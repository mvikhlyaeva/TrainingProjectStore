using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions.CellException
{
    public class CellRepeatKeyException : Exception
    {
        public CellRepeatKeyException(string message = ExceptionMessagesHelper.repeatKey)
             : base(message)
        {

        }
    }
}
