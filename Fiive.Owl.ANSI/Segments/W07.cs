using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W07 : ANSISegmentBase
	{
		public string W0701_413 { get; set; }
		public string W0702_355 { get; set; }
		public string W0703_438 { get; set; }
		public string W0704_235 { get; set; }
		public string W0705_234 { get; set; }
		public string W0706_235 { get; set; }
		public string W0707_234 { get; set; }
		public string W0708_451 { get; set; }
		public string W0709_893 { get; set; }
		public string W0710_235 { get; set; }
		public string W0711_234 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W0701_413 = Helper.GetElementValue(valores, 1);
            this.W0702_355 = Helper.GetElementValue(valores, 2);
            this.W0703_438 = Helper.GetElementValue(valores, 3);
            this.W0704_235 = Helper.GetElementValue(valores, 4);
            this.W0705_234 = Helper.GetElementValue(valores, 5);
            this.W0706_235 = Helper.GetElementValue(valores, 6);
            this.W0707_234 = Helper.GetElementValue(valores, 7);
            this.W0708_451 = Helper.GetElementValue(valores, 8);
            this.W0709_893 = Helper.GetElementValue(valores, 9);
            this.W0710_235 = Helper.GetElementValue(valores, 10);
            this.W0711_234 = Helper.GetElementValue(valores, 11);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W07"
                                    , string.Format("W07{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{12}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W0701_413, Properties)
                                        , Helper.ReleaseValue(W0702_355, Properties)
                                        , Helper.ReleaseValue(W0703_438, Properties)
                                        , Helper.ReleaseValue(W0704_235, Properties)
                                        , Helper.ReleaseValue(W0705_234, Properties)
                                        , Helper.ReleaseValue(W0706_235, Properties)
                                        , Helper.ReleaseValue(W0707_234, Properties)
                                        , Helper.ReleaseValue(W0708_451, Properties)
                                        , Helper.ReleaseValue(W0709_893, Properties)
                                        , Helper.ReleaseValue(W0710_235, Properties)
                                        , Helper.ReleaseValue(W0711_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
