using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class PostCellQuery : IRequest<List<CellDomainModelForPostInput>>
    {
        public int StandId { get; }
        public List<CellDomainModelForPostInput> Cells { get; }

        public PostCellQuery(int standId, List<CellDomainModelForPostInput> cells)
        {
            StandId = standId;
            Cells = cells;
        }
    }
}