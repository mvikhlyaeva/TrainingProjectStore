using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.CellException;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.GetCell
{
    public class GetCellHandler : IRequestHandler<GetCellQuery, List<CellDomainModelForPost>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetCellHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CellDomainModelForPost>> Handle(GetCellQuery request, CancellationToken cancellationToken)
        {
            var stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == request.StandId, cancellationToken);
            if (stand == null)
                throw new CellNoForeignKeyException();

            var cells = await _context.cells.Where(cell => cell.StandId == request.StandId).ToListAsync(cancellationToken);
            return _mapper.Map<List<CellDomainModelForPost>>(cells);
        }
    }
}