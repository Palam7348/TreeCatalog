using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeCatalog.Models;

namespace TreeCatalog
{

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMode console = new ConsoleMode();
            console.ControlPanel();

            Console.ReadLine();
        }
    }
}
