namespace TransactionsImporter.Common.Configurations
{
    public class ConnectionStrings
    {
        public const string Key = nameof(ConnectionStrings);
        
        public string TransactionsImporterDb { get; set; }
    }
}