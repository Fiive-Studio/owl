using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G55 : ANSISegmentBase
	{
		public string G5501_235 { get; set; }
		public string G5502_234 { get; set; }
		public string G5503_235 { get; set; }
		public string G5504_234 { get; set; }
		public string G5505 { get; set; }
		public string G5506 { get; set; }
		public string G5507 { get; set; }
		public string G5508 { get; set; }
		public string G5509 { get; set; }
		public string G5510 { get; set; }
		public string G5511 { get; set; }
		public string G5512 { get; set; }
		public string G5513 { get; set; }
		public string G5514 { get; set; }
		public string G5515 { get; set; }
		public string G5516 { get; set; }
		public string G5517 { get; set; }
		public string G5518 { get; set; }
		public string G5519 { get; set; }
		public string G5520 { get; set; }
		public string G5521 { get; set; }
		public string G5522 { get; set; }
		public string G5523 { get; set; }
		public string G5524 { get; set; }
		public string G5525 { get; set; }
		public string G5526 { get; set; }
		public string G5527 { get; set; }
		public string G5528 { get; set; }
		public string G5529_235 { get; set; }
		public string G5530_234 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G5501_235 = Helper.GetElementValue(valores, 1);
            this.G5502_234 = Helper.GetElementValue(valores, 2);
            this.G5503_235 = Helper.GetElementValue(valores, 3);
            this.G5504_234 = Helper.GetElementValue(valores, 4);
            this.G5505 = Helper.GetElementValue(valores, 5);
            this.G5506 = Helper.GetElementValue(valores, 6);
            this.G5507 = Helper.GetElementValue(valores, 7);
            this.G5508 = Helper.GetElementValue(valores, 8);
            this.G5509 = Helper.GetElementValue(valores, 9);
            this.G5510 = Helper.GetElementValue(valores, 10);
            this.G5511 = Helper.GetElementValue(valores, 11);
            this.G5512 = Helper.GetElementValue(valores, 12);
            this.G5513 = Helper.GetElementValue(valores, 13);
            this.G5514 = Helper.GetElementValue(valores, 14);
            this.G5515 = Helper.GetElementValue(valores, 15);
            this.G5516 = Helper.GetElementValue(valores, 16);
            this.G5517 = Helper.GetElementValue(valores, 17);
            this.G5518 = Helper.GetElementValue(valores, 18);
            this.G5519 = Helper.GetElementValue(valores, 19);
            this.G5520 = Helper.GetElementValue(valores, 20);
            this.G5521 = Helper.GetElementValue(valores, 21);
            this.G5522 = Helper.GetElementValue(valores, 22);
            this.G5523 = Helper.GetElementValue(valores, 23);
            this.G5524 = Helper.GetElementValue(valores, 24);
            this.G5525 = Helper.GetElementValue(valores, 25);
            this.G5526 = Helper.GetElementValue(valores, 26);
            this.G5527 = Helper.GetElementValue(valores, 27);
            this.G5528 = Helper.GetElementValue(valores, 28);
            this.G5529_235 = Helper.GetElementValue(valores, 29);
            this.G5530_234 = Helper.GetElementValue(valores, 30);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G55"
                                    , string.Format("G55{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{0}{21}{0}{22}{0}{23}{0}{24}{0}{25}{0}{26}{0}{27}{0}{28}{0}{29}{0}{30}{31}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G5501_235, Properties)
                                        , Helper.ReleaseValue(G5502_234, Properties)
                                        , Helper.ReleaseValue(G5503_235, Properties)
                                        , Helper.ReleaseValue(G5504_234, Properties)
                                        , Helper.ReleaseValue(G5505, Properties)
                                        , Helper.ReleaseValue(G5506, Properties)
                                        , Helper.ReleaseValue(G5507, Properties)
                                        , Helper.ReleaseValue(G5508, Properties)
                                        , Helper.ReleaseValue(G5509, Properties)
                                        , Helper.ReleaseValue(G5510, Properties)
                                        , Helper.ReleaseValue(G5511, Properties)
                                        , Helper.ReleaseValue(G5512, Properties)
                                        , Helper.ReleaseValue(G5513, Properties)
                                        , Helper.ReleaseValue(G5514, Properties)
                                        , Helper.ReleaseValue(G5515, Properties)
                                        , Helper.ReleaseValue(G5516, Properties)
                                        , Helper.ReleaseValue(G5517, Properties)
                                        , Helper.ReleaseValue(G5518, Properties)
                                        , Helper.ReleaseValue(G5519, Properties)
                                        , Helper.ReleaseValue(G5520, Properties)
                                        , Helper.ReleaseValue(G5521, Properties)
                                        , Helper.ReleaseValue(G5522, Properties)
                                        , Helper.ReleaseValue(G5523, Properties)
                                        , Helper.ReleaseValue(G5524, Properties)
                                        , Helper.ReleaseValue(G5525, Properties)
                                        , Helper.ReleaseValue(G5526, Properties)
                                        , Helper.ReleaseValue(G5527, Properties)
                                        , Helper.ReleaseValue(G5528, Properties)
                                        , Helper.ReleaseValue(G5529_235, Properties)
                                        , Helper.ReleaseValue(G5530_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
