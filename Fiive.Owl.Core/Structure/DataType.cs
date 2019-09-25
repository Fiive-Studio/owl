using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.Core.Structure
{
    public enum DataType
    {
        [XmlEnum("string")]
        String,
        [XmlEnum("int")]
        Int,
        [XmlEnum("decimal")]
        Decimal
    }
}
