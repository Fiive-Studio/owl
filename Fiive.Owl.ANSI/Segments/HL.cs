using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
    public class HL : ANSISegmentBase
	{
		public string HL01_628 { get; set; }
		public string HL02_734 { get; set; }
		public string HL03_735 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.HL01_628 = Helper.GetElementValue(valores, 1);
            this.HL02_734 = Helper.GetElementValue(valores, 2);
            this.HL03_735 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("HL"
                                    , string.Format("HL{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(HL01_628, Properties)
                                        , Helper.ReleaseValue(HL02_734, Properties)
                                        , Helper.ReleaseValue(HL03_735, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}