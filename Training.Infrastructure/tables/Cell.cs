using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Core;

namespace TrainingProject.tables
{
    public class Cell
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Position { get; set; }
        public string Shelf { get; set; }
        public CellType Type { get; set; }

        public int StandId { get; set; }
        public Stand Stand { get; set; }

        public List<Product> Products { get; set; }
    }
}