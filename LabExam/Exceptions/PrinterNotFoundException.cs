using System;
using System.Runtime.Serialization;

namespace LabExam.Exceptions
{
    public class PrinterNotFoundException : Exception
    {
        public PrinterNotFoundException()
        {
        }

        public PrinterNotFoundException(string message) : base(message)
        {
        }

        public PrinterNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PrinterNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}