using BetterExtensions.Domain.Repository;
using TransactionsImporter.DataAccess.Abstractions.Entities;

namespace TransactionsImporter.DataAccess.Abstractions.Repositories
{
    public interface ITransactionsRepository : IWriteRepository<Transaction>
    {
    }
}