using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class MAN : ANSISegmentBase
	{
		public string MAN01_88 { get; set; }
		public string MAN02_87 { get; set; }
		public string MAN03_87 { get; set; }
		public string MAN04_88 { get; set; }
		public string MAN05_87 { get; set; }
		public string MAN06_87 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.MAN01_88 = Helper.GetElementValue(valores, 1);
            this.MAN02_87 = Helper.GetElementValue(valores, 2);
            this.MAN03_87 = Helper.GetElementValue(valores, 3);
            this.MAN04_88 = Helper.GetElementValue(valores, 4);
            this.MAN05_87 = Helper.GetElementValue(valores, 5);
            this.MAN06_87 = Helper.GetElementValue(valores, 6);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MAN"
                                    , string.Format("MAN{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(MAN01_88, Properties)
                                        , Helper.ReleaseValue(MAN02_87, Properties)
                                        , Helper.ReleaseValue(MAN03_87, Properties)
                                        , Helper.ReleaseValue(MAN04_88, Properties)
                                        , Helper.ReleaseValue(MAN05_87, Properties)
                                        , Helper.ReleaseValue(MAN06_87, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
