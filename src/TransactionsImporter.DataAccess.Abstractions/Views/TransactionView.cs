namespace TransactionsImporter.DataAccess.Abstractions.Views
{
    public class TransactionView
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
    }
}