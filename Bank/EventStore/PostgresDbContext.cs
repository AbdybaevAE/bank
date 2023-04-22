using Bank.EventStore.Models.Event;
using Microsoft.EntityFrameworkCore;

namespace Bank.EventStore
{
    public class PostgresDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public PostgresDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetSection("EventStore").GetValue<string>("ConnectionString");
            options.UseNpgsql(connectionString);
        }
        public DbSet<Event> Events { get; set; }
    }
}
