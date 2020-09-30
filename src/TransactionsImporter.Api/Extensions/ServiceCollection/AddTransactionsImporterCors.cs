using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterCors(this IServiceCollection services) =>
            services.AddCors(SetupCorsOptions);

        private static void SetupCorsOptions(CorsOptions options) =>
            options.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    }
}