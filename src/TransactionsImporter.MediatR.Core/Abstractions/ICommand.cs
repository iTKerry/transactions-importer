using MediatR;

namespace TransactionsImporter.MediatR.Core.Abstractions
{
    public interface ICommand : IRequest<IHandlerResult>
    {
    }
}