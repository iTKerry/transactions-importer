using System.Threading;
using System.Threading.Tasks;

namespace TransactionsImporter.DataAccess.EF.Seeder.Abstractions
{
    public interface IDbSeeder
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}