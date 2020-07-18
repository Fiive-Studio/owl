using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class PO4 : ANSISegmentBase
	{
		public string PO401_356 { get; set; }
		public string PO402_357 { get; set; }
		public string PO403_355 { get; set; }
		public string PO404 { get; set; }
		public string PO405 { get; set; }
		public string PO406 { get; set; }
		public string PO407 { get; set; }
		public string PO408 { get; set; }
		public string PO409 { get; set; }
		public string PO410 { get; set; }
		public string PO411 { get; set; }
		public string PO412 { get; set; }
		public string PO413 { get; set; }
		public string PO414 { get; set; }
		public string PO415 { get; set; }
		public string PO416_350 { get; set; }
		public string PO417_350 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PO401_356 = Helper.GetElementValue(valores, 1);
            this.PO402_357 = Helper.GetElementValue(valores, 2);
            this.PO403_355 = Helper.GetElementValue(valores, 3);
            this.PO404 = Helper.GetElementValue(valores, 4);
            this.PO405 = Helper.GetElementValue(valores, 5);
            this.PO406 = Helper.GetElementValue(valores, 6);
            this.PO407 = Helper.GetElementValue(valores, 7);
            this.PO408 = Helper.GetElementValue(valores, 8);
            this.PO409 = Helper.GetElementValue(valores, 9);
            this.PO410 = Helper.GetElementValue(valores, 10);
            this.PO411 = Helper.GetElementValue(valores, 11);
            this.PO412 = Helper.GetElementValue(valores, 12);
            this.PO413 = Helper.GetElementValue(valores, 13);
            this.PO414 = Helper.GetElementValue(valores, 14);
            this.PO415 = Helper.GetElementValue(valores, 15);
            this.PO416_350 = Helper.GetElementValue(valores, 16);
            this.PO417_350 = Helper.GetElementValue(valores, 17);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PO4"
                                    , string.Format("PO4{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{18}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PO401_356, Properties)
                                        , Helper.ReleaseValue(PO402_357, Properties)
                                        , Helper.ReleaseValue(PO403_355, Properties)
                                        , Helper.ReleaseValue(PO404, Properties)
                                        , Helper.ReleaseValue(PO405, Properties)
                                        , Helper.ReleaseValue(PO406, Properties)
                                        , Helper.ReleaseValue(PO407, Properties)
                                        , Helper.ReleaseValue(PO408, Properties)
                                        , Helper.ReleaseValue(PO409, Properties)
                                        , Helper.ReleaseValue(PO410, Properties)
                                        , Helper.ReleaseValue(PO411, Properties)
                                        , Helper.ReleaseValue(PO412, Properties)
                                        , Helper.ReleaseValue(PO413, Properties)
                                        , Helper.ReleaseValue(PO414, Properties)
                                        , Helper.ReleaseValue(PO415, Properties)
                                        , Helper.ReleaseValue(PO416_350, Properties)
                                        , Helper.ReleaseValue(PO417_350, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
