using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core
{
    public class StoreDepartmentNotFoundException : Exception
    {
        public StoreDepartmentNotFoundException(string message = "Not found")
             : base(message)
        {

        }
    }
}
