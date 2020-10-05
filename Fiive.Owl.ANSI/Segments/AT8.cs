using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class AT8 : ANSISegmentBase
    {

		public string AT801_187 { get; set; }
		public string AT802_188 { get; set; }
		public string AT803_81 { get; set; }
		public string AT804_80 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.AT801_187 = Helper.GetElementValue(valores, 1);
            this.AT802_188 = Helper.GetElementValue(valores, 2);
            this.AT803_81 = Helper.GetElementValue(valores, 3);
            this.AT804_80 = Helper.GetElementValue(valores, 4);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("AT8"
                                    , string.Format("AT8{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(AT801_187, Properties)
                                        , Helper.ReleaseValue(AT802_188, Properties)
                                        , Helper.ReleaseValue(AT803_81, Properties)
                                        , Helper.ReleaseValue(AT804_80, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
