using System;

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