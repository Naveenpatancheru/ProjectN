using ProjectN.Application.Contracts.Persistance;
using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Persistance.Repositories
{
    public class CollegeRepository : BaseRepository<College>, ICollegeRepository
    {
        public CollegeRepository(ProjectNDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsCollegeNameUnique(string collegeName)
        {
            var collegeNameMatches = _dbContext.Colleges.Any( e => e.CollegeName == collegeName );
            return Task.FromResult( collegeNameMatches );
        }
    }
}
