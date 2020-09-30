using TransactionsImporter.DataAccess.Abstractions.Attributes;

namespace TransactionsImporter.DataAccess.Abstractions.Enums
{
    public enum TransactionStatus
    {
        [TransactionStatusDisplay("Approved")]
        A,
        
        [TransactionStatusDisplay("Failed")]
        [TransactionStatusDisplay("Rejected")]
        R,
        
        [TransactionStatusDisplay("Finished")]
        [TransactionStatusDisplay("Done")]
        D
    }
}