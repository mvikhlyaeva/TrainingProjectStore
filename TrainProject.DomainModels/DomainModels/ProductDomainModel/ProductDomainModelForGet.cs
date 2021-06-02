using System;

namespace TrainProject.Domain.DomainModels.ProductDomainModel
{
    public class ProductDomainModelForGet
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}