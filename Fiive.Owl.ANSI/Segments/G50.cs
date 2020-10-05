using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class G50 : ANSISegmentBase
	{
		public string G5001_473 { get; set; }
        public string G5002_373 { get; set; }
        public string G5003_324 { get; set; }
        public string G5004_441 { get; set; }
        public string G5005_474 { get; set; }
        public string G5006_472 { get; set; }
        public string G5007_92 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G5001_473 = Helper.GetElementValue(valores, 1);
            this.G5002_373 = Helper.GetElementValue(valores, 2);
            this.G5003_324 = Helper.GetElementValue(valores, 3);
            this.G5004_441 = Helper.GetElementValue(valores, 4);
            this.G5005_474 = Helper.GetElementValue(valores, 5);
            this.G5006_472 = Helper.GetElementValue(valores, 6);
            this.G5007_92 = Helper.GetElementValue(valores, 7);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G50"
                                    , string.Format("G50{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{8}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G5001_473, Properties)
                                        , Helper.ReleaseValue(G5002_373, Properties)
                                        , Helper.ReleaseValue(G5003_324, Properties)
                                        , Helper.ReleaseValue(G5004_441, Properties)
                                        , Helper.ReleaseValue(G5005_474, Properties)
                                        , Helper.ReleaseValue(G5006_472, Properties)
                                        , Helper.ReleaseValue(G5007_92, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}