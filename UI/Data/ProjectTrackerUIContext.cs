#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerDataAccess.Models;

namespace ProjectTrackerUI.Data
{
    public class ProjectTrackerUIContext : DbContext
    {
        public ProjectTrackerUIContext (DbContextOptions<ProjectTrackerUIContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectTrackerDataAccess.Models.FeatureModel> Feature { get; set; }
    }
}
