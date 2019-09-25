using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlDataTypeException : ApplicationException
    {
        public OwlDataTypeException()
        {
        }

        public OwlDataTypeException(string message) : base(message)
        {
        }

        public OwlDataTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwlDataTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
