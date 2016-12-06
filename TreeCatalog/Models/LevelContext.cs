using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog.Models
{
    class LevelContext : DbContext
    {
        public LevelContext() : base("DefaultConnection")
        {

        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<SubLevel> SubLevels { get; set; }
        public DbSet<SubSubLevel> SubSubLevels { get; set; }
    }
}
