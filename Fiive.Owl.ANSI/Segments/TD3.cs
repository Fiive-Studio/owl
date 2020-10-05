using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class TD3 : ANSISegmentBase
	{
		public string TD301_40 { get; set; }
		public string TD302 { get; set; }
		public string TD303_207 { get; set; }
		public string TD304 { get; set; }
		public string TD305 { get; set; }
		public string TD306 { get; set; }
		public string TD307 { get; set; }
		public string TD308 { get; set; }
		public string TD309_225 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.TD301_40 = Helper.GetElementValue(valores, 1);
            this.TD302 = Helper.GetElementValue(valores, 2);
            this.TD303_207 = Helper.GetElementValue(valores, 3);
            this.TD304 = Helper.GetElementValue(valores, 4);
            this.TD305 = Helper.GetElementValue(valores, 5);
            this.TD306 = Helper.GetElementValue(valores, 6);
            this.TD307 = Helper.GetElementValue(valores, 7);
            this.TD308 = Helper.GetElementValue(valores, 8);
            this.TD309_225 = Helper.GetElementValue(valores, 9);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TD3"
                                    , string.Format("TD3{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{10}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(TD301_40, Properties)
                                        , Helper.ReleaseValue(TD302, Properties)
                                        , Helper.ReleaseValue(TD303_207, Properties)
                                        , Helper.ReleaseValue(TD304, Properties)
                                        , Helper.ReleaseValue(TD305, Properties)
                                        , Helper.ReleaseValue(TD306, Properties)
                                        , Helper.ReleaseValue(TD307, Properties)
                                        , Helper.ReleaseValue(TD308, Properties)
                                        , Helper.ReleaseValue(TD309_225, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
