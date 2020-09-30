using System;

namespace TransactionsImporter.Application.Readers
{
    public class FileTransactionDto
    {
        public string TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }
        public decimal? Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}