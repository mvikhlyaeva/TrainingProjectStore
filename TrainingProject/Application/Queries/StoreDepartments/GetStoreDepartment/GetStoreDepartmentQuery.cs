using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.GetStoreDepartment
{
    public class GetStoreDepartmentQuery : IRequest<StoreDepartmentDomainModel>
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }

        public GetStoreDepartmentQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }
    }
}
