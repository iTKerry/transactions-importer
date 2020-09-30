using System;
using System.Collections.Generic;
using TransactionsImporter.DataAccess.Abstractions.Enums;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Queries.GetTransactions
{
    public class GetTransactionsQuery : IQuery<List<TransactionsDto>>
    {
        public string CurrencyCode { get; set; }
        public TransactionStatus? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}