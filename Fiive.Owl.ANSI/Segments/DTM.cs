using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class DTM : ANSISegmentBase
	{
		public string DTM01_374 { get; set; }
		public string DTM02_373 { get; set; }
		public string DTM03_337 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.DTM01_374 = Helper.GetElementValue(valores, 1);
            this.DTM02_373 = Helper.GetElementValue(valores, 2);
            this.DTM03_337 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DTM"
                                    , string.Format("DTM{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(DTM01_374, Properties)
                                        , Helper.ReleaseValue(DTM02_373, Properties)
                                        , Helper.ReleaseValue(DTM03_337, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
