using MediatR;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.PostStoreDepartment
{
    public class PostStoreDepartmentQuery: IRequest<StoreDepartmentDomainModel>
    {

        public StoreDepartmentDomainModel StD { get; set; }
        public PostStoreDepartmentQuery(StoreDepartmentDomainModel SD)
        {
            StD = SD;
        }

    }
}
