using Fiive.Owl.Core.Adapters;
using Fiive.Owl.Core.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fiive.Owl.FlatFile.Config
{
    [Serializable]
    [XmlRoot("owl")]
    public class OwlFlatFileConfig : OwlConfig
    {
        [XmlElement("section")]
        public List<OwlFlatFileSection> Sections { get; set; }
    }

    [Serializable]
    public class OwlFlatFileSection : OwlSection
    {
        [XmlAttribute("separator")]
        public string Separator { get; set; }

        [XmlElement("section")]
        public List<OwlFlatFileSection> Sections { get; set; }

        [XmlElement("element")]
        public List<OwlFlatFileElement> Elements { get; set; }
    }

    [Serializable]
    public class OwlFlatFileElement : OwlElement
    {
        [XmlAttribute("start-position")]
        public int StartPosition { get; set; }

        [XmlAttribute("length")]
        public int Length { get; set; }

        [XmlAttribute("data-type")]
        public DataType DataType { get; set; }

        [XmlAttribute("required")]
        public bool Required { get; set; }
    }
}
