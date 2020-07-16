using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlException : ApplicationException
    {
        public virtual string Section { get; private set; }

        public OwlException() : base() { }

        public OwlException(string message) : base(message) { }

        public OwlException(string message, string section) : base(message) { Section = section; }

        public OwlException(string message, Exception innerException) : base(message, innerException) { }

        public OwlException(string message, string section, System.Exception innerException) : base(message, innerException) { this.Section = section; }

        protected OwlException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
