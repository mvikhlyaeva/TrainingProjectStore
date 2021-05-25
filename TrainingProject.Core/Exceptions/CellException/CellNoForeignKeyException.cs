using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
