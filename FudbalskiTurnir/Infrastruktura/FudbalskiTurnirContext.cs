using FudbalskiTurnir.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FudbalskiTurnir.Infrastruktura
{
    public class FudbalskiTurnirContext : IdentityDbContext<AppUser>
    {
        public FudbalskiTurnirContext()
        {
        }

        public FudbalskiTurnirContext(DbContextOptions<FudbalskiTurnirContext> options) : base(options)
        {
        } 
        public DbSet<Page> Pages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Result> Results { get; set; }
    
        
    }
}
