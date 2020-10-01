namespace TransactionsImporter.Application.Readers.CsvReader.FileData
{
    public class CsvTransaction
    {
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
