using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.PostStand
{
    public class PostStandCommandQuery : IRequest<List<StandDomainModelForPost>>
    {
        public int StoreId { get; }
        public int DepartmentId { get; }
        public List<StandDomainModelForPost> Stands { get; }

        public PostStandCommandQuery(int storeId, int departmentId, List<StandDomainModelForPost> stands)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
            Stands = stands;
        }
    }
}