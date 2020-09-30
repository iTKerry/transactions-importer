using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionsImporter.Api.Common;
using TransactionsImporter.Api.Requests.Transactions;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.MediatR.Core.HandlerResults;
using TransactionsImporter.Queries.GetTransactions;

namespace TransactionsImporter.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : ApiController
    {
        public TransactionsController(
            IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork) 
            : base(mapper, mediator, unitOfWork)
        {
        }

        /// <summary>
        /// Get transactions
        /// </summary>
        /// <param name="data">Request params</param>
        /// <returns>Transactions</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Envelope<DataHandlerResult<List<TransactionsDto>>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransactions([FromQuery] GetTransactionsDto data)
        {
            var query = Mapper.Map<GetTransactionsQuery>(data);
            var result = await Mediator.Send(query);
            return FromResult(result);
        }
    }
}