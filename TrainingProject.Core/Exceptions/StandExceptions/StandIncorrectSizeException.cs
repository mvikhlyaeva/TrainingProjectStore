using System;

namespace TrainingProject.Core.Exceptions.StandExceptions
{
    public class StandIncorrectSizeException : Exception
    {
        public StandIncorrectSizeException(string message = ExceptionMessagesHelper.incorrectSize)
             : base(message)
        {
        }
    }
}