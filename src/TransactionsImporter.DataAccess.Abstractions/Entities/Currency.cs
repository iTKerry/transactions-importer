using System.Linq;
using BetterExtensions.Domain.Base;
using CSharpFunctionalExtensions;

namespace TransactionsImporter.DataAccess.Abstractions.Entities
{
    public class Currency : Entity
    {
        public static readonly Currency USD = Create(840, "USD");
        public static readonly Currency EUR = Create(978, "EUR");

        public static readonly Currency[] AllCurrencies =
        {
            USD, EUR
        };

        protected Currency()
        {
        }

        private Currency(int id, string code)
            : base(id) =>
            Code = code;

        public string Code { get; }

        private static Currency Create(int id, string name) =>
            new Currency(id, name);

        public static Result<Currency> FromCode(string code) =>
            AllCurrencies.SingleOrDefault(c => c.Code == code)
            ?? Result.Failure<Currency>($"There is no such currency for code: {code}");
    }
}