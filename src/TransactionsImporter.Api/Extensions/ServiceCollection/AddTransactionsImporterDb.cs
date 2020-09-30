using Microsoft.Extensions.DependencyInjection;
using TransactionsImporter.DataAccess.EF;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterDb(this IServiceCollection services) => 
            services
                .AddDbContext<WriteDbContext>()
                .AddDbContext<ReadDbContext>();
    }
}