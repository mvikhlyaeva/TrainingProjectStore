using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class Product
    {
        public int Id { get; set; }

        public int Cellid { get; set; }
        public Cell Cell { get; set; }

        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
