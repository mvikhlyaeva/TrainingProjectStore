using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions.StandExceptions
{
    public class StandIncorrectSideException : Exception
    {
        public StandIncorrectSideException(string message = ExceptionMessagesHelper.incorrectSide)
             : base(message)
        {
        }
    }
}