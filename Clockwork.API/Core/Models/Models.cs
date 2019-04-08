using Clockwork.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Models
{
    public class ClockworkContext : DbContext
    {
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }
        public DbSet<ServiceLogging> ServiceLoggings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
    
}
