using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment
{
    public class DeleteStoreDepartmentCommandHandler : IRequestHandler<DeleteStoreDepartmentCommandQuery, StoreDepartmentDomainModel>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public DeleteStoreDepartmentCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreDepartmentDomainModel> Handle(DeleteStoreDepartmentCommandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);
            if (storeDepartment == null)
                throw new StoreDepartmentNotFoundException();

            _context.storeDepartments.Remove(storeDepartment);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<StoreDepartmentDomainModel>(storeDepartment);
        }
    }
}