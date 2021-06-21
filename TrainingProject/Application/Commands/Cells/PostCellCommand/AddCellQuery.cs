using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class AddCellQuery : IRequest<List<CellDomainModelForPost>>
    {
        public int StandId { get; }
        public List<CellDomainModelForPost> Cells { get; }

        public AddCellQuery(int standId, List<CellDomainModelForPost> cells)
        {
            StandId = standId;
            Cells = cells;
        }
    }
}