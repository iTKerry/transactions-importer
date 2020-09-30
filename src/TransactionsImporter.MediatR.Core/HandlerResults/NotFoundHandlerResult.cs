using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.MediatR.Core.HandlerResults
{
    public class NotFoundHandlerResult<T> : IHandlerResult<T>
    {
    }
    
    public class NotFoundHandlerResult : IHandlerResult
    {
    }
}