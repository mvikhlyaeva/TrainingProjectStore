using System;

namespace TrainingProject.tables
{
    public class Product
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }

        public int CellId { get; set; }
        public Cell Cell { get; set; }

        public string ProductCode { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}