using TransactionsImporter.MediatR.Core;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Queries.Abstractions
{
    public abstract class QueryHandlerBase<TRequest, TResponse> : RequestHandlerBase<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }
}