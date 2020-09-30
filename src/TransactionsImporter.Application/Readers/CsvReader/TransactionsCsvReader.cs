using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Application.Abstractions;

namespace TransactionsImporter.Application.Readers.CsvReader
{
    public sealed class TransactionsCsvReader : ITransactionsFileReader
    {
        public List<FileTransactionDto> ReadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}