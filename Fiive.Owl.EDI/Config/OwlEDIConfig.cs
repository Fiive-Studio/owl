using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.EDI.Config
{
    [Serializable]
    [XmlRoot("owl")]
    public class OwlEDIConfig
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("section")]
        public List<OwlEDISection> Sections { get; set; }
    }

    [Serializable]
    public class OwlEDISection
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("section")]
        public List<OwlEDISection> Sections { get; set; }
    }
}
