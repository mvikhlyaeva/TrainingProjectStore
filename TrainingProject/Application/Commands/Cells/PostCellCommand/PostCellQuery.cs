using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class PostCellQuery : IRequest<List<CellDomainModelForPost>>
    {
        public int StandId { get; }
        public List<CellDomainModelForPost> Cells { get; }

        public PostCellQuery(int standId, List<CellDomainModelForPost> cells)
        {
            StandId = standId;
            Cells = cells;
        }
    }
}