using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class IT1 : ANSISegmentBase
	{
        public string IT101_350 { get; set; }
        public string IT102_358 { get; set; }
        public string IT103_355 { get; set; }
        public string IT104_212 { get; set; }
        public string IT105_639 { get; set; }
        public string IT106_235 { get; set; }
        public string IT107_234 { get; set; }
        public string IT108_235 { get; set; }
        public string IT109_234 { get; set; }
        public string IT110_235 { get; set; }
        public string IT111_234 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.IT101_350 = Helper.GetElementValue(valores, 1);
            this.IT102_358 = Helper.GetElementValue(valores, 2);
            this.IT103_355 = Helper.GetElementValue(valores, 3);
            this.IT104_212 = Helper.GetElementValue(valores, 4);
            this.IT105_639 = Helper.GetElementValue(valores, 5);
            this.IT106_235 = Helper.GetElementValue(valores, 6);
            this.IT107_234 = Helper.GetElementValue(valores, 7);
            this.IT108_235 = Helper.GetElementValue(valores, 8);
            this.IT109_234 = Helper.GetElementValue(valores, 9);
            this.IT110_235 = Helper.GetElementValue(valores, 10);
            this.IT111_234 = Helper.GetElementValue(valores, 11);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("IT1"
                                    , string.Format("IT1{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{12}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(IT101_350, Properties)
                                        , Helper.ReleaseValue(IT102_358, Properties)
                                        , Helper.ReleaseValue(IT103_355, Properties)
                                        , Helper.ReleaseValue(IT104_212, Properties)
                                        , Helper.ReleaseValue(IT105_639, Properties)
                                        , Helper.ReleaseValue(IT106_235, Properties)
                                        , Helper.ReleaseValue(IT107_234, Properties)
                                        , Helper.ReleaseValue(IT108_235, Properties)
                                        , Helper.ReleaseValue(IT109_234, Properties)
                                        , Helper.ReleaseValue(IT110_235, Properties)
                                        , Helper.ReleaseValue(IT111_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
