using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.PostStand
{
    public class PostStandQuery : IRequest<List<StandDomainModelForPost>>
    {
        public int StoreId;
        public int DepartmentId;
        public List<StandDomainModelForPost> Stands;

        public PostStandQuery(int storeId, int departmentId, List<StandDomainModelForPost> stands)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
            Stands = stands;
        }
    }

}
