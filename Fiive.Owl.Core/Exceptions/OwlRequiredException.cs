using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlRequiredException : ApplicationException
    {
        public OwlRequiredException()
        {
        }

        public OwlRequiredException(string message) : base(message)
        {
        }

        public OwlRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwlRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
