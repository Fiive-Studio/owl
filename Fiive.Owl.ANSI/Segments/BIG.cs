using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class BIG : ANSISegmentBase
	{
		public string BIG01_373 { get; set; }
		public string BIG02_76 { get; set; }
		public string BIG03 { get; set; }
		public string BIG04_324 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BIG01_373 = Helper.GetElementValue(valores, 1);
            this.BIG02_76 = Helper.GetElementValue(valores, 2);
            this.BIG03 = Helper.GetElementValue(valores, 3);
            this.BIG04_324 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BIG"
                                    , string.Format("BIG{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BIG01_373, Properties)
                                        , Helper.ReleaseValue(BIG02_76, Properties)
                                        , Helper.ReleaseValue(BIG03, Properties)
                                        , Helper.ReleaseValue(BIG04_324, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
