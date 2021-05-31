using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.Domain.DomainModels.ProductDomainModel
{
    public class ProductDomainModelForGet
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }

        public string ProductCode { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}