using Bank.EventStore.Models.Event;
using Microsoft.EntityFrameworkCore;

namespace Bank.EventStore
{
    public class PostgresDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public PostgresDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetSection("EventStore").GetValue<string>("ConnectionString");
            options.UseNpgsql(connectionString);
        }
        public DbSet<Event> Events { get; set; }
    }
}
