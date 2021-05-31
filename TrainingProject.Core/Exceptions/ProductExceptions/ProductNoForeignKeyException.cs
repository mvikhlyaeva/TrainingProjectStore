using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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