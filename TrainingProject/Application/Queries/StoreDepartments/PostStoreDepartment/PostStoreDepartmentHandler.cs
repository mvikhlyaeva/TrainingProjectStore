using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.PostStoreDepartment
{
    public class PostStoreDepartmentHandler : IRequestHandler<PostStoreDepartmentQuery, StoreDepartmentDomainModel>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PostStoreDepartmentHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StoreDepartmentDomainModel> Handle(PostStoreDepartmentQuery request, CancellationToken cancellationToken)
        {
            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StD.StoreId && sd.DepartmentId == request.StD.DepartmentId);
            if (StoreDepartment == null)
            {
                _context.storeDepartments.Add(_mapper.Map<StoreDepartment>(request.StD));
                await _context.SaveChangesAsync(cancellationToken);
                return request.StD;
            }
            else throw new StoreDepartmentRepeatKeyException();
        }

    }
}
