using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PutCell
{
    public class PutCellQuery : IRequest<Cell>
    {
        public int CellId;
        public CellDomainModelForPut Cell;

        public PutCellQuery(int cellId, CellDomainModelForPut cell)
        {
            CellId = cellId;
            Cell = cell;
        }
    }
}
