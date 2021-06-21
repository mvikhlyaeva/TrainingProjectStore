using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.PostStoreDepartment
{
    public class AddStoreDepartmentCommandQuery : IRequest<StoreDepartmentDomainModel>
    {
        public StoreDepartmentDomainModel StD { get; }

        public AddStoreDepartmentCommandQuery(StoreDepartmentDomainModel SD)
        {
            StD = SD;
        }
    }
}