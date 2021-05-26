using System;

namespace TrainingProject.Core.Exceptions.StandExceptons
{
    public class StandNotFoundException : Exception
    {
        public StandNotFoundException(string message = ExceptionMessagesHelper.notFound)
             : base(message)
        {

        }
    }
}
