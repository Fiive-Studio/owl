using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.ANSI.Config
{
    [Serializable]
    [XmlRoot("owl")]
    public class OwlANSIConfig
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("section")]
        public List<OwlANSISection> Sections { get; set; }
    }

    [Serializable]
    public class OwlANSISection
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("section")]
        public List<OwlANSISection> Sections { get; set; }
    }
}
