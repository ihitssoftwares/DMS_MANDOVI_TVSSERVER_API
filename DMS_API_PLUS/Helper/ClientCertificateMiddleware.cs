using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SAMPLE_API_PLUS.Helper
{
    // Runs on every request, before routing, JWT checks, or Swagger.
    // Refuses any request whose client certificate does not chain to our CA.
    public class ClientCertificateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly X509Certificate2 _trustedCa;

        public ClientCertificateMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _next = next;

            // Load our CA's public certificate once, at startup
            var caPath = Path.Combine(
                environment.ContentRootPath,
                configuration["Tls:ClientCaPath"] ?? "Certs/ca.crt");

            _trustedCa = new X509Certificate2(caPath);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Get the certificate the client presented during the TLS handshake
            var clientCert = await context.Connection.GetClientCertificateAsync();

            if (clientCert == null || !CertificateValidator.IsIssuedByTrustedCa(clientCert, _trustedCa))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("A valid client certificate is required.");
                return; // stop here: the request never reaches the controller
            }

            // Certificate is valid: continue to the next step in the pipeline
            await _next(context);
        }
    }
}