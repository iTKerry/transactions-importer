using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.Formatting = Formatting.Indented)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .Services;
    }
}