using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class TXI : ANSISegmentBase
	{
        public string TXI01_963 { get; set; }
        public string TXI02_782 { get; set; }
        public string TXI03_954 { get; set; }
        public string TXI04_955 { get; set; }
        public string TXI05_956 { get; set; }
        public string TXI06_441 { get; set; }
        public string TXI07_662 { get; set; }
        public string TXI08_828 { get; set; }
        public string TXI09_325 { get; set; }
        public string TXI10_350 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.TXI01_963 = Helper.GetElementValue(valores, 1);
            this.TXI02_782 = Helper.GetElementValue(valores, 2);
            this.TXI03_954 = Helper.GetElementValue(valores, 3);
            this.TXI04_955 = Helper.GetElementValue(valores, 4);
            this.TXI05_956 = Helper.GetElementValue(valores, 5);
            this.TXI06_441 = Helper.GetElementValue(valores, 6);
            this.TXI07_662 = Helper.GetElementValue(valores, 7);
            this.TXI08_828 = Helper.GetElementValue(valores, 8);
            this.TXI09_325 = Helper.GetElementValue(valores, 9);
            this.TXI10_350 = Helper.GetElementValue(valores, 10);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TXI"
                                    , string.Format("TXI{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{11}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(TXI01_963, Properties)
                                        , Helper.ReleaseValue(TXI02_782, Properties)
                                        , Helper.ReleaseValue(TXI03_954, Properties)
                                        , Helper.ReleaseValue(TXI04_955, Properties)
                                        , Helper.ReleaseValue(TXI05_956, Properties)
                                        , Helper.ReleaseValue(TXI06_441, Properties)
                                        , Helper.ReleaseValue(TXI07_662, Properties)
                                        , Helper.ReleaseValue(TXI08_828, Properties)
                                        , Helper.ReleaseValue(TXI09_325, Properties)
                                        , Helper.ReleaseValue(TXI10_350, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
