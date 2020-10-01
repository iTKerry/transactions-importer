using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TransactionsImporter.Api.Infrastructure.ModelBinder.DateTime;

namespace TransactionsImporter.Api.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionsImporterMvc(this IServiceCollection services) =>
            services
                .AddControllers(SetupMvcOptions)
                .AddNewtonsoftJson(options => options.SerializerSettings.Formatting = Formatting.Indented)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .Services;

        private static void SetupMvcOptions(MvcOptions options) => 
            options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
    }
}