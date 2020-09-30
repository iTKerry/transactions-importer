using Microsoft.Extensions.DependencyInjection;
using TransactionsImporter.DataAccess.EF;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterHealthChecks(this IServiceCollection services) =>
            services
                .AddHealthChecks()
                .AddDbContextCheck<WriteDbContext>()
                .AddDbContextCheck<ReadDbContext>()
                .Services;
    }
}