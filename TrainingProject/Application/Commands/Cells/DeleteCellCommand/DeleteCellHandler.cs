using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.CellException;
using TrainingProject.tables;

namespace TrainingProject.Application.Commands.Cells.DeleteCellCommand
{
    public class DeleteCellHandler : IRequestHandler<DeleteCellQuery, Cell>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public DeleteCellHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cell> Handle(DeleteCellQuery request, CancellationToken cancellationToken)
        {
            var cell = await _context.cells
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);

            if (cell == null)
                throw new CellNotFoundException();

            _context.cells.Remove(cell);
            await _context.SaveChangesAsync(cancellationToken);
            return cell;
        }
    }
}