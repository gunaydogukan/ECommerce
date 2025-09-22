using ECommerce.Core.Helpers.Security;
using ECommerce.Core.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Extensions
{
    public static class JwtRegistration
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtOptions>(config.GetSection("JwtOptions"));

            services.AddScoped<IJwtTokenService, JwtTokenService>();

            var jwtOptions = config.GetSection("JwtOptions").Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                    };

                    //ex middleware tasinacak
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            // Varsayılan davranışı bastırıyoruz
                            context.HandleResponse();

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var result = System.Text.Json.JsonSerializer.Serialize(new
                            {
                                message = "Yetkisiz erişim. Lütfen giriş yapınız."
                            });

                            return context.Response.WriteAsync(result);
                        }
                    };

                });

            return services;
        }
    }
}