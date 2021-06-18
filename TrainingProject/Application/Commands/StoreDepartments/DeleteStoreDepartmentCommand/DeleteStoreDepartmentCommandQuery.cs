using MediatR;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment
{
    public class DeleteStoreDepartmentCommandQuery : IRequest<StoreDepartment>
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