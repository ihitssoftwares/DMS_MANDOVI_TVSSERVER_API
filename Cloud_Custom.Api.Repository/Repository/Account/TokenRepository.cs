
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Cloud_Custom.Api.Repository.IRepository.Account;
using Cloud_Custom.Api.Shared.General;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cloud_Custom.Api.Repository.Repository.Account
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppTokens _tokenConfig;
        public TokenRepository(IOptions<AppSettings> appSettings)
        {
            _tokenConfig = appSettings.Value?.Token;
        }

        string ITokenRepository.GenerateToken<T>(AppTokenSettings<T> tokenSettings)
        {
            if (tokenSettings?.Configration == null)
            {
                if (tokenSettings?.Type == "LOGIN")
                    tokenSettings.Configration = _tokenConfig.Login;
                else if (tokenSettings?.Type == "RESET_PASSWORD")
                    tokenSettings.Configration = _tokenConfig.ResetPassword;
                else if (tokenSettings?.Type == "MOBILE_LOGIN")
                    tokenSettings.Configration = _tokenConfig.MobileLogin;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenSettings.Configration.TokenSecret);
            var issuedAt = tokenSettings.IssuedAt.ToUniversalTime().AddSeconds(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(tokenSettings.Data))
                }),
                IssuedAt = issuedAt,
                Expires = issuedAt.AddHours(tokenSettings.Configration.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
