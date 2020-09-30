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

        protected IActionResult FromResult<T>(IHandlerResult<T> result) where T : class =>
            result switch
            {
                DataHandlerResult<T> d => (IActionResult)Ok(Envelope.Ok(d.Data)),
                PagedDataHandlerResult<T> pd => (IActionResult) Ok(Envelope.Ok(pd.Data)),
                ValidationFailedHandlerResult<T> vf => BadRequest(Envelope.Error(vf.Message)),
                _ => NotFound(Envelope.Error("Not found"))
            };

        protected async Task<IActionResult> FromResult(IHandlerResult result)
        {
            switch (result)
            {
                case OkHandlerResult _:
                    await _unitOfWork.CommitAsync();
                    return Ok(Envelope.Ok());
                
                case ValidationFailedHandlerResult vf:
                    await _unitOfWork.RollbackAsync();
                    return BadRequest(Envelope.Error(vf.Message));
                
                default:
                    await _unitOfWork.RollbackAsync();
                    return NotFound(Envelope.Error("Not found"));
            }
        }
    }
}
