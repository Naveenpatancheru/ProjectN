using ProjectN.Application.Contracts.Identity;
using ProjectN.Application.Models.Authentication;
using ProjectN.Identity.Models;
using ProjectN.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;
using ProjectN.Identity;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ProjectN.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            string connectionString = configuration.GetValue<string>("AppConfigConnectionString");
            //     var keyVaultUrl = "https://projectn-keyvault.vault.azure.net/";
            ////     var credential = new DefaultAzureCredential();
            //     var credential = new ClientSecretCredential(
            //                     "AZURE_TENANT_ID",  // use value from "tenant"
            //                     "AZURE_CLIENT_ID", //  use value from "appId"
            //                     "AZURE_CLIENT_SECRET" // use value from "password"
            //                     );
            //     var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential);
            //     KeyVaultSecret secret = client.GetSecret("ProjectNDbConnectionString");

            //services.AddDbContext<ProjectNIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(connectionString),
            //    b => b.MigrationsAssembly(typeof(ProjectNIdentityDbContext).Assembly.FullName)));
            services.AddDbContext<ProjectNIdentityDbContext>(options => options.UseSqlServer(connectionString,
              b => b.MigrationsAssembly(typeof(ProjectNIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProjectNIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };

                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("401 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("403 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
        }
    }
}
