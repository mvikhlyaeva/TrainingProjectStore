using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment;
using TrainingProject.Application.Queries.StoreDepartments.GetStoreDepartment;
using TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment;
using TrainingProject.Application.Queries.StoreDepartments.PostStoreDepartment;
using TrainingProject.Core;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class StoreDepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public StoreDepartmentController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<StoreDepartmentDomainModel>), StatusCodes.Status200OK)]
        public async Task<List<StoreDepartmentDomainModel>> GetAllStoreDepartments()
        {
            var storeDepartments = await _context.storeDepartments.OrderBy(sd => sd.StoreId).ThenBy(sd => sd.DepartmentId).ToListAsync();
            return _mapper.Map<List<StoreDepartmentDomainModel>>(storeDepartments);
        }

        [HttpPost("storeDepartments")]
        [ProducesResponseType(typeof(StoreDepartmentDomainModel), StatusCodes.Status200OK)]
        public async Task<StoreDepartmentDomainModel> AddStoreDepartments([FromBody] StoreDepartmentDomainModel SD, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostStoreDepartmentCommandQuery(SD), cancellationToken);
        }

        [HttpPatch("store/{storeId}/department/{departmentId}")]
        [ProducesResponseType(typeof(SchemeType), StatusCodes.Status200OK)]
        public async Task<SchemeType> ChangeStoreDepartments(int storeId, int departmentId, [FromBody] SchemeType scheme, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PatchStoreDepartmentCommandQuery(storeId, departmentId, scheme), cancellationToken);
        }

        [HttpGet("store/{storeId}/department/{departmentId}")]
        [ProducesResponseType(typeof(StoreDepartmentDomainModel), StatusCodes.Status200OK)]
        public async Task<StoreDepartmentDomainModel> GetStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStoreDepartmentQuery(storeId, departmentId), cancellationToken);
        }

        [HttpDelete("store/{storeId}/department/{departmentId}")]
        [ProducesResponseType(typeof(StoreDepartmentDomainModel), StatusCodes.Status200OK)]
        public async Task<StoreDepartment> DeleteStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteStoreDepartmentCommandQuery(storeId, departmentId), cancellationToken);
        }
    }
}