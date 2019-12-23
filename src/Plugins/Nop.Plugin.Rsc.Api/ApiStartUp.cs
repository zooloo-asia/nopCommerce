using System.Net;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Plugin.Rsc.Api.Services;

namespace Nop.Plugin.Rsc.Api
{
    public class ApiStartUp:INopStartup
    {
        private const string _allowCorsPolicy = "_allowCors";
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRscShoppingCartService, RscShoppingCartService>();
            services.AddScoped<IRscProductService, RscProductService>();
            
            services.AddCors(option =>
            {
                option.AddPolicy(_allowCorsPolicy, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var config = JwtConfig.Instance;
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Key)),
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseCors(_allowCorsPolicy);
            application.UseAuthentication();
            application.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    response.Redirect("~/api/test");
                }
            });

        }

        public int Order => 1;
        
    }
}