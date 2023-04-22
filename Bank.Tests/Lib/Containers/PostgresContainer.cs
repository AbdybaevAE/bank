using System.Data.Common;
using Npgsql;
using Testcontainers.PostgreSql;

namespace Bank.Tests.Lib
{
    public abstract class PostgresContainer : IAsyncLifetime
    {
        protected readonly List<string> _filesToMigrate;
        protected PostgresContainer(List<string> filesToMigrate)
        {
            if (filesToMigrate is null)
            {
                throw new ArgumentNullException(nameof(filesToMigrate));
            }
            this._filesToMigrate = filesToMigrate;
        }
        protected PostgresContainer(string fileToMigrate) : this(new List<string>() { fileToMigrate })
        {
        }
        protected readonly PostgreSqlContainer CurrentContainer = new PostgreSqlBuilder().Build();

        public Task DisposeAsync()
        {
            return CurrentContainer.DisposeAsync().AsTask();
        }

        public async Task InitializeAsync()
        {
            await CurrentContainer.StartAsync();
            OnContainerUp();
            RunMigrations();
        }
        protected abstract void OnContainerUp();
        protected void RunMigrations()
        {
            using DbConnection connection = new NpgsqlConnection(CurrentContainer.GetConnectionString());
            connection.Open();
            foreach (var file in _filesToMigrate)
            {
                var command = connection.CreateCommand();
                command.CommandText = File.ReadAllText(file);
                _ = command.ExecuteNonQuery();
            }
        }
    }
}
