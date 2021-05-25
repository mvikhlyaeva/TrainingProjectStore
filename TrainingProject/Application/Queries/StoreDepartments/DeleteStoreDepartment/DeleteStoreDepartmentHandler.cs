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
    public class DeleteStoreDepartmentHandler : IRequestHandler<DeleteStoreDepartmentQuery, StoreDepartmentDomainModel>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public DeleteStoreDepartmentHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StoreDepartmentDomainModel> Handle(DeleteStoreDepartmentQuery request, CancellationToken cancellationToken)
        {
            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId);
            if (StoreDepartment == null)
                throw new StoreDepartmentNotFoundException();

            _context.storeDepartments.Remove(StoreDepartment);
            await _context.SaveChangesAsync();
            return _mapper.Map<StoreDepartmentDomainModel>(StoreDepartment);

        }
    }
}
