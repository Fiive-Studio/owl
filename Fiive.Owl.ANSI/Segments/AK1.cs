using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class AK1 : ANSISegmentBase
    {
		public string AK101 { get; set; }
		public string AK102 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.AK101 = Helper.GetElementValue(valores, 1);
            this.AK102 = Helper.GetElementValue(valores, 2);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("AK1"
                                    , string.Format("AK1{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(AK101, Properties)
                                        , Helper.ReleaseValue(AK102, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
