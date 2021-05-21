using System.Collections.Generic;
using TrainingProject.Core;

namespace TrainingProject.tables
{
    public class StoreDepartment
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }

        public List<Stand> Stands { get; set; }
    }
}
