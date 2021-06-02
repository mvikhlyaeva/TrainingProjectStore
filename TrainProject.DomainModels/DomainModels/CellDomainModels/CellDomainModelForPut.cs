using TrainingProject.Core;

namespace TrainProject.Domain.DomainModels
{
    public class CellDomainModelForPut
    {
        public string Code { get; set; }
        public int Position { get; set; }
        public string Shelf { get; set; }
        public CellType Type { get; set; }
    }
}