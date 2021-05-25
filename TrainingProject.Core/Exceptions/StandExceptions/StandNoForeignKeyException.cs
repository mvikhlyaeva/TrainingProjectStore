using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions.StandExceptons
{
    public class StandNoForeignKeyException : Exception
    {
        public StandNoForeignKeyException(string message = ExceptionMessagesHelper.noForeingKey)
             : base(message)
        {

        }
    }
}
