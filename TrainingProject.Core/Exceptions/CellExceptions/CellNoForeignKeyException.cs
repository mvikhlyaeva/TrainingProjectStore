using System;

namespace TrainingProject.Core.Exceptions.CellException
{
    public class CellNoForeignKeyException : Exception
    {
        public CellNoForeignKeyException(string message = ExceptionMessagesHelper.noForeingKey)
             : base(message)
        {
        }
    }
}