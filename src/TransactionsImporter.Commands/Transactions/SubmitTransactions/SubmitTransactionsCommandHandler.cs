using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Commands.Abstractions;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.Domain.Abstractions;
using TransactionsImporter.MediatR.Core.Abstractions;

namespace TransactionsImporter.Commands.Transactions.SubmitTransactions
{
    public class SubmitTransactionsCommandHandler 
        : CommandHandlerBase<SubmitTransactionsCommand>
    {
        private readonly string[] _allowedExtensions = {".csv", ".xml"};

        private readonly ITransactionsRepository _repository;
        private readonly ITransactionsReader _reader;
        private readonly ITransactionsMapper _mapper;

        public SubmitTransactionsCommandHandler(
            ITransactionsRepository repository, 
            ITransactionsReader reader, 
            ITransactionsMapper mapper)
        {
            _repository = repository;
            _reader = reader;
            _mapper = mapper;
        }

        public override async Task<IHandlerResult> Handle(
            SubmitTransactionsCommand request, 
            CancellationToken ctx)
        {
            var validationResult = ValidateRequest(request);
            if (validationResult.IsFailure)
                return ValidationFailed(validationResult.Error);

            var fileTransactions = _reader.Read(request.File);
            var transactionsResult = _mapper.Map(fileTransactions);

            if (transactionsResult.IsFailure)
                return ValidationFailed(transactionsResult.Error);

            _repository.SaveRange(transactionsResult.Value);

            return await Task.FromResult(Ok());
        }

        private Result ValidateRequest(SubmitTransactionsCommand request) =>
            request switch
            {
                _ when request.File?.Name is null => 
                    Result.Failure("File input is null."),

                _ when request.File?.Length <= 0 =>
                    Result.Failure("Invalid file size."),

                _ when !_allowedExtensions.Contains(Path.GetExtension(request.File.FileName)) => 
                    Result.Failure($"Unknown format: {Path.GetExtension(request.File.FileName)}. Should be csv or xml."),

                _ => Result.Success()
            };
    }
}