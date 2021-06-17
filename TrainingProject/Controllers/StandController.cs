using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Queries.Stands.GetStand;
using TrainingProject.Application.Queries.Stands.PostStand;
using TrainingProject.Domain;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class StandController : Controller
    {
        private readonly IMediator _mediator;

        public StandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("stands")]
        [ProducesResponseType(typeof(StandDomainModelForGet), StatusCodes.Status200OK)]
        public async Task<List<StandDomainModelForGet>> GetStands([FromQuery] int storeId, [FromQuery] int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStandQuery(storeId, departmentId), cancellationToken);
        }

        [HttpPost("stands")]
        [ProducesResponseType(typeof(StandDomainModel), StatusCodes.Status200OK)]
        public async Task<List<StandDomainModelForPost>> AddUpDelStands([FromQuery] int storeId, int departmentId, List<StandDomainModelForPost> stands, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostStandCommandQuery(storeId, departmentId, stands), cancellationToken);
        }
    }
}