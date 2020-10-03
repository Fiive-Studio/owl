using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;
using Fiive.Owl.FlatFile.Config;
using Fiive.Owl.FlatFile.Structure;

namespace Fiive.Owl.UnitTest
{
    [TestClass]
    public class FlatFileAdapter
    {
        OwlFlatFileConfig GetConfig(string filename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            OwlFlatFileConfig owlConfig = XmlExtension.Deserialize<OwlFlatFileConfig>(xml);

            return owlConfig;
        }

        string GetContent(string filename)
        {
            return File.ReadAllText(filename);
        }

        [TestMethod]
        public void ValidateContent_1()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\1\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\1\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
            Assert.AreEqual(original, content);
        }

        [TestMethod]
        [ExpectedException(typeof(OwlRequiredException))]
        public void ValidateRequiredException_2()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\2\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\2\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
        }

        [TestMethod]
        public void ValidateRequiredMessage_2()
        {
            try
            {
                OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\2\owl-config-flatfile.xml");

                FlatFileDocument document = new FlatFileDocument();
                string original = GetContent(@"examples\flatfile\2\test.txt");
                document.LoadContent(owlConfig, original);

                string content = document.ToString();
            }
            catch (OwlRequiredException e)
            {
                Assert.AreEqual("The element: 'enc_1' - section: 'ENC' is required", e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OwlDataTypeException))]
        public void ValidateDataTypeException_3()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\3\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\3\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
        }

        [TestMethod]
        public void ValidateDataTypeMessage_3()
        {
            try
            {
                OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\3\owl-config-flatfile.xml");

                FlatFileDocument document = new FlatFileDocument();
                string original = GetContent(@"examples\flatfile\3\test.txt");
                document.LoadContent(owlConfig, original);

                string content = document.ToString();
            }
            catch (OwlDataTypeException e)
            {
                Assert.AreEqual("The element: 'enc_1' - section: 'ENC' have data-type: 'int' and the sent value is: '770.2'", e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OwlLengthException))]
        public void ValidateLengthException_4()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\4\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\4\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
        }

        [TestMethod]
        public void ValidateLengthTypeMessage_4()
        {
            try
            {
                OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\4\owl-config-flatfile.xml");

                FlatFileDocument document = new FlatFileDocument();
                string original = GetContent(@"examples\flatfile\4\test.txt");
                document.LoadContent(owlConfig, original);

                string content = document.ToString();
            }
            catch (OwlLengthException e)
            {
                Assert.AreEqual("The element: 'loc_1' - section: 'LOC' have length: '3' and the allowed length is: '2' - sent value is: '770'", e.Message);
            }
        }

        [TestMethod]
        public void ValidateContent_5()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\5\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\5\test.txt");
            document.LoadContent(owlConfig, original);

            string content = document.ToString();
            Assert.AreEqual(original, content);
        }

        [TestMethod]
        [ExpectedException(typeof(OwlContentException))]
        public void ValidateOwlContentException_6()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\6\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            string original = GetContent(@"examples\flatfile\6\test.txt");
            document.LoadContent(owlConfig, original);
        }

        [TestMethod]
        public void ValidateOwlContentMessage_6()
        {
            try
            {
                OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\6\owl-config-flatfile.xml");

                FlatFileDocument document = new FlatFileDocument();
                string original = GetContent(@"examples\flatfile\6\test.txt");
                document.LoadContent(owlConfig, original);
            }
            catch (OwlContentException e)
            {
                Assert.AreEqual("Invalid content found in position '21'. The last valid section was 'ENC'", e.Message);
            }
        }

        [TestMethod]
        public void ValidateSerialize()
        {
            OwlFlatFileConfig owlConfig = GetConfig(@"examples\flatfile\1\owl-config-flatfile.xml");

            FlatFileDocument document = new FlatFileDocument();
            document.LoadContent(owlConfig, GetContent(@"examples\flatfile\1\test.txt"));

            XmlDocument xmlResult = XmlExtension.Serialize(document);
        }
    }
}
