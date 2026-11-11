using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SAMPLE_API_PLUS.Helper
{
    // Limits a TVS service token to the endpoints TVS may call.
    // Staff tokens are not affected.
    public class ServiceTokenRestrictionMiddleware
    {
        private static readonly string[] AllowedServicePaths =
        {
            "/api/MCareCustomerDetails",
            "/api/ServiceAuth"
        };

        private readonly RequestDelegate _next;

        public ServiceTokenRestrictionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only requests carrying the TVS service claim are checked
            if (context.User.HasClaim("client_type", "service"))
            {
                var path = context.Request.Path.Value ?? string.Empty;

                bool allowed = false;
                foreach (var allowedPath in AllowedServicePaths)
                {
                    // Exact match, or a sub-path of it (avoids matching "/api/MCareCustomerDetailsX")
                    if (path.Equals(allowedPath, StringComparison.OrdinalIgnoreCase) ||
                        path.StartsWith(allowedPath + "/", StringComparison.OrdinalIgnoreCase))
                    {
                        allowed = true;
                        break;
                    }
                }

                if (!allowed)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("This service token cannot access this endpoint.");
                    return;
                }
            }

            await _next(context);
        }
    }
}