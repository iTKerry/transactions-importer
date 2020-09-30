using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TransactionsImporter.Api.ExceptionHandling.Abstractions
{
    public interface IExceptionHandler
    {
        Task HandleException(Exception exception, HttpContext context);
    }
}