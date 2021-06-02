using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.StandExceptons;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.GetStand
{
    public class GetStandHandler : IRequestHandler<GetStandQuery, List<StandDomainModelForGet>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetStandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StandDomainModelForGet>> Handle(GetStandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);
            if (storeDepartment == null)
                throw new StandNoForeignKeyException();

            var stands = await _context.stands
                .Where(st => st.StoreId == request.StoreId && st.DepartmentId == request.DepartmentId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<StandDomainModelForGet>>(stands);
        }
    }
}