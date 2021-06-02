using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.GetCell
{
    public class GetCellQuery : IRequest<List<CellDomainModelForPost>>
    {
        public int StandId { get; }

        public GetCellQuery(int standId)
        {
            StandId = standId;
        }
    }
}