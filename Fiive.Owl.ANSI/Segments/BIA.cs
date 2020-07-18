using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class BIA : ANSISegmentBase
	{
		public string BIA01_353 { get; set; }
		public string BIA02_755 { get; set; }
		public string BIA03_127 { get; set; }
		public string BIA04_373 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BIA01_353 = Helper.GetElementValue(valores, 1);
            this.BIA02_755 = Helper.GetElementValue(valores, 2);
            this.BIA03_127 = Helper.GetElementValue(valores, 3);
            this.BIA04_373 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BIA"
                                    , string.Format("BIA{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BIA01_353, Properties)
                                        , Helper.ReleaseValue(BIA02_755, Properties)
                                        , Helper.ReleaseValue(BIA03_127, Properties)
                                        , Helper.ReleaseValue(BIA04_373, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
