using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions
{
    public class StoreDepartmentRepeatKeyException : Exception
    {

        public StoreDepartmentRepeatKeyException(string message = ExceptionMessagesHelper.repeatKey)
             : base(message)
        {

        }
    }
}
