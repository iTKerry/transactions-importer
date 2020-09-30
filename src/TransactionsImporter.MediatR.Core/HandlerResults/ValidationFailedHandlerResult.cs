
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.MediatR.Core.HandlerResults
{
    public class ValidationFailedHandlerResult<T> : IHandlerResult<T>
    {
        public ValidationFailedHandlerResult(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
    
    public class ValidationFailedHandlerResult : IHandlerResult
    {
        public ValidationFailedHandlerResult(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}