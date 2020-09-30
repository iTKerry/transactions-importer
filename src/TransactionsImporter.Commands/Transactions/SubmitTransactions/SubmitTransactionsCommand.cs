using Microsoft.AspNetCore.Http;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Commands.Transactions.SubmitTransactions
{
    public class SubmitTransactionsCommand : ICommand
    {
        public IFormFile File { get; set; }
    }
}