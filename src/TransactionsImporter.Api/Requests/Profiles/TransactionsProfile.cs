using AutoMapper;
using TransactionsImporter.Api.Requests.Transactions;
using TransactionsImporter.Queries.GetTransactions;

namespace TransactionsImporter.Api.Requests.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<GetTransactionsDto, GetTransactionsQuery>();
        }
    }
}