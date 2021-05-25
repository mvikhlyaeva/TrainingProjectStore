using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class PostCellQuery : IRequest<List<CellDomainModelForPostInput>>
    {
        public int StandId;
        public List<CellDomainModelForPostInput> Cells;
        public PostCellQuery(int standId, List<CellDomainModelForPostInput> cells)
        {
            StandId = standId;
            Cells = cells;
        }
    }
}
