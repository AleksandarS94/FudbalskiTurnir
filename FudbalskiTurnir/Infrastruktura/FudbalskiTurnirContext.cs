using FudbalskiTurnir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Infrastruktura
{
    public class FudbalskiTurnirContext : DbContext
    {
        public FudbalskiTurnirContext()
        {
        }

        public FudbalskiTurnirContext(DbContextOptions<FudbalskiTurnirContext> options) : base(options)
        {
        }
            public DbSet<Page> Pages { get; set; }
            public DbSet<User> Users { get; set; }
    
        
    }
}
