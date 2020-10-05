using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class BSS : ANSISegmentBase
	{
		public string BSS01_353 { get; set; }
		public string BSS02_127 { get; set; }
		public string BSS03_373 { get; set; }
		public string BSS04_675 { get; set; }
		public string BSS05_373 { get; set; }
		public string BSS06_373 { get; set; }
		public string BSS07_328 { get; set; }
		public string BSS08_127 { get; set; }
		public string BSS09 { get; set; }
		public string BSS10_324 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BSS01_353 = Helper.GetElementValue(valores, 1);
            this.BSS02_127 = Helper.GetElementValue(valores, 2);
            this.BSS03_373 = Helper.GetElementValue(valores, 3);
            this.BSS04_675 = Helper.GetElementValue(valores, 4);
            this.BSS05_373 = Helper.GetElementValue(valores, 5);
            this.BSS06_373 = Helper.GetElementValue(valores, 6);
            this.BSS07_328 = Helper.GetElementValue(valores, 7);
            this.BSS08_127 = Helper.GetElementValue(valores, 8);
            this.BSS09 = Helper.GetElementValue(valores, 9);
            this.BSS10_324 = Helper.GetElementValue(valores, 10);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BSS"
                                    , string.Format("BSS{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{11}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BSS01_353, Properties)
                                        , Helper.ReleaseValue(BSS02_127, Properties)
                                        , Helper.ReleaseValue(BSS03_373, Properties)
                                        , Helper.ReleaseValue(BSS04_675, Properties)
                                        , Helper.ReleaseValue(BSS05_373, Properties)
                                        , Helper.ReleaseValue(BSS06_373, Properties)
                                        , Helper.ReleaseValue(BSS07_328, Properties)
                                        , Helper.ReleaseValue(BSS08_127, Properties)
                                        , Helper.ReleaseValue(BSS09, Properties)
                                        , Helper.ReleaseValue(BSS10_324, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}