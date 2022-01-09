#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerUI.Models;

namespace ProjectTrackerUI.Data
{
    public class ApplicationDbContext : IdentityDbContext //: DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Project { get; set; }

        public DbSet<Issue> Issue { get; set; }
    }
}
