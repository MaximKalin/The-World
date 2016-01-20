using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace TheWorld.Models
{
    public class WorldContext : IdentityDbContext<WorldUser>
    {
        public WorldContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "Data Source=(localdb)\\ProjectsV12;Database=TheWorldDb;Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}