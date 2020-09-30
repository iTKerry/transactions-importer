using System;
using TransactionsImporter.DataAccess.Abstractions.Enums;

namespace TransactionsImporter.Api.Requests.Transactions
{
    public class GetTransactionsDto
    {
        public string CurrencyCode { get; set; }
        public TransactionStatus? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}