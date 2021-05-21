using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment
{
    public class DeleteStoreDepartmentQuery : IRequest<StoreDepartmentDomainModel>
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }

        public DeleteStoreDepartmentQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }
    }
}
