using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Queries.Cells.GetCell;
using TrainingProject.Application.Queries.Cells.PostCell;
using TrainingProject.Application.Queries.Cells.PutCell;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class CellController : Controller
    {
        private readonly IMediator _mediator;

        public CellController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("cells")]
        [ProducesResponseType(typeof(List<CellDomainModelForPost>), StatusCodes.Status200OK)]
        public async Task<List<CellDomainModelForPost>> AddCells(int standId, List<CellDomainModelForPost> cells, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostCellQuery(standId, cells), cancellationToken);
        }

        [HttpPut("cells/{cellId}")]
        [ProducesResponseType(typeof(Cell), StatusCodes.Status200OK)]
        public async Task<Cell> UpdateCells(int cellId, CellDomainModelForPut cell, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PutCellCommandQuery(cellId, cell), cancellationToken);
        }

        [HttpGet("cells")]
        [ProducesResponseType(typeof(List<CellDomainModelForPost>), StatusCodes.Status200OK)]
        public async Task<List<CellDomainModelForPost>> GetCells(int standId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCellQuery(standId), cancellationToken);
        }
    }
}