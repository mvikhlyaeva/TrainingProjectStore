using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.PostStoreDepartment
{
    public class PostStoreDepartmentCommandQuery : IRequest<StoreDepartmentDomainModel>
    {
        public StoreDepartmentDomainModel StD { get; }

        public PostStoreDepartmentCommandQuery(StoreDepartmentDomainModel SD)
        {
            StD = SD;
        }
    }
}