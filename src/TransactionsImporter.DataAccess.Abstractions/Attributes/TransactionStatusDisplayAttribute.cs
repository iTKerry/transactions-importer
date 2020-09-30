using System;

namespace TransactionsImporter.DataAccess.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=true)]
    public class TransactionStatusDisplayAttribute : Attribute
    {
        public TransactionStatusDisplayAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}