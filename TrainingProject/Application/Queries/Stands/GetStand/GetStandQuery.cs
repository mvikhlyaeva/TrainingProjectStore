using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.GetStand
{
    public class GetStandQuery : IRequest<List<StandDomainModelForGet>>
    {
        public int StoreId;
        public int DepartmentId;

        public GetStandQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }

    }
}
