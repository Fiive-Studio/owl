using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlSectionException : OwlException
    {
        public string Xml { get; private set; }
        public string ParentNode { get; private set; }

        public OwlSectionException()
        {
        }

        public OwlSectionException(string message, string xml, string parentNode, string section)
            : base(message, section)
        {
            this.Xml = xml;
            this.ParentNode = parentNode;
        }

        public OwlSectionException(string message, string xml, string parentNode, string section, System.Exception innerException)
            : base(message, section, innerException)
        {
            this.Xml = xml;
            this.ParentNode = parentNode;
        }
    }
}
