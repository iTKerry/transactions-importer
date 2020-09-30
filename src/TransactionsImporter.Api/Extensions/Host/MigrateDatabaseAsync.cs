using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TransactionsImporter.DataAccess.EF.Seeder.Abstractions;

namespace TransactionsImporter.Api.Extensions.Host
{
    public static class HostExtensions
    {
        public static async Task<IHost> MigrateDatabaseAsync<T>(this IHost host) 
            where T : DbContext
        {
            using var scope = host.Services.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<T>();

            await appDbContext.Database.EnsureDeletedAsync();
            await appDbContext.Database.MigrateAsync();

            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
            await dbInitializer.SeedAsync();

            return host;
        }
    }
}