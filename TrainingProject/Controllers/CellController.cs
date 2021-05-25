using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CellController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("cells")]
        [ProducesResponseType(typeof(List<CellDomainModelForPostInput>), StatusCodes.Status200OK)]
        public async Task<List<CellDomainModelForPostInput>> AddCells(int standId, List<CellDomainModelForPostInput> cells, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostCellQuery(standId, cells), cancellationToken);
        }


        [HttpPut("cells/{cellId}")]
        [ProducesResponseType(typeof(List<CellDomainModelForPostInput>), StatusCodes.Status200OK)]
        public async Task<Cell> UpdateCells(int cellId, CellDomainModelForPut cell, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PutCellQuery(cellId, cell), cancellationToken);
        }

    }
}
