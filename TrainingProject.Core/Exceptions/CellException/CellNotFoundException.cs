using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions.CellException
{
    public class CellNotFoundException : Exception
    {
        public CellNotFoundException(string message = ExceptionMessagesHelper.notFound)
             : base(message)
        {

        }
    }
}
