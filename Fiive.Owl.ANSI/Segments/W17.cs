using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W17 : ANSISegmentBase
	{
		public string W1701_514 { get; set; }
		public string W1702_373 { get; set; }
		public string W1703_394 { get; set; }
		public string W1704_285 { get; set; }
		public string W1705_145 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W1701_514 = Helper.GetElementValue(valores, 1);
            this.W1702_373 = Helper.GetElementValue(valores, 2);
            this.W1703_394 = Helper.GetElementValue(valores, 3);
            this.W1704_285 = Helper.GetElementValue(valores, 4);
            this.W1705_145 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W17"
                                    , string.Format("W17{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W1701_514, Properties)
                                        , Helper.ReleaseValue(W1702_373, Properties)
                                        , Helper.ReleaseValue(W1703_394, Properties)
                                        , Helper.ReleaseValue(W1704_285, Properties)
                                        , Helper.ReleaseValue(W1705_145, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
