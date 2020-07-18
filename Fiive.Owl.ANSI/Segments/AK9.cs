using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class AK9 : ANSISegmentBase
	{
		public string AK901 { get; set; }
        public string AK902 { get; set; }
        public string AK903 { get; set; }
        public string AK904 { get; set; }
        public string AK905 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.AK901 = Helper.GetElementValue(valores, 1);
            this.AK902 = Helper.GetElementValue(valores, 2);
            this.AK903 = Helper.GetElementValue(valores, 3);
            this.AK904 = Helper.GetElementValue(valores, 4);
            this.AK905 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("AK9"
                                    , string.Format("AK9{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(AK901, Properties)
                                        , Helper.ReleaseValue(AK902, Properties)
                                        , Helper.ReleaseValue(AK903, Properties)
                                        , Helper.ReleaseValue(AK904, Properties)
                                        , Helper.ReleaseValue(AK905, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
