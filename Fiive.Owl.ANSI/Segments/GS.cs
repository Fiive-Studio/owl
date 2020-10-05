using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class GS : ANSISegmentBase
	{
		public string GS01_479 { get; set; }
		public string GS02_142 { get; set; }
		public string GS03_124 { get; set; }
		public string GS04_373 { get; set; }
		public string GS05_337 { get; set; }
		public string GS06_28 { get; set; }
		public string GS07_455 { get; set; }
		public string GS08_480 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.GS01_479 = Helper.GetElementValue(valores, 1);
            this.GS02_142 = Helper.GetElementValue(valores, 2);
            this.GS03_124 = Helper.GetElementValue(valores, 3);
            this.GS04_373 = Helper.GetElementValue(valores, 4);
            this.GS05_337 = Helper.GetElementValue(valores, 5);
            this.GS06_28 = Helper.GetElementValue(valores, 6);
            this.GS07_455 = Helper.GetElementValue(valores, 7);
            this.GS08_480 = Helper.GetElementValue(valores, 8);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("GS"
                                    , string.Format("GS{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{9}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(GS01_479, Properties)
                                        , Helper.ReleaseValue(GS02_142, Properties)
                                        , Helper.ReleaseValue(GS03_124, Properties)
                                        , Helper.ReleaseValue(GS04_373, Properties)
                                        , Helper.ReleaseValue(GS05_337, Properties)
                                        , Helper.ReleaseValue(GS06_28, Properties)
                                        , Helper.ReleaseValue(GS07_455, Properties)
                                        , Helper.ReleaseValue(GS08_480, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
