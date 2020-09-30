using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Application.Readers;

namespace TransactionsImporter.Application.Abstractions
{
    public interface ITransactionsReader
    {
        List<FileTransactionDto> Read(IFormFile file);
    }
}