using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.Domain.DomainModels
{
    public class StandDomainModelForPost
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public int Position { get; set; }
        public int Side { get; set; }
    }
}
