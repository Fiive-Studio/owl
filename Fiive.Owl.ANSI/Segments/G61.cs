using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G61 : ANSISegmentBase
	{
		public string G6101_366 { get; set; }
		public string G6102_93 { get; set; }
        public string G6103_365 { get; set; }
        public string G6104_364 { get; set; }
        public string G6105 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G6101_366 = Helper.GetElementValue(valores, 1);
            this.G6102_93 = Helper.GetElementValue(valores, 2);
            this.G6103_365 = Helper.GetElementValue(valores, 3);
            this.G6104_364 = Helper.GetElementValue(valores, 4);
            this.G6105 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G61"
                                    , string.Format("G61{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G6101_366, Properties)
                                        , Helper.ReleaseValue(G6102_93, Properties)
                                        , Helper.ReleaseValue(G6103_365, Properties)
                                        , Helper.ReleaseValue(G6104_364, Properties)
                                        , Helper.ReleaseValue(G6105, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
