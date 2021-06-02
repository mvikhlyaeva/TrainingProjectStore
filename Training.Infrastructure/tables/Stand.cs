using System.Collections.Generic;

namespace TrainingProject.tables
{
    public class Stand
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public int Position { get; set; }
        public int Side { get; set; }
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }

        public StoreDepartment StoreDepartment { get; set; }

        public List<Cell> Cells { get; set; }
    }
}