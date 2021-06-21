using System;

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