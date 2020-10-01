using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CSharpFunctionalExtensions;
using TransactionsImporter.Application.Readers;
using TransactionsImporter.Common.Extensions;
using TransactionsImporter.DataAccess.Abstractions.Attributes;
using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.Abstractions.Enums;
using TransactionsImporter.DataAccess.Abstractions.ValueObjects;
using TransactionsImporter.Domain.Abstractions;

namespace TransactionsImporter.Domain
{
    public class TransactionsMapper : ITransactionsMapper
    {
        public Result<List<Transaction>> Map(List<FileTransactionDto> data)
        {
            var results = data.Select(Projection).ToList();
            return Result.Combine(results)
                .Map(() => results.Select(r => r.Value).ToList());
        }

        private static Result<Transaction> Projection(FileTransactionDto dto)
        {
            var transactionIdResult = TryResolveTransactionId(dto.TransactionId);
            var amountResult = TryResolveAmount(dto.Amount);
            var currencyResult = TryResolveCurrency(dto.CurrencyCode);
            var transactionDateResult = TryResolveTransactionDate(dto.TransactionDate);
            var statusResult = TryResolveStatus(dto.Status);

            return Result.Combine(
                    transactionIdResult,
                    amountResult,
                    currencyResult,
                    transactionDateResult,
                    statusResult)
                .Bind(() => Transaction.Create(
                    transactionIdResult.Value,
                    amountResult.Value,
                    currencyResult.Value,
                    transactionDateResult.Value,
                    statusResult.Value
                ));
        }

        private static Result<TransactionId> TryResolveTransactionId(string id) => 
            TransactionId.Create(id);

        private static Result<decimal> TryResolveAmount(string amount) =>
            decimal.TryParse(amount, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var result) 
                ? result
                : Result.Failure<decimal>($"Invalid transaction amount: {amount}");

        private static Result<Currency> TryResolveCurrency(string currencyCode) => 
            Currency.FromCode(currencyCode);

        private static Result<TransactionDate> TryResolveTransactionDate(string date) => 
            TransactionDate.Create(date);

        private static Result<TransactionStatus> TryResolveStatus(string status)
        {
            var result = Enum.GetValues(typeof(TransactionStatus))
                .Cast<TransactionStatus>()
                .Select(transactionStatus => new
                {
                    Status= transactionStatus, 
                    Attributes= transactionStatus.SelectAttributes<TransactionStatusDisplayAttribute>()
                })
                .FirstOrDefault(s => s.Attributes?.Any(attr => attr.Value == status) ?? false);

            return result?.Status ?? Result.Failure<TransactionStatus>($"Not supported status parameter: {status}");
        }
    }
}
