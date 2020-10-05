using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlElementException : OwlException
    {
        public string Xml { get; private set; }
        public string ParentNode { get; private set; }
        public OwlElementException() : base() { }

        public OwlElementException(string message, string xml, string parentNode, string section)
            : base(message, section)
        {
            this.Xml = xml;
            this.ParentNode = parentNode;
        }

        public OwlElementException(string message, string xml, string parentNode, string section, System.Exception innerException)
            : base(message, section, innerException)
        {
            this.Xml = xml;
            this.ParentNode = parentNode;
        }
    }
}
