using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TransactionsImporter.Api.Extensions.ApplicationBuilder;
using TransactionsImporter.Api.Extensions.ServiceCollection;

namespace TransactionsImporter.Api
{
    public class Startup
    {
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration configuration) =>
            _cfg = configuration;

        public void ConfigureServices(IServiceCollection services) =>
            services.AddOptions()
                .AddAutoMapper(typeof(Startup).Assembly)
                .AddTransactionsImporterConfigurations(_cfg)
                .AddTransactionsImporterCompression()
                .AddTransactionsImporterMvc()
                .AddTransactionsImporterProfiler()
                .AddTransactionsImporterDb()
                .AddMemoryCache()
                .AddTransactionsImporterCors()
                .AddRouteOptions()
                .AddTransactionsImporterHealthChecks()
                .AddTransactionsImporterSwagger();

        public void ConfigureContainer(ContainerBuilder builder) =>
            builder.RegisterAssemblyModules(typeof(Startup).Assembly);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.UseExceptionHandler(env)
                .UseStaticFiles()
                .UseTransactionsImporterUi()
                .UseSerilogRequestLogging()
                .UseCors()
                .UseAuthentication()
                .UseRouting()
                .UseEndpoints(e =>
                {
                    e.MapControllers();
                    e.MapHealthChecks("/_health");
                });
    }
}