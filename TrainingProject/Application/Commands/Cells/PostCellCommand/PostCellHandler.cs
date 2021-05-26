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

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class PostCellHandler : IRequestHandler<PostCellQuery, List<CellDomainModelForPostInput>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PostCellHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CellDomainModelForPostInput>> Handle(PostCellQuery request, CancellationToken cancellationToken)
        {
            var Stand = await _context.stands.FirstOrDefaultAsync(sd => sd.Id == request.StandId, cancellationToken);
            if (Stand == null)
                throw new CellNoForeignKeyException();
            var cellsdb = await _context.cells.Where(u => u.StandId == request.StandId).OrderBy(u => u.Id).ToListAsync(cancellationToken);
            foreach (CellDomainModelForPostInput cell in request.Cells)
            {
                if (cellsdb.FirstOrDefault(u => u.Id == cell.Id) != null)
                    throw new CellRepeatKeyException();
                Cell cellAdd = _mapper.Map<Cell>(cell);
                cellAdd.StandId = request.StandId;
                _context.cells.Add(cellAdd);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return request.Cells;
        }
    }
}
