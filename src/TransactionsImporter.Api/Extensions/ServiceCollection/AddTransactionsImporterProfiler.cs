using Microsoft.Extensions.DependencyInjection;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterProfiler(this IServiceCollection services) =>
            services
                .AddMiniProfiler()
                .AddEntityFramework()
                .Services;
    }
}