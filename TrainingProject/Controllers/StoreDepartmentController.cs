using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
//qq
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class StoreDepartmentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StoreDepartmentController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("StoreDeparments")]
        public async Task<StoreDepartmentDomainModel> AddStoreDepartments([FromBody] StoreDepartmentDomainModel SD, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostStoreDepartmentQuery(SD), cancellationToken);
        }

        [HttpPatch("store/{storeId}/department/{departmentId}")]
        public async Task<SchemeType> ChangeStoreDepartments(int storeId, int departmentId, SchemeType scheme, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PatchStoreDepartmentQuery(storeId, departmentId, scheme), cancellationToken);
        }


        [HttpGet("store/{storeId}/department/{departmentId}")]
        public async Task<StoreDepartmentDomainModel> GetStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStoreDepartmentQuery(storeId, departmentId), cancellationToken);
        }

        [HttpDelete("store/{storeId}/department/{departmentId}")]
        public async Task<StoreDepartmentDomainModel> DeleteStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteStoreDepartmentQuery(storeId, departmentId), cancellationToken);
        }

    }
}
