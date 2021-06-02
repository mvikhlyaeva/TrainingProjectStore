using System;

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