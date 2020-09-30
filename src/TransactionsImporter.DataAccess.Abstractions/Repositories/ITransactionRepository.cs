using BetterExtensions.Domain.Repository;
using TransactionsImporter.DataAccess.Abstractions.Entities;

namespace TransactionsImporter.DataAccess.Abstractions.Repositories
{
    public interface ITransactionRepository : IWriteRepository<Transaction>
    {
    }
}