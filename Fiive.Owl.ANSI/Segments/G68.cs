using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G68 : ANSISegmentBase
	{
        public string G6801_380 { get; set; }
        public string G6802_355 { get; set; }
        public string G6803_237 { get; set; }
        public string G6804_438 { get; set; }
        public string G6805_235 { get; set; }
        public string G6806_234 { get; set; }
        public string G6807_235 { get; set; }
        public string G6808_234 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G6801_380 = Helper.GetElementValue(valores, 1);
            this.G6802_355 = Helper.GetElementValue(valores, 2);
            this.G6803_237 = Helper.GetElementValue(valores, 3);
            this.G6804_438 = Helper.GetElementValue(valores, 4);
            this.G6805_235 = Helper.GetElementValue(valores, 5);
            this.G6806_234 = Helper.GetElementValue(valores, 6);
            this.G6807_235 = Helper.GetElementValue(valores, 7);
            this.G6808_234 = Helper.GetElementValue(valores, 8);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G68"
                                    , string.Format("G68{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{9}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G6801_380, Properties)
                                        , Helper.ReleaseValue(G6802_355, Properties)
                                        , Helper.ReleaseValue(G6803_237, Properties)
                                        , Helper.ReleaseValue(G6804_438, Properties)
                                        , Helper.ReleaseValue(G6805_235, Properties)
                                        , Helper.ReleaseValue(G6806_234, Properties)
                                        , Helper.ReleaseValue(G6807_235, Properties)
                                        , Helper.ReleaseValue(G6808_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
