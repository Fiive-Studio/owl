using Fiive.Owl.Core;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Formats.Input;
using Fiive.Owl.Formats.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
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

        [TestMethod]
        public void ValidateEachMapKeyword_3()
        {
            var owl = GetHandler(@"examples\keywords\2\owl-output-config.xml", @"examples\keywords\2\input.xml");
            owl["variable"] = "variable";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("field_1", typeof(string));
            dt.Columns.Add("field_2", typeof(string));
            ds.Tables.Add(dt);

            dt.Rows.Add("field_1", "reference");

            owl.Settings.References = ds;

            var filesGenerated = 0;
            var expectedResult = @"default|variable|1|xpath|reference|concatenate|substring|6|is-number|3|is-empty|trim|if
";

            foreach (GenericOutputValue value in owl.WriteOutput(new FlatFileOutput()))
            {
                Assert.AreEqual(expectedResult, value.Content);
                filesGenerated++;
            }

            Assert.AreEqual(1, filesGenerated);
        }
    }
}
