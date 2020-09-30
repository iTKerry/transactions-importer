﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionsImporter.MediatR.Core.Abstractions;
using TransactionsImporter.MediatR.Core.HandlerResults;

namespace TransactionsImporter.MediatR.Core
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, IHandlerResult<TResponse>>
        where TRequest : IRequest<IHandlerResult<TResponse>>
    {
        public abstract Task<IHandlerResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

        protected static IHandlerResult<TResponse> Data(TResponse data) =>
            new DataHandlerResult<TResponse>(data);

        protected static IHandlerResult<TResponse> PagedData(TResponse data, int count) =>
            new PagedDataHandlerResult<TResponse>(data, count);

        protected static IHandlerResult<TResponse> NotFound() =>
            new NotFoundHandlerResult<TResponse>();

        protected static IHandlerResult<TResponse> ValidationFailed(string message) =>
            new ValidationFailedHandlerResult<TResponse>(message);
    }
    
    public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest, IHandlerResult>
        where TRequest : IRequest<IHandlerResult>
    {
        public abstract Task<IHandlerResult> Handle(TRequest request, CancellationToken ctx);

        protected static IHandlerResult Ok() =>
            new OkHandlerResult();

        protected static IHandlerResult NotFound() =>
            new NotFoundHandlerResult();

        protected static IHandlerResult ValidationFailed(string message) =>
            new ValidationFailedHandlerResult(message);
    }
}