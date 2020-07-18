using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class OTI : ANSISegmentBase
	{
		public string OTI01_110 { get; set; }
		public string OTI02_128 { get; set; }
		public string OTI03_127 { get; set; }
		public string OTI10_143 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.OTI01_110 = Helper.GetElementValue(valores, 1);
            this.OTI02_128 = Helper.GetElementValue(valores, 2);
            this.OTI03_127 = Helper.GetElementValue(valores, 3);
            this.OTI10_143 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("OTI"
                                    , string.Format("OTI{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(OTI01_110, Properties)
                                        , Helper.ReleaseValue(OTI02_128, Properties)
                                        , Helper.ReleaseValue(OTI03_127, Properties)
                                        , Helper.ReleaseValue(OTI10_143, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}