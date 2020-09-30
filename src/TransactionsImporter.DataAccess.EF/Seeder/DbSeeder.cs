using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.EF.Seeder.Abstractions;

namespace TransactionsImporter.DataAccess.EF.Seeder
{
    public class DbSeeder : IDbSeeder
    {
        private readonly WriteDbContext _dbContext;

        public DbSeeder(WriteDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.EnsureDeletedAsync(cancellationToken);
            await _dbContext.Database.MigrateAsync(cancellationToken);
            
            await InitializeInternalAsync(cancellationToken);
        }

        private async Task InitializeInternalAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Currencies.AddRangeAsync(Currency.AllCurrencies, cancellationToken);
            
            await _dbContext.SaveChangesAsync(true, cancellationToken);
        }
    }
}