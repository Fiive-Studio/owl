using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class PID : ANSISegmentBase
	{
		public string PID01_349 { get; set; }
		public string PID02 { get; set; }
		public string PID03 { get; set; }
		public string PID04 { get; set; }
        public string PID05_352 { get; set; }
        public string PID06 { get; set; }
        public string PID07 { get; set; }
        public string PID08 { get; set; }
        public string PID09 { get; set; }
        public string PID10 { get; set; }
        public string PID11 { get; set; }
        public string PID12 { get; set; }
        public string PID13 { get; set; }
        public string PID14 { get; set; }
        public string PID15 { get; set; }
        public string PID16 { get; set; }
        public string PID17 { get; set; }
        public string PID18 { get; set; }
        public string PID19 { get; set; }
        public string PID20 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PID01_349 = Helper.GetElementValue(valores, 1);
            this.PID02 = Helper.GetElementValue(valores, 2);
            this.PID03 = Helper.GetElementValue(valores, 3);
            this.PID04 = Helper.GetElementValue(valores, 4);
            this.PID05_352 = Helper.GetElementValue(valores, 5);
            this.PID06 = Helper.GetElementValue(valores, 6);
            this.PID07 = Helper.GetElementValue(valores, 7);
            this.PID08 = Helper.GetElementValue(valores, 8);
            this.PID09 = Helper.GetElementValue(valores, 9);
            this.PID10 = Helper.GetElementValue(valores, 10);
            this.PID11 = Helper.GetElementValue(valores, 11);
            this.PID12 = Helper.GetElementValue(valores, 12);
            this.PID13 = Helper.GetElementValue(valores, 13);
            this.PID14 = Helper.GetElementValue(valores, 14);
            this.PID15 = Helper.GetElementValue(valores, 15);
            this.PID16 = Helper.GetElementValue(valores, 16);
            this.PID17 = Helper.GetElementValue(valores, 17);
            this.PID18 = Helper.GetElementValue(valores, 18);
            this.PID19 = Helper.GetElementValue(valores, 19);
            this.PID20 = Helper.GetElementValue(valores, 20);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PID"
                                    , string.Format("PID{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{21}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PID01_349, Properties)
                                        , Helper.ReleaseValue(PID02, Properties)
                                        , Helper.ReleaseValue(PID03, Properties)
                                        , Helper.ReleaseValue(PID04, Properties)
                                        , Helper.ReleaseValue(PID05_352, Properties)
                                        , Helper.ReleaseValue(PID06, Properties)
                                        , Helper.ReleaseValue(PID07, Properties)
                                        , Helper.ReleaseValue(PID08, Properties)
                                        , Helper.ReleaseValue(PID09, Properties)
                                        , Helper.ReleaseValue(PID10, Properties)
                                        , Helper.ReleaseValue(PID11, Properties)
                                        , Helper.ReleaseValue(PID12, Properties)
                                        , Helper.ReleaseValue(PID13, Properties)
                                        , Helper.ReleaseValue(PID14, Properties)
                                        , Helper.ReleaseValue(PID15, Properties)
                                        , Helper.ReleaseValue(PID16, Properties)
                                        , Helper.ReleaseValue(PID17, Properties)
                                        , Helper.ReleaseValue(PID18, Properties)
                                        , Helper.ReleaseValue(PID19, Properties)
                                        , Helper.ReleaseValue(PID20, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
