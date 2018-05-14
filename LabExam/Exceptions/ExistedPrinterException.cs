using System;
using System.Runtime.Serialization;

namespace LabExam.Exceptions
{
    [Serializable]
    public class ExistedPrinterException : Exception
    {
        public ExistedPrinterException()
            : base()
        {
        }

        public ExistedPrinterException(string message)
            : base(message)
        {
        }

        public ExistedPrinterException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExistedPrinterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}