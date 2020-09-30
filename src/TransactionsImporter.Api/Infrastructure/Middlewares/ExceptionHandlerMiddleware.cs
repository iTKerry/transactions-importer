using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Api.ExceptionHandling.Abstractions;

namespace TransactionsImporter.Api.Infrastructure.Middlewares
{
    public sealed class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionRequestHandler _exceptionRequestHandler;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            IExceptionRequestHandler exceptionRequestHandler)
        {
            _exceptionRequestHandler = exceptionRequestHandler;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) when (!(ex is StackOverflowException))
            {
                await _exceptionRequestHandler.Handle(httpContext, ex);
            }
        }
    }
}