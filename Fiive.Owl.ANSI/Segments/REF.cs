using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class REF : ANSISegmentBase
	{
		public string REF01_128 { get; set; }
		public string REF02_127 { get; set; }
		public string REF03_352 { get; set; }
        public string REF04_128 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.REF01_128 = Helper.GetElementValue(valores, 1);
            this.REF02_127 = Helper.GetElementValue(valores, 2);
            this.REF03_352 = Helper.GetElementValue(valores, 3);
            this.REF04_128 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("REF"
                                    , string.Format("REF{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(REF01_128, Properties)
                                        , Helper.ReleaseValue(REF02_127, Properties)
                                        , Helper.ReleaseValue(REF03_352, Properties)
                                        , Helper.ReleaseValue(REF04_128, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}