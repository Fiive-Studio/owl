using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class B10 : ANSISegmentBase
	{
		public string B1001_127 { get; set; }
		public string B1002_145 { get; set; }
		public string B1003_140 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.B1001_127 = Helper.GetElementValue(valores, 1);
            this.B1002_145 = Helper.GetElementValue(valores, 2);
            this.B1003_140 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("B10"
                                    , string.Format("B10{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(B1001_127, Properties)
                                        , Helper.ReleaseValue(B1002_145, Properties)
                                        , Helper.ReleaseValue(B1003_140, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
