using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Core.Exceptions.StoreDepartmentExceptions
{
    public class StoreDepartmentDeleteException : Exception
    {
        public StoreDepartmentDeleteException(string message = ExceptionMessagesHelper.deleteSD)
             : base(message)
        {
        }
    }
}