using TransactionsImporter.DataAccess.Abstractions.Attributes;

namespace TransactionsImporter.DataAccess.Abstractions.Enums
{
    public enum TransactionStatus : short
    {
        [TransactionStatusDisplay("Approved")]
        A = 0,
        
        [TransactionStatusDisplay("Failed")]
        [TransactionStatusDisplay("Rejected")]
        R = 1,
        
        [TransactionStatusDisplay("Finished")]
        [TransactionStatusDisplay("Done")]
        D = 2
    }
}