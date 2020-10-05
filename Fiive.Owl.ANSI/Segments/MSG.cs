using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class MSG : ANSISegmentBase
	{
		public string MSG01_933 { get; set; }
		public string MSG02_934 { get; set; }
		public string MSG03_1470 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.MSG01_933 = Helper.GetElementValue(valores, 1);
            this.MSG02_934 = Helper.GetElementValue(valores, 2);
            this.MSG03_1470 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MSG"
                                    , string.Format("MSG{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(MSG01_933, Properties)
                                        , Helper.ReleaseValue(MSG02_934, Properties)
                                        , Helper.ReleaseValue(MSG03_1470, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
