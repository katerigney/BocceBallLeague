using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BocceBallLeague.Model;

namespace BocceBallLeague.Data
{
    class DataContext : DbContext
    {
            public DataContext() : base("name=DefaultConnection")
            {

            }

            public DbSet<Teams> Teams { get; set; }
            public DbSet<Record> Records { get; set; }
            public DbSet<Players> Players { get; set; }
            public DbSet<Games> Games { get; set; }
        
    }
}
