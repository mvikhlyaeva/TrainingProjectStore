using System;

namespace TrainingProject.Core.Exceptions.StandExceptons
{
    public class StandNoForeignKeyException : Exception
    {
        public StandNoForeignKeyException(string message = ExceptionMessagesHelper.noForeingKey)
             : base(message)
        {
        }
    }
}