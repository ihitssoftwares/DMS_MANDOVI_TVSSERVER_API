using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace TVS_API_PLUS.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/ServiceAuth")]
    public class ServiceAuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ServiceAuthController(IConfiguration config)
        {
            _config = config;
        }

        // Issues a JWT for the TVS service account.
        // 1. The client certificate must be present and chain to our CA (enforced by IIS).
        // 2. The certificate thumbprint must match the TVS certificate.
        // 3. The username and password must match the ServiceAccount settings.
        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] ServiceTokenRequest request)
        {
            // Step 1: certificate must be present
            var cert = await HttpContext.Connection.GetClientCertificateAsync();
            if (cert == null)
                return StatusCode(403, new { error = "Client certificate required." });

            // Step 2: certificate must be the TVS certificate
            var expectedThumbprint = _config["ServiceAccount:CertificateThumbprint"]?.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(expectedThumbprint) ||
                !string.Equals(cert.Thumbprint, expectedThumbprint, StringComparison.OrdinalIgnoreCase))
                return StatusCode(403, new { error = "This certificate is not allowed for the service account." });

            // Step 3: username and password must match
            var expectedUser = _config["ServiceAccount:Username"];
            var expectedPass = _config["ServiceAccount:Password"];

            if (string.IsNullOrWhiteSpace(expectedUser) || string.IsNullOrWhiteSpace(expectedPass))
                return StatusCode(500, new { error = "Service account is not configured." });

            bool valid = SafeEquals(request?.Username, expectedUser) &
                         SafeEquals(request?.Password, expectedPass);
            if (!valid)
                return Unauthorized(new { error = "Invalid service credentials." });

            // Same claim shape as the existing login token, so UserHelper keeps working.
            var userData = JsonSerializer.Serialize(new
            {
                UserGuid = _config["ServiceAccount:UserGuid"],
                CompanyGuid = _config["ServiceAccount:CompanyGuid"],
                GroupCompanyGUID = "00000000-0000-0000-0000-000000000000"
            });

            var secret = _config["Token:Login:TokenSecret"];
            var issuer = _config["Token:Login:Issuer"];
            var audience = _config["Token:Login:Audience"];
            var hours = _config.GetValue<int>("Token:Login:Expiration", 24);
            var now = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, expectedUser),
                new Claim(ClaimTypes.UserData, userData),
                new Claim("client_type", "service")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: now.AddHours(hours),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    SecurityAlgorithms.HmacSha256));

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                tokenType = "Bearer",
                expiresIn = hours * 3600
            });
        }

        // Compares two strings in constant time, so the check doesn't reveal how many characters matched.
        private static bool SafeEquals(string a, string b)
        {
            if (a == null || b == null) return false;
            var x = Encoding.UTF8.GetBytes(a);
            var y = Encoding.UTF8.GetBytes(b);
            return x.Length == y.Length && CryptographicOperations.FixedTimeEquals(x, y);
        }
    }
}