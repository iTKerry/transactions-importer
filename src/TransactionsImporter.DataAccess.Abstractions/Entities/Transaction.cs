using BetterExtensions.Domain.Base;
using CSharpFunctionalExtensions;
using TransactionsImporter.DataAccess.Abstractions.Enums;
using TransactionsImporter.DataAccess.Abstractions.ValueObjects;

namespace TransactionsImporter.DataAccess.Abstractions.Entities
{
    public class Transaction : AggregateRoot
    {
        protected Transaction() {}

        private Transaction(
            TransactionId id, 
            decimal amount,
            Currency currency,
            TransactionDate date, 
            TransactionStatus status)
        {
            TransactionId = id;
            Amount = amount;
            Currency = currency;
            TransactionDate = date;
            Status = status;
        }

        public virtual TransactionId TransactionId { get; private set; }
        public decimal Amount { get; private set; }
        public virtual Currency Currency { get; private set; }
        public virtual TransactionDate TransactionDate { get; private set; }
        public TransactionStatus Status { get; private set; }

        public static Result<Transaction> Create(
            Maybe<TransactionId> maybeId, 
            decimal amount,
            Maybe<Currency> maybeCurrency,
            Maybe<TransactionDate> maybeDate,
            TransactionStatus status)
        {
            var idResult = maybeId.ToResult("TransactionIdentifier is null.");
            var currencyResult = maybeCurrency.ToResult("Currency is null");
            var dateResult = maybeDate.ToResult("TransactionDate is null.");

            return Result
                .Combine(idResult, dateResult)
                .Map(() => new Transaction(idResult.Value, amount, currencyResult.Value, dateResult.Value, status));
        }
    }
}