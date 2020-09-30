using System;
using CSharpFunctionalExtensions;

namespace TransactionsImporter.DataAccess.Abstractions.ValueObjects
{
    public class CurrencyCode : ValueObject<CurrencyCode>
    {
        private CurrencyCode(string value) => 
            Value = value;

        public string Value { get; }

        public static Result<CurrencyCode> Create(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Result.Failure<CurrencyCode>($"CurrencyCode invalid parameter: {code}");
            
            // TODO: Implement validation rules here
            throw new NotImplementedException();

            return Result.Success(new CurrencyCode(code));
        }
        
        protected override bool EqualsCore(CurrencyCode other) => 
            Value == other.Value;

        protected override int GetHashCodeCore() => 
            Value.GetHashCode();
    }
}