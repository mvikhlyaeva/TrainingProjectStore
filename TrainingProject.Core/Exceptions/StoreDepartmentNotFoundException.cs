using System;

namespace TrainingProject.Core
{
    public class StoreDepartmentNotFoundException : Exception
    {
        public StoreDepartmentNotFoundException(string message = ExceptionMessagesHelper.notFound)
             : base(message)
        {
        }
    }
}