using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectN.Identity.Models;

namespace ProjectN.Identity
{
    public class ProjectNIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectNIdentityDbContext(DbContextOptions<ProjectNIdentityDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
