using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerate
{
    public class CustomException: Exception
    {
        public ExceptionType type;
        public string message;

        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME
        }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
