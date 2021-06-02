using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment
{
    public class PatchStoreDepartmentCommandHandler : IRequestHandler<PatchStoreDepartmentCommandQuery, SchemeType>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PatchStoreDepartmentCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SchemeType> Handle(PatchStoreDepartmentCommandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);
            if (storeDepartment == null)
                throw new StoreDepartmentNotFoundException();

            storeDepartment.Scheme = request.Scheme;
            await _context.SaveChangesAsync(cancellationToken);
            return storeDepartment.Scheme;
        }
    }
}