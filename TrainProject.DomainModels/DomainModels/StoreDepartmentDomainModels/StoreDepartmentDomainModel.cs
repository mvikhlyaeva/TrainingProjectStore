using TrainingProject.Core;

namespace TrainingProject.Domain
{
    public class StoreDepartmentDomainModel
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }
    }
}