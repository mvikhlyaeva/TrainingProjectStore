using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.GetStand
{
    public class GetStandQuery : IRequest<List<StandDomainModelForGet>>
    {
        public int StoreId { get; }
        public int DepartmentId { get; }

        public GetStandQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }
    }
}