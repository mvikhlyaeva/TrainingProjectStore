using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment
{
    public class PatchStoreDepartmentHandler : IRequestHandler<PatchStoreDepartmentQuery, SchemeType>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PatchStoreDepartmentHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SchemeType> Handle(PatchStoreDepartmentQuery request, CancellationToken cancellationToken)
        {
            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId);
            if (StoreDepartment == null)
                throw new StoreDepartmentNotFoundException();

            StoreDepartment.Scheme = request.Scheme;
            await _context.SaveChangesAsync();
            return StoreDepartment.Scheme;


        }

    }
}
