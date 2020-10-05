using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class ITD : ANSISegmentBase
	{
        public string ITD01_336 { get; set; }
        public string ITD02_333 { get; set; }
        public string ITD03_338 { get; set; }
        public string ITD04_370 { get; set; }
        public string ITD05_351 { get; set; }
        public string ITD06_446 { get; set; }
        public string ITD07_386 { get; set; }
        public string ITD08 { get; set; }
        public string ITD09 { get; set; }
        public string ITD10 { get; set; }
        public string ITD11 { get; set; }
        public string ITD12_352 { get; set; }
        public string ITD13 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.ITD01_336 = Helper.GetElementValue(valores, 1);
            this.ITD02_333 = Helper.GetElementValue(valores, 2);
            this.ITD03_338 = Helper.GetElementValue(valores, 3);
            this.ITD04_370 = Helper.GetElementValue(valores, 4);
            this.ITD05_351 = Helper.GetElementValue(valores, 5);
            this.ITD06_446 = Helper.GetElementValue(valores, 6);
            this.ITD07_386 = Helper.GetElementValue(valores, 7);
            this.ITD08 = Helper.GetElementValue(valores, 8);
            this.ITD09 = Helper.GetElementValue(valores, 9);
            this.ITD10 = Helper.GetElementValue(valores, 10);
            this.ITD11 = Helper.GetElementValue(valores, 11);
            this.ITD12_352 = Helper.GetElementValue(valores, 12);
            this.ITD13 = Helper.GetElementValue(valores, 13);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ITD"
                                    , string.Format("ITD{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{14}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(ITD01_336, Properties)
                                        , Helper.ReleaseValue(ITD02_333, Properties)
                                        , Helper.ReleaseValue(ITD03_338, Properties)
                                        , Helper.ReleaseValue(ITD04_370, Properties)
                                        , Helper.ReleaseValue(ITD05_351, Properties)
                                        , Helper.ReleaseValue(ITD06_446, Properties)
                                        , Helper.ReleaseValue(ITD07_386, Properties)
                                        , Helper.ReleaseValue(ITD08, Properties)
                                        , Helper.ReleaseValue(ITD09, Properties)
                                        , Helper.ReleaseValue(ITD10, Properties)
                                        , Helper.ReleaseValue(ITD11, Properties)
                                        , Helper.ReleaseValue(ITD12_352, Properties)
                                        , Helper.ReleaseValue(ITD13, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
