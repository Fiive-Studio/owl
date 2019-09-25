using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlLengthException : ApplicationException
    {
        public OwlLengthException()
        {
        }

        public OwlLengthException(string message) : base(message)
        {
        }

        public OwlLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwlLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
