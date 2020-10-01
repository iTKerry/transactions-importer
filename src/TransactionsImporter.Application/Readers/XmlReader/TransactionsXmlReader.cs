using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Application.Readers.XmlReader.FileData;

namespace TransactionsImporter.Application.Readers.XmlReader
{
    public sealed class TransactionsXmlReader : ITransactionsFileReader
    {
        public List<FileTransactionDto> ReadFile(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());

            var serializer = new XmlSerializer(typeof(XmlTransactions));
            var xmlTransactions = (XmlTransactions) serializer.Deserialize(reader);

            return xmlTransactions.Transactions.Select(MappingProjection).ToList();
        }
        
        private static FileTransactionDto MappingProjection(XmlTransaction xml) =>
            new FileTransactionDto
            {
                TransactionId = xml.Id,
                Amount = xml.PaymentDetails.Amount,
                CurrencyCode = xml.PaymentDetails.CurrencyCode,
                Status = xml.Status,
                TransactionDate = xml.TransactionDate
            };
    }
}