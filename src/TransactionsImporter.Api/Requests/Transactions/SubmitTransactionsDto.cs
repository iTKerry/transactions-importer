using Microsoft.AspNetCore.Http;

namespace TransactionsImporter.Api.Requests.Transactions
{
    public class SubmitTransactionsDto
    {
        public IFormFile File { get; set; }
    }
}