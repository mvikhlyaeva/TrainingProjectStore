using System;

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