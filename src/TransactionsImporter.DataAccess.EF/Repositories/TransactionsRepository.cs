using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.DataAccess.EF.Abstractions;

namespace TransactionsImporter.DataAccess.EF.Repositories
{
    public class TransactionsRepository 
        : WriteRepository<Transaction>, ITransactionsRepository
    {
        public TransactionsRepository(WriteDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}