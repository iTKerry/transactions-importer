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
            CurrencyCode currencyCode,
            TransactionDate date, 
            TransactionStatus status)
        {
            TransactionId = id;
            Amount = amount;
            CurrencyCode = currencyCode;
            TransactionDate = date;
            Status = status;
        }

        public virtual TransactionId TransactionId { get; private set; }
        public decimal Amount { get; private set; }
        public virtual CurrencyCode CurrencyCode { get; private set; }
        public virtual TransactionDate TransactionDate { get; private set; }
        public TransactionStatus Status { get; private set; }

        public static Result<Transaction> Create(
            Maybe<TransactionId> maybeId, 
            decimal amount,
            Maybe<CurrencyCode> maybeCurrencyCode,
            Maybe<TransactionDate> maybeDate,
            TransactionStatus status)
        {
            var idResult = maybeId.ToResult("TransactionIdentifier is null.");
            var currencyCodeResult = maybeCurrencyCode.ToResult("CurrencyCode is null");
            var dateResult = maybeDate.ToResult("TransactionDate is null.");

            return Result
                .Combine(idResult, dateResult)
                .Map(() => new Transaction(idResult.Value, amount, currencyCodeResult.Value, dateResult.Value, status));
        }
    }
}