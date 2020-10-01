namespace TransactionsImporter.Application.Readers
{
    public class FileTransactionDto
    {
        public string TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public string Status { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}