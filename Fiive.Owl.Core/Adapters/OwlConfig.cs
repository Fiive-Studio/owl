using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.Core.Adapters
{
    [Serializable]
    [XmlRoot("owl")]
    public class OwlConfig
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
    }

    [Serializable]
    public class OwlSection
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }
    }

    [Serializable]
    public class OwlElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
