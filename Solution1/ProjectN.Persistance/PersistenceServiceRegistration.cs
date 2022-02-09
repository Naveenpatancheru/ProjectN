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

namespace ProjectN.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectNDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("ProjectNConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));

            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }
    }
}
