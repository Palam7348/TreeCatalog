using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog.Models
{
    class Level
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SubLevel> Branches { get; set; }
    }
}
