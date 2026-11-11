using System;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Shared.General;
using SAMPLE_API_PLUS.Middleware;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using SAMPLE_API_PLUS.Helper;

namespace SAMPLE_API_PLUS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 100000;
                options.KeyLengthLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = 1024L * 1024L * 1024L;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddControllers(options =>
            {
                options.MaxModelBindingCollectionSize = int.MaxValue;
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddDependencyInjectionServices();

            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below."
                });
                option.CustomSchemaIds(i => i.FullName);
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

           

            // TVS: settings and the client that calls the Mandovi API
            services.Configure<McareApiOptions>(Configuration.GetSection("McareApi"));

            services.AddHttpClient<McareApiClient>((sp, client) =>
            {
                var mcareOptions = sp.GetRequiredService<IOptions<McareApiOptions>>().Value;
                client.BaseAddress = new Uri(mcareOptions.BaseUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(sp =>
            {
                var mcareOptions = sp.GetRequiredService<IOptions<McareApiOptions>>().Value;
                var hostEnv = sp.GetRequiredService<IHostEnvironment>();

                var handler = new HttpClientHandler
                {
                    // Present tvs-client.pfx whenever Mandovi asks for a certificate
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
                };

                handler.ClientCertificates.Add(new X509Certificate2(
                    Path.Combine(hostEnv.ContentRootPath, mcareOptions.ClientCertPath),
                    mcareOptions.ClientCertPassword));

                return handler;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TVS API");
                });
            }

            app.UseRouting();
            app.UseCors("ApiCorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<DateFormatMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}