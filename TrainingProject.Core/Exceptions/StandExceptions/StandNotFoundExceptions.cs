using System;

namespace TrainingProject.Core.Exceptions.StandExceptons
{
    public class StandNotFoundExceptions : Exception
    {
        public StandNotFoundExceptions(string message = ExceptionMessagesHelper.notFound)
             : base(message)
        {

        }
    }
}
