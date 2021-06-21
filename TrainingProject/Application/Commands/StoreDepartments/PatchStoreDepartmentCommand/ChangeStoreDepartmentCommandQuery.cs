using MediatR;
using TrainingProject.Core.Enums;

namespace TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment
{
    public class ChangeStoreDepartmentCommandQuery : IRequest<SchemeType>
    {
        public int StoreId { get; }
        public int DepartmentId { get; }
        public SchemeType Scheme { get; }

        public ChangeStoreDepartmentCommandQuery(int storeId, int departmentId, SchemeType scheme)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
            Scheme = scheme;
        }
    }
}