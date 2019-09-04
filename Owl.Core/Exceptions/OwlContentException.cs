using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Owl.Core.Exceptions
{
    public class OwlContentException : ApplicationException
    {
        public OwlContentException()
        {
        }

        public OwlContentException(string message) : base(message)
        {
        }

        public OwlContentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwlContentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
