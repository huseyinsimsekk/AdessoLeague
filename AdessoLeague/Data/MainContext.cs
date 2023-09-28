using AdessoLeague.Data.Configuration;
using AdessoLeague.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdessoLeague.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }
        public DbSet<GroupTeam> GroupTeams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupTeamConfiguration());
        
        }
    }
}
