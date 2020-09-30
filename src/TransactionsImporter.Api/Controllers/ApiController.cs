using System;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionsImporter.Api.Common;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.MediatR.Core.Abstractions;
using TransactionsImporter.MediatR.Core.HandlerResults;

namespace TransactionsImporter.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class ApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected IMapper Mapper { get; }
        protected IMediator Mediator { get; }

        protected ApiController(IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork) =>
            (Mapper, Mediator, _unitOfWork) =
            (mapper, mediator, unitOfWork);

        protected async Task<IActionResult> FromResult<T>(IHandlerResult<T> result) where T : class
        {
            switch (result)
            {
                case PagedDataHandlerResult<T> dhr:
                    await _unitOfWork.CommitAsync();
                    return Ok(Envelope.Ok(dhr.Data));

                case ValidationFailedHandlerResult<T> vhr:
                    await _unitOfWork.RollbackAsync();
                    return BadRequest(Envelope.Error(vhr.Message));

                default:
                    return NotFound(Envelope.Error("Not found"));
            }
        }

        protected IActionResult FromResult(IHandlerResult result) =>
            result switch
            {
                OkHandlerResult _ => Ok(Envelope.Ok()),
                ValidationFailedHandlerResult vhr => BadRequest(Envelope.Error(vhr.Message)),
                _ => NotFound(Envelope.Error("Not found"))
            };
    }
}
