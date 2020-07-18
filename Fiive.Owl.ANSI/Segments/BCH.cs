using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class BCH : ANSISegmentBase
	{
        public string BCH01_353 { get; set; }
        public string BCH02_92 { get; set; }
        public string BCH03_324 { get; set; }
        public string BCH04_328 { get; set; }
        public string BCH05_327 { get; set; }
        public string BCH06_373 { get; set; }
        public string BCH07_326 { get; set; }
        public string BCH08_367 { get; set; }
        public string BCH09_127 { get; set; }
        public string BCH010_587 { get; set; }
        public string BCH011_123 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BCH01_353 = Helper.GetElementValue(valores, 1);
            this.BCH02_92 = Helper.GetElementValue(valores, 2);
            this.BCH03_324 = Helper.GetElementValue(valores, 3);
            this.BCH04_328 = Helper.GetElementValue(valores, 4);
            this.BCH05_327 = Helper.GetElementValue(valores, 5);
            this.BCH06_373 = Helper.GetElementValue(valores, 6);
            this.BCH07_326 = Helper.GetElementValue(valores, 7);
            this.BCH08_367 = Helper.GetElementValue(valores, 8);
            this.BCH09_127 = Helper.GetElementValue(valores, 9);
            this.BCH010_587 = Helper.GetElementValue(valores, 10);
            this.BCH011_123 = Helper.GetElementValue(valores, 11);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BCH"
                                    , string.Format("BCH{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{12}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BCH01_353, Properties)
                                        , Helper.ReleaseValue(BCH02_92, Properties)
                                        , Helper.ReleaseValue(BCH03_324, Properties)
                                        , Helper.ReleaseValue(BCH04_328, Properties)
                                        , Helper.ReleaseValue(BCH05_327, Properties)
                                        , Helper.ReleaseValue(BCH06_373, Properties)
                                        , Helper.ReleaseValue(BCH07_326, Properties)
                                        , Helper.ReleaseValue(BCH08_367, Properties)
                                        , Helper.ReleaseValue(BCH09_127, Properties)
                                        , Helper.ReleaseValue(BCH010_587, Properties)
                                        , Helper.ReleaseValue(BCH011_123, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
