using MediatR;
using TrainingProject.tables;

namespace TrainingProject.Application.Commands.Cells.DeleteCellCommand
{
    public class DeleteCellQuery : IRequest<Cell>
    {
        public int CellId { get; }

        public DeleteCellQuery(int cellId)
        {
            CellId = cellId;
        }
    }
}