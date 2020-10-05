using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Fiive.Owl.ANSI.Config;
using Fiive.Owl.ANSI.Documents;
using Fiive.Owl.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiive.Owl.UnitTest
{
    [TestClass]
    public class Ansi
    {
        OwlANSIConfig GetConfig(string filename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            OwlANSIConfig owlConfig = XmlExtension.Deserialize<OwlANSIConfig>(xml);

            return owlConfig;
        }

        string GetContent(string filename)
        {
            return File.ReadAllText(filename);
        }

        [TestMethod]
        public void ValidateContent_1()
        {
            OwlANSIConfig owlConfig = GetConfig(@"examples\ansi\1\owl-config-ansi.xml");

            ANSIDocument document = new ANSIDocument();
            string original = GetContent(@"examples\ansi\1\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
            Assert.AreEqual(original, content);
        }
    }
}
