using Fiive.Owl.Core;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Formats.Input;
using Fiive.Owl.Formats.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiive.Owl.UnitTest
{
    [TestClass]
    public class Keywords
    {
        OwlHandler GetHandler(string config, string input)
        {
            OwlSettings settings = new OwlSettings
            {
                PathConfig = config
            };

            var owl = new OwlHandler(settings);
            owl.LoadConfigMap();
            owl.LoadInput(new XmlInput(input));

            return owl;
        }

        [TestMethod]
        public void ValidateResult_1()
        {
            var owl = GetHandler(@"examples\keywords\1\owl-output-config.xml", @"examples\keywords\1\input.xml");
            owl["var"] = "VALUE";

            var filesGenerated = 0;
            var expectedResult = @"ENC|south|Avenue 5|VALUE
1|Yours sincerely,| Paul Smith|Smith Company Ltd.|http://www.smith-company-ltd.com
2|Yours sincerely,| Paul Smith|Smith & Company Ltd.|http://www.smith-company-ltd.com
";

            foreach (GenericOutputValue value in owl.WriteOutput(new FlatFileOutput()))
            {
                Assert.AreEqual(expectedResult, value.Content);
                filesGenerated++;
            }

            Assert.AreEqual(1, filesGenerated);
        }

        [TestMethod]
        [ExpectedException(typeof(OwlElementException))]
        public void ValidateVariableException_2()
        {
            var owl = GetHandler(@"examples\keywords\1\owl-output-config.xml", @"examples\keywords\1\input.xml");
            foreach (GenericOutputValue value in owl.WriteOutput(new FlatFileOutput())) { }
        }
    }
}
