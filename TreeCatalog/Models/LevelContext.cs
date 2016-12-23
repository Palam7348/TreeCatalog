using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog.Models
{
    class LevelContext : DbContext
    {
        public LevelContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<SubLevel> SubLevels { get; set; }
        public DbSet<SubSubLevel> SubSubLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
