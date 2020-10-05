using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class UIT : ANSISegmentBase
	{
		public string UIT01_355 { get; set; }
        public string UIT02_212 { get; set; }
        public string UIT03_639 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.UIT01_355 = Helper.GetElementValue(valores, 1);
            this.UIT02_212 = Helper.GetElementValue(valores, 2);
            this.UIT03_639 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UIT"
                                    , string.Format("UIT{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(UIT01_355, Properties)
                                        , Helper.ReleaseValue(UIT02_212, Properties)
                                        , Helper.ReleaseValue(UIT03_639, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}