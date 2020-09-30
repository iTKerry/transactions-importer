using TransactionsImporter.MediatR.Core;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Commands.Abstractions
{
    public abstract class CommandHandlerBase<TRequest> : RequestHandlerBase<TRequest> 
        where TRequest : ICommand
    {
    }
}