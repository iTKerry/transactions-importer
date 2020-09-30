using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.MediatR.Core.HandlerResults
{
    public class DataHandlerResult<T> : IHandlerResult<T>
    {
        public DataHandlerResult(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
