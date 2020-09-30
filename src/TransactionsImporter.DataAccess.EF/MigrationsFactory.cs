using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using TransactionsImporter.Common.Configurations;

namespace TransactionsImporter.DataAccess.EF
{
    public class MigrationsFactory : IDesignTimeDbContextFactory<WriteDbContext>
    {
        private const string ConnectionString =
            "Server=localhost,1433;Database=TransactionsImporterDb;User=SA;Password=Your_password123;";
        
        public WriteDbContext CreateDbContext(string[] args)
        {
            var connectionStrings = new ConnectionStrings { TransactionsImporterDb = ConnectionString};

            return new WriteDbContext(null, null, new OptionsWrapper<ConnectionStrings>(connectionStrings));
        }
    }
}