using System;
using System.Globalization;
using CSharpFunctionalExtensions;

namespace TransactionsImporter.DataAccess.Abstractions.ValueObjects
{
    public class TransactionDate : ValueObject<TransactionDate>
    {
        protected TransactionDate()
        {
        }

        private TransactionDate(DateTime value) => 
            Value = value;

        public DateTime Value { get; }

        public static Result<TransactionDate> Create(string date) =>
            date switch
            {
                _ when string.IsNullOrWhiteSpace(date) =>
                    Result.Failure<TransactionDate>($"TransactionDate failed with invalid input parameter: {date}"),
                
                _ when TryParseDate(date, "dd/MM/yyyy hh:mm:ss", out var result) => 
                    Result.Success(new TransactionDate(result)),
                
                _ when TryParseDate(date, "yyyy-MM-dd'T'hh:mm:ss", out var result) => 
                    Result.Success(new TransactionDate(result)),
                
                _ => Result.Failure<TransactionDate>($"Invalid transaction date format: {date}") 
            };

        private static bool TryParseDate(string date, string format, out DateTime result) =>
            DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

        protected override bool EqualsCore(TransactionDate other) => 
            Value == other.Value;

        protected override int GetHashCodeCore() => 
            Value.GetHashCode();
    }
}