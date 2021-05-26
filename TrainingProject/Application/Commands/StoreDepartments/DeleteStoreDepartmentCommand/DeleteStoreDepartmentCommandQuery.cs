using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment
{
    public class DeleteStoreDepartmentCommandQuery : IRequest<StoreDepartmentDomainModel>
    {
        public int StoreId { get; }
        public int DepartmentId { get; }

        public DeleteStoreDepartmentCommandQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }
    }
}