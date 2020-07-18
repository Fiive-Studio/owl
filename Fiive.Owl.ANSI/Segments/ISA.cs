using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class ISA : ANSISegmentBase
	{
		public string ISA01_I01 { get; set; }
		public string ISA02_I02 { get; set; }
		public string ISA03_I03 { get; set; }
		public string ISA04_I04 { get; set; }
		public string ISA05_I05 { get; set; }
		public string ISA06_I06 { get; set; }
		public string ISA07_I05 { get; set; }
		public string ISA08_I07 { get; set; }
		public string ISA09_I08 { get; set; }
		public string ISA10_I09 { get; set; }
		public string ISA11_I10 { get; set; }
		public string ISA12_I11 { get; set; }
		public string ISA13_I12 { get; set; }
		public string ISA14_I13 { get; set; }
		public string ISA15_I14 { get; set; }
		public string ISA16_I15 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.ISA01_I01 = Helper.GetElementValue(valores, 1);
            this.ISA02_I02 = Helper.GetElementValue(valores, 2);
            this.ISA03_I03 = Helper.GetElementValue(valores, 3);
            this.ISA04_I04 = Helper.GetElementValue(valores, 4);
            this.ISA05_I05 = Helper.GetElementValue(valores, 5);
            this.ISA06_I06 = Helper.GetElementValue(valores, 6);
            this.ISA07_I05 = Helper.GetElementValue(valores, 7);
            this.ISA08_I07 = Helper.GetElementValue(valores, 8);
            this.ISA09_I08 = Helper.GetElementValue(valores, 9);
            this.ISA10_I09 = Helper.GetElementValue(valores, 10);
            this.ISA11_I10 = Helper.GetElementValue(valores, 11);
            this.ISA12_I11 = Helper.GetElementValue(valores, 12);
            this.ISA13_I12 = Helper.GetElementValue(valores, 13);
            this.ISA14_I13 = Helper.GetElementValue(valores, 14);
            this.ISA15_I14 = Helper.GetElementValue(valores, 15);
            this.ISA16_I15 = Helper.GetElementValue(valores, 16);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ISA"
                                    , string.Format("ISA{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{17}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(ISA01_I01, Properties)
                                        , Helper.ReleaseValue(ISA02_I02, Properties)
                                        , Helper.ReleaseValue(ISA03_I03, Properties)
                                        , Helper.ReleaseValue(ISA04_I04, Properties)
                                        , Helper.ReleaseValue(ISA05_I05, Properties)
                                        , Helper.ReleaseValue(ISA06_I06, Properties)
                                        , Helper.ReleaseValue(ISA07_I05, Properties)
                                        , Helper.ReleaseValue(ISA08_I07, Properties)
                                        , Helper.ReleaseValue(ISA09_I08, Properties)
                                        , Helper.ReleaseValue(ISA10_I09, Properties)
                                        , Helper.ReleaseValue(ISA11_I10, Properties)
                                        , Helper.ReleaseValue(ISA12_I11, Properties)
                                        , Helper.ReleaseValue(ISA13_I12, Properties)
                                        , Helper.ReleaseValue(ISA14_I13, Properties)
                                        , Helper.ReleaseValue(ISA15_I14, Properties)
                                        , Helper.ReleaseValue(ISA16_I15, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
