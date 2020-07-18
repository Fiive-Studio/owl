using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W15 : ANSISegmentBase
	{
		public string W1501_373 { get; set; }
		public string W1502_31 { get; set; }
		public string W1503_31 { get; set; }
		public string W1504_353 { get; set; }
		public string W1505_640 { get; set; }
		public string W1506_306 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W1501_373 = Helper.GetElementValue(valores, 1);
            this.W1502_31 = Helper.GetElementValue(valores, 2);
            this.W1503_31 = Helper.GetElementValue(valores, 3);
            this.W1504_353 = Helper.GetElementValue(valores, 4);
            this.W1505_640 = Helper.GetElementValue(valores, 5);
            this.W1506_306 = Helper.GetElementValue(valores, 6);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W15"
                                    , string.Format("W15{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W1501_373, Properties)
                                        , Helper.ReleaseValue(W1502_31, Properties)
                                        , Helper.ReleaseValue(W1503_31, Properties)
                                        , Helper.ReleaseValue(W1504_353, Properties)
                                        , Helper.ReleaseValue(W1505_640, Properties)
                                        , Helper.ReleaseValue(W1506_306, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
