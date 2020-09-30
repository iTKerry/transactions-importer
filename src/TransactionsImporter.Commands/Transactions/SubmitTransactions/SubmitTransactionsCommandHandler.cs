using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using TransactionsImporter.Commands.Abstractions;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Commands.Transactions.SubmitTransactions
{
    public class SubmitTransactionsCommandHandler 
        : CommandHandlerBase<SubmitTransactionsCommand>
    {
        private readonly string[] _allowedExtensions = {".csv", ".xml"};

        private readonly ITransactionsRepository _repository;

        public SubmitTransactionsCommandHandler(ITransactionsRepository repository) => 
            _repository = repository;

        public override async Task<IHandlerResult> Handle(
            SubmitTransactionsCommand request, 
            CancellationToken ctx)
        {
            var validationResult = ValidateRequest(request);
            if (validationResult.IsFailure)
                return ValidationFailed(validationResult.Error);


            throw new System.NotImplementedException();
        }

        private Result ValidateRequest(SubmitTransactionsCommand request) =>
            request switch
            {
                _ when request.File?.Name is null => 
                    Result.Failure("File input is null."),

                _ when !_allowedExtensions.Contains(Path.GetExtension(request.File.FileName)) => 
                    Result.Failure($"Invalid file type: {Path.GetExtension(request.File.FileName)}. Should be csv or xml."),

                _ => Result.Success()
            };
    }
}