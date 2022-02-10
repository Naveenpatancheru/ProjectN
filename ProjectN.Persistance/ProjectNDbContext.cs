using Microsoft.EntityFrameworkCore;
using ProjectN.Domain.Common;
using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectN.Persistance
{
    public class ProjectNDbContext : DbContext
    {
        public ProjectNDbContext(DbContextOptions<ProjectNDbContext> options) : base(options)
        {

        }

        public DbSet<College> Colleges { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectNDbContext).Assembly);
            //seed data, added through migrations
            var collegeGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var countryGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            modelBuilder.Entity<Country>().HasData(new Country
            {
                   CountryId = countryGuid,
                   CountryCode = "USA",
                   CountryName = "United States Of America"
            });
            modelBuilder.Entity<College>().HasData(new College
            {
                CollegeId = collegeGuid,
                CollegeCode = "UCM",
                CollegeName = "University Of Central Missouri",
                CollegeType = "Public",
                CollegeLocation = "Missouri",
                CountryId = countryGuid,
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
