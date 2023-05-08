using Npgsql;
using Testcontainers.PostgreSql;

namespace Bank.Tests.LibTest
{
    public class PersistenceFixture : IDisposable, IDataContainer
    {
        public readonly PostgreSqlContainer Container = new PostgreSqlBuilder().Build();
        public PersistenceFixture()
        {
            Container.StartAsync().GetAwaiter().GetResult();
        }
        public void Dispose()
        {
            Container.StopAsync().GetAwaiter().GetResult();
        }
        public void SeedData()
        {
            var files = new List<string>() { "Resources/create_relations.sql" };
            foreach (var file in files)
            {
                var query = File.ReadAllText(file);
                using var dataSource = NpgsqlDataSource.Create(Container.GetConnectionString());
                using var cmd = dataSource.CreateCommand(query);
                cmd.ExecuteNonQuery();
            }
        }
        public void ClearData()
        {
            using var dataSource = NpgsqlDataSource.Create(Container.GetConnectionString());
            var query = File.ReadAllText("Resources/clear.sql");
            using var cmd = dataSource.CreateCommand(query);
            cmd.ExecuteNonQuery();
        }
    }
}
