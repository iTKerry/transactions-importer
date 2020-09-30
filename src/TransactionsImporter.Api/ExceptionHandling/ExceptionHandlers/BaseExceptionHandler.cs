using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Api.ExceptionHandling.Abstractions;

namespace TransactionsImporter.Api.ExceptionHandling.ExceptionHandlers
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        public Task HandleException(Exception exception, HttpContext context)
        {
            var errorResponse = CreateErrorMessage(exception);
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            return context.Response.WriteAsync(errorResponse.Message);
        }

        protected abstract ErrorResponse CreateErrorMessage(Exception exception);

        protected class ErrorResponse
        {
            public ErrorResponse(HttpStatusCode statusCode, string message)
            {
                StatusCode = statusCode;
                Message = message;
            }

            public HttpStatusCode StatusCode { get; }
            public string Message { get; }
        }
    }
}