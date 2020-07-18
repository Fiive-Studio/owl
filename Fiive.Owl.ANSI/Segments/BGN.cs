using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class BGN : ANSISegmentBase
	{
		public string BGN01_353 { get; set; }
		public string BGN02_127 { get; set; }
		public string BGN03_373 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BGN01_353 = Helper.GetElementValue(valores, 1);
            this.BGN02_127 = Helper.GetElementValue(valores, 2);
            this.BGN03_373 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BGN"
                                    , string.Format("BGN{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BGN01_353, Properties)
                                        , Helper.ReleaseValue(BGN02_127, Properties)
                                        , Helper.ReleaseValue(BGN03_373, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
