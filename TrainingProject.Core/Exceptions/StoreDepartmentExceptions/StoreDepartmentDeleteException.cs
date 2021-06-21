using System;

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