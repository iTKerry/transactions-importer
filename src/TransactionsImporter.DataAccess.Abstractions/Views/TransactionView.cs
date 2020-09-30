using System;
using System.Collections.Generic;
using BetterExtensions.Domain.Base;
using TransactionsImporter.DataAccess.Abstractions.Enums;

namespace TransactionsImporter.DataAccess.Abstractions.Views
{
    public class TransactionView : View
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime Time { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Amount;
            yield return CurrencyCode;
            yield return Status;
        }
    }
}