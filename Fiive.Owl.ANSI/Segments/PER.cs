using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class PER : ANSISegmentBase
	{
		public string PER01_366 { get; set; }
		public string PER02_93 { get; set; }
		public string PER03_365 { get; set; }
		public string PER04_364 { get; set; }
		public string PER05_365 { get; set; }
		public string PER06_364 { get; set; }
		public string PER07_365 { get; set; }
		public string PER08_364 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PER01_366 = Helper.GetElementValue(valores, 1);
            this.PER02_93 = Helper.GetElementValue(valores, 2);
            this.PER03_365 = Helper.GetElementValue(valores, 3);
            this.PER04_364 = Helper.GetElementValue(valores, 4);
            this.PER05_365 = Helper.GetElementValue(valores, 5);
            this.PER06_364 = Helper.GetElementValue(valores, 6);
            this.PER07_365 = Helper.GetElementValue(valores, 7);
            this.PER08_364 = Helper.GetElementValue(valores, 8);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PER"
                                    , string.Format("PER{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{9}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PER01_366, Properties)
                                        , Helper.ReleaseValue(PER02_93, Properties)
                                        , Helper.ReleaseValue(PER03_365, Properties)
                                        , Helper.ReleaseValue(PER04_364, Properties)
                                        , Helper.ReleaseValue(PER05_365, Properties)
                                        , Helper.ReleaseValue(PER06_364, Properties)
                                        , Helper.ReleaseValue(PER07_365, Properties)
                                        , Helper.ReleaseValue(PER08_364, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}