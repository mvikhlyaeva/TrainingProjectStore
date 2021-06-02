using System;

namespace TrainingProject.Core.Exceptions.ProductExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message = ExceptionMessagesHelper.notFound)
             : base(message)
        {
        }
    }
}