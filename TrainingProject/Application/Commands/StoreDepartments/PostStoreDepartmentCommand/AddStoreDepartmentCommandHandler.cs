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
    public class AddStoreDepartmentCommandHandler : IRequestHandler<AddStoreDepartmentCommandQuery, StoreDepartmentDomainModel>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AddStoreDepartmentCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreDepartmentDomainModel> Handle(AddStoreDepartmentCommandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == request.StD.StoreId && sd.DepartmentId == request.StD.DepartmentId, cancellationToken);
            if (storeDepartment != null)
                throw new StoreDepartmentRepeatKeyException();

            _context.storeDepartments.Add(_mapper.Map<StoreDepartment>(request.StD));
            await _context.SaveChangesAsync(cancellationToken);
            return request.StD;
        }
    }
}