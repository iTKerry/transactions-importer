using System;
using System.Net;
using TransactionsImporter.Api.ExceptionHandling.Abstractions;

namespace TransactionsImporter.Api.ExceptionHandling.ExceptionHandlers
{
    public class DefaultExceptionHandler : BaseExceptionHandler, IExceptionHandler<Exception>
    {
        private const string ErrorMessage = "Some unexpected error occurred.";

        protected override ErrorResponse CreateErrorMessage(Exception exception) =>
            new ErrorResponse(HttpStatusCode.InternalServerError, ErrorMessage);
    }
}