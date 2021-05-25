using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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
            var stands = await _context.stands.ToListAsync(cancellationToken);
            var resStands = stands.Where(st => st.StoreId == request.StoreId && st.DepartmentId == request.DepartmentId);
            if (resStands == null)
                throw new StandNotFoundExceptions();

            return _mapper.Map<List<StandDomainModelForGet>>(resStands);

        }
    }
}
