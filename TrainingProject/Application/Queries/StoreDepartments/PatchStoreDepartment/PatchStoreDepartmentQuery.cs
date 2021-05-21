using MediatR;
using TrainingProject.Core;

namespace TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment
{
    public class PatchStoreDepartmentQuery : IRequest<SchemeType>
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }

        public PatchStoreDepartmentQuery(int storeId, int departmentId, SchemeType scheme)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
            Scheme = scheme;
        }
    }
}
