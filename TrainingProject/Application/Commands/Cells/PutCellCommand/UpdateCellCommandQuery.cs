using MediatR;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PutCell
{
    public class UpdateCellCommandQuery : IRequest<Cell>
    {
        public int CellId { get; }
        public CellDomainModelForPut Cell { get; }

        public UpdateCellCommandQuery(int cellId, CellDomainModelForPut cell)
        {
            CellId = cellId;
            Cell = cell;
        }
    }
}