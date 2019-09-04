using Owl.Core.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Owl.FlatFile.Config
{
    [Serializable]
    [XmlRoot("owl")]
    public class OwlConfig
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("section")]
        public List<OwlSection> Sections { get; set; }
    }

    [Serializable]
    public class OwlSection
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("separator")]
        public string Separator { get; set; }

        [XmlElement("section")]
        public List<OwlSection> Sections { get; set; }

        [XmlElement("element")]
        public List<OwlElement> Elements { get; set; }
    }

    [Serializable]
    public class OwlElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

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
