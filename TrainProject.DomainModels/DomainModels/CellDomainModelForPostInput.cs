using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Core;

namespace TrainProject.Domain.DomainModels
{
    public class CellDomainModelForPostInput
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Position { get; set; }
        public string Shelf { get; set; }
        public CellType Type { get; set; }
    }
}
