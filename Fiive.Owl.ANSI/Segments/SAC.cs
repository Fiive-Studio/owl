using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class SAC : ANSISegmentBase
	{
		public string SAC01_248 { get; set; }
		public string SAC02_1300 { get; set; }
		public string SAC03_559 { get; set; }
		public string SAC04_1301 { get; set; }
		public string SAC05_610 { get; set; }
		public string SAC06_378 { get; set; }
		public string SAC07_332 { get; set; }
		public string SAC08_118 { get; set; }
		public string SAC09_355 { get; set; }
		public string SAC10_380 { get; set; }
		public string SAC11_380 { get; set; }
		public string SAC12_331 { get; set; }
		public string SAC13_127 { get; set; }
		public string SAC14_770 { get; set; }
		public string SAC15_352 { get; set; }
		public string SAC16_819 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.SAC01_248 = Helper.GetElementValue(valores, 1);
            this.SAC02_1300 = Helper.GetElementValue(valores, 2);
            this.SAC03_559 = Helper.GetElementValue(valores, 3);
            this.SAC04_1301 = Helper.GetElementValue(valores, 4);
            this.SAC05_610 = Helper.GetElementValue(valores, 5);
            this.SAC06_378 = Helper.GetElementValue(valores, 6);
            this.SAC07_332 = Helper.GetElementValue(valores, 7);
            this.SAC08_118 = Helper.GetElementValue(valores, 8);
            this.SAC09_355 = Helper.GetElementValue(valores, 9);
            this.SAC10_380 = Helper.GetElementValue(valores, 10);
            this.SAC11_380 = Helper.GetElementValue(valores, 11);
            this.SAC12_331 = Helper.GetElementValue(valores, 12);
            this.SAC13_127 = Helper.GetElementValue(valores, 13);
            this.SAC14_770 = Helper.GetElementValue(valores, 14);
            this.SAC15_352 = Helper.GetElementValue(valores, 15);
            this.SAC16_819 = Helper.GetElementValue(valores, 16);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SAC"
                                    , string.Format("SAC{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{17}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(SAC01_248, Properties)
                                        , Helper.ReleaseValue(SAC02_1300, Properties)
                                        , Helper.ReleaseValue(SAC03_559, Properties)
                                        , Helper.ReleaseValue(SAC04_1301, Properties)
                                        , Helper.ReleaseValue(SAC05_610, Properties)
                                        , Helper.ReleaseValue(SAC06_378, Properties)
                                        , Helper.ReleaseValue(SAC07_332, Properties)
                                        , Helper.ReleaseValue(SAC08_118, Properties)
                                        , Helper.ReleaseValue(SAC09_355, Properties)
                                        , Helper.ReleaseValue(SAC10_380, Properties)
                                        , Helper.ReleaseValue(SAC11_380, Properties)
                                        , Helper.ReleaseValue(SAC12_331, Properties)
                                        , Helper.ReleaseValue(SAC13_127, Properties)
                                        , Helper.ReleaseValue(SAC14_770, Properties)
                                        , Helper.ReleaseValue(SAC15_352, Properties)
                                        , Helper.ReleaseValue(SAC16_819, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
