using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class QTY : ANSISegmentBase
	{
		public string QTY01_673 { get; set; }
		public string QTY02_380 { get; set; }
        public string QTY03_355 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.QTY01_673 = Helper.GetElementValue(valores, 1);
            this.QTY02_380 = Helper.GetElementValue(valores, 2);
            this.QTY03_355 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("QTY"
                                    , string.Format("QTY{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(QTY01_673, Properties)
                                        , Helper.ReleaseValue(QTY02_380, Properties)
                                        , Helper.ReleaseValue(QTY03_355, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
