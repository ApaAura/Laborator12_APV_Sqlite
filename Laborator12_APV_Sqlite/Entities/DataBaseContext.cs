using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator12_APV_Sqlite.Entities
{
    internal class DataBaseContext
    {
        private readonly string? _connectionString;
        public DataBaseContext()
        {
            Configurator configurator = new Configurator("appsettings.json");
            _connectionString = configurator.ConnectionString;
        }
        public DataBaseContext(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = _connectionString };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            opBuilder.UseSqlite(connection);
        }
    }
}
