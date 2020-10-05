using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class BEG : ANSISegmentBase
	{
		public string BEG01_353 { get; set; }
		public string BEG02_92 { get; set; }
		public string BEG03_324 { get; set; }
		public string BEG04_328 { get; set; }
		public string BEG05_373 { get; set; }
        public string BEG06 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BEG01_353 = Helper.GetElementValue(valores, 1);
            this.BEG02_92 = Helper.GetElementValue(valores, 2);
            this.BEG03_324 = Helper.GetElementValue(valores, 3);
            this.BEG04_328 = Helper.GetElementValue(valores, 4);
            this.BEG05_373 = Helper.GetElementValue(valores, 5);
            this.BEG06 = Helper.GetElementValue(valores, 6);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BEG"
                                    , string.Format("BEG{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BEG01_353, Properties)
                                        , Helper.ReleaseValue(BEG02_92, Properties)
                                        , Helper.ReleaseValue(BEG03_324, Properties)
                                        , Helper.ReleaseValue(BEG04_328, Properties)
                                        , Helper.ReleaseValue(BEG05_373, Properties)
                                        , Helper.ReleaseValue(BEG06, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
