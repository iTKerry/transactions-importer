using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TransactionsImporter.Api.Common;
using TransactionsImporter.Api.ExceptionHandling.Abstractions;

namespace TransactionsImporter.Api.ExceptionHandling.ExceptionHandlers
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        public Task HandleException(Exception exception, HttpContext context)
        {
            var errorResponse = CreateErrorMessage(exception);
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            var jsonResult = JsonConvert.SerializeObject(Envelope.Error(errorResponse.Message));
            return context.Response.WriteAsync(jsonResult);
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