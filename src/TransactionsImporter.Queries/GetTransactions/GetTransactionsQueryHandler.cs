using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BetterExtensions.Domain.Common;
using BetterExtensions.Domain.Repository;
using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.Abstractions.Views;
using TransactionsImporter.MediatR.Core.Abstractions;
using TransactionsImporter.Queries.Abstractions;

namespace TransactionsImporter.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : QueryHandlerBase<GetTransactionsQuery, List<TransactionsDto>>
    {
        private readonly IReadRepository<TransactionView> _repository;

        public GetTransactionsQueryHandler(IReadRepository<TransactionView> repository) => 
            _repository = repository;

        public override async Task<IHandlerResult<List<TransactionsDto>>> Handle(
            GetTransactionsQuery request, 
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.CurrencyCode) && Currency.FromCode(request.CurrencyCode).IsFailure)
                return ValidationFailed($"Invalid currency code: {request.CurrencyCode}");

            Expression<Func<TransactionView, bool>> wherePredicate = view => 
                (string.IsNullOrEmpty(request.CurrencyCode) || view.CurrencyCode == request.CurrencyCode) &&
                (request.Status == null || view.Status == request.Status) &&
                (request.DateFrom == null || request.DateFrom <= view.Time) &&
                (request.DateTo == null || request.DateTo >= view.Time);

            var queryParams = new QueryParams<TransactionView>
            {
                WherePredicate = wherePredicate
            };

            var data = await _repository.GetAllAsync(queryParams, cancellationToken);
            var count = await _repository.CountAsync(wherePredicate, cancellationToken);
            var result = data.Select(MappingProjection).ToList();

            return PagedData(result, count);
        }

        private static TransactionsDto MappingProjection(TransactionView view) => 
            new TransactionsDto
            {
                Id = view.Id, 
                Payment = $"{view.Amount} {view.CurrencyCode}", 
                Status = view.Status.ToString()
            };
    }
}