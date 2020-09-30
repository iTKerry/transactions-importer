using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TransactionsImporter.Api.Infrastructure.Middlewares;

namespace TransactionsImporter.Api.Extensions.ApplicationBuilder
{
    public static partial class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env) =>
            env.IsDevelopment()
                ? app.UseDeveloperExceptionPage()
                : app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}