using ProjectN.Application.Contracts.Persistance;
using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Persistance.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ProjectNDbContext dbContext) : base(dbContext)
        {

        }
        
    }
}
