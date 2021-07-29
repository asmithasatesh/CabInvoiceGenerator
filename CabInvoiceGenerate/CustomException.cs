using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerate
{
    public class CustomException: Exception
    {
        public ExceptionType type;
        public string message;

        //Create Custome Exception
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME, NULL_RIDES
        }
        
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
