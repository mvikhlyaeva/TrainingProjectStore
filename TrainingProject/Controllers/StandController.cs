using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Queries.Stands.GetStand;
using TrainingProject.Application.Queries.Stands.PostStand;
using TrainingProject.Domain;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class StandController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StandController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("Stand")]
        [ProducesResponseType(typeof(StandDomainModelForGet), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStand([FromBody] StandDomainModelForGet Stand, CancellationToken cancellationToken)
        {

            _context.stands.Add(_mapper.Map<Stand>(Stand));
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(Stand);
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

            return await _mediator.Send(new PostStandQuery(storeId, departmentId, stands), cancellationToken);
        }


    }
}
