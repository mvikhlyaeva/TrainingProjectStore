namespace TrainingProject.Domain
{
    public class StandDomainModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public int Position { get; set; }
        public int Side { get; set; }
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
    }
}