using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Application.Readers.CsvReader.FileData;

namespace TransactionsImporter.Application.Readers.CsvReader
{
    public sealed class TransactionsCsvReader : ITransactionsFileReader
    {
        public List<FileTransactionDto> ReadFile(IFormFile file)
        {
            var cfg = new CsvConfiguration {HasHeaderRecord = false};
            using var reader = new StreamReader(file.OpenReadStream());
            using var csvReader = new CsvHelper.CsvReader(reader, cfg);

            var records = csvReader.GetRecords<CsvTransaction>();
            return records.Select(MappingProjection).ToList();
        }

        private static FileTransactionDto MappingProjection(CsvTransaction csv) =>
            new FileTransactionDto
            {
                TransactionId = csv.TransactionId,
                Amount = csv.Amount,
                CurrencyCode = csv.CurrencyCode,
                Status = csv.Status,
                TransactionDate = csv.TransactionDate
            };
    }
}