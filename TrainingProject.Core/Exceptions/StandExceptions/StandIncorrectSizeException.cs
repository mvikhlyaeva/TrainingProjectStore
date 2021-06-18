﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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