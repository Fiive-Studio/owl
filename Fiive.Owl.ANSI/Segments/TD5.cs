using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class TD5 : ANSISegmentBase
	{

		public string TD501_133 { get; set; }
		public string TD502_66 { get; set; }
		public string TD503_67 { get; set; }
		public string TD504_91 { get; set; }
        public string TD505_67 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.TD501_133 = Helper.GetElementValue(valores, 1);
            this.TD502_66 = Helper.GetElementValue(valores, 2);
            this.TD503_67 = Helper.GetElementValue(valores, 3);
            this.TD504_91 = Helper.GetElementValue(valores, 4);
            this.TD505_67 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TD5"
                                    , string.Format("TD5{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(TD501_133, Properties)
                                        , Helper.ReleaseValue(TD502_66, Properties)
                                        , Helper.ReleaseValue(TD503_67, Properties)
                                        , Helper.ReleaseValue(TD504_91, Properties)
                                        , Helper.ReleaseValue(TD505_67, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
