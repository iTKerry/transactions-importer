using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionsImporter.Common.Configurations;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterConfigurations(
            this IServiceCollection services, IConfiguration cfg) =>
            services
                .Configure<ConnectionStrings>(cfg.GetSection(ConnectionStrings.Key));
    }
}