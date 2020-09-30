using System;
using System.Threading.Tasks;

namespace TransactionsImporter.DataAccess.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}