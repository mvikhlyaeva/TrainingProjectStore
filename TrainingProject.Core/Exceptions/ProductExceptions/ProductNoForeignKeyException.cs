using System;

namespace TrainingProject.Core.Exceptions.ProductExceptions
{
    public class ProductNoForeignKeyException : Exception
    {
        public ProductNoForeignKeyException(string message = ExceptionMessagesHelper.noForeingKey)
             : base(message)
        {
        }
    }
}