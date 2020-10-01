using System.Collections.Generic;
using CSharpFunctionalExtensions;
using TransactionsImporter.Application.Readers;
using TransactionsImporter.DataAccess.Abstractions.Entities;

namespace TransactionsImporter.Domain.Abstractions
{
    public interface ITransactionsMapper
    {
        Result<List<Transaction>> Map(List<FileTransactionDto> data);
    }
}