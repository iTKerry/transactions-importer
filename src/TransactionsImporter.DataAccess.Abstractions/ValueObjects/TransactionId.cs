using CSharpFunctionalExtensions;

namespace TransactionsImporter.DataAccess.Abstractions.ValueObjects
{
    public class TransactionId : ValueObject<TransactionId>
    {
        protected TransactionId()
        {
        }

        private TransactionId(string value) => 
            Value = value;

        public string Value { get; }

        public static Result<TransactionId> Create(string identifier) =>
            identifier switch
            {
                _ when string.IsNullOrWhiteSpace(identifier) => 
                    Result.Failure<TransactionId>("Identifier is null or empty."),
                
                _ when identifier.Length > 50 => 
                    Result.Failure<TransactionId>("Identifier length is more than 50."),

                _ when identifier.Trim().Length > 0 && identifier.Trim().Length <= 50 =>
                    Result.Success(new TransactionId(identifier)),
                
                _ => Result.Failure<TransactionId>("Identifier failed with unknown error")
            };

        protected override bool EqualsCore(TransactionId other) => 
            Value == other.Value;

        protected override int GetHashCodeCore() => 
            Value.GetHashCode();
    }
}