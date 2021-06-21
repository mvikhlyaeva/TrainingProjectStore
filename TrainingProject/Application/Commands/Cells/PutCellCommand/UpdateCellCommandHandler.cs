using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.CellException;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.Cells.PutCell
{
    public class UpdateCellCommandHandler : IRequestHandler<UpdateCellCommandQuery, Cell>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UpdateCellCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cell> Handle(UpdateCellCommandQuery request, CancellationToken cancellationToken)
        {
            var celldb = await _context.cells.Select(cell => new
            {
                Id = cell.Id,
                StandId = cell.StandId
            }).FirstOrDefaultAsync(cells => cells.Id == request.CellId, cancellationToken);
            if (celldb == null)
                throw new CellNotFoundException();

            var cellForUpdate = _mapper.Map<Cell>(request.Cell);
            cellForUpdate.Id = request.CellId;
            cellForUpdate.StandId = celldb.StandId;
            _context.cells.Update(cellForUpdate);
            await _context.SaveChangesAsync(cancellationToken);
            return cellForUpdate;
        }
    }
}