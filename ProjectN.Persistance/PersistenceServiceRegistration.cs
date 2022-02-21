using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectN.Application.Contracts.Persistance;
using ProjectN.Persistance.Repositories;


using ProjectN.Application.Contracts.Identity;
using ProjectN.Application.Models.Authentication;

using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;


namespace ProjectN.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("AppConfigConnectionString");
  
            services.AddDbContext<ProjectNDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                  sqlServerOptionsAction: sqlOptions =>
                  {
                      sqlOptions.EnableRetryOnFailure();
                  });
            });



            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));

            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }
    }
}
