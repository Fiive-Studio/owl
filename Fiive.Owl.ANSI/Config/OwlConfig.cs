using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.ANSI.Config
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
    }
}
