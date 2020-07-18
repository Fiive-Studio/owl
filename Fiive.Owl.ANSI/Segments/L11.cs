using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class L11 : ANSISegmentBase
	{
		public string L1101_127 { get; set; }
		public string L1102_128 { get; set; }
		public string L1103_352 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.L1101_127 = Helper.GetElementValue(valores, 1);
            this.L1102_128 = Helper.GetElementValue(valores, 2);
            this.L1103_352 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("L11"
                                    , string.Format("L11{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(L1101_127, Properties)
                                        , Helper.ReleaseValue(L1102_128, Properties)
                                        , Helper.ReleaseValue(L1103_352, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
