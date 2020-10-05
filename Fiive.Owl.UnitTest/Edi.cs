using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Fiive.Owl.Core.Extensions;
using Fiive.Owl.EDI.Config;
using Fiive.Owl.EDI.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiive.Owl.UnitTest
{
    [TestClass]
    public class Edi
    {
        OwlEDIConfig GetConfig(string filename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            OwlEDIConfig owlConfig = XmlExtension.Deserialize<OwlEDIConfig>(xml);

            return owlConfig;
        }

        string GetContent(string filename)
        {
            return File.ReadAllText(filename);
        }

        [TestMethod]
        public void ValidateContent_1()
        {
            OwlEDIConfig owlConfig = GetConfig(@"examples\edi\1\owl-config-edi.xml");

            EDIDocument document = new EDIDocument();
            string original = GetContent(@"examples\edi\1\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
            Assert.AreEqual(original, content);
        }
    }
}
