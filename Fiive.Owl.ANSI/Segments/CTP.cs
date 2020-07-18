using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class CTP : ANSISegmentBase
	{

		public string CTP01 { get; set; }
		public string CTP02 { get; set; }
		public string CTP03 { get; set; }
		public string CTP04 { get; set; }
		public string CTP05 { get; set; }
		public string CTP06 { get; set; }
		public string CTP07 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.CTP01 = Helper.GetElementValue(valores, 1);
            this.CTP02 = Helper.GetElementValue(valores, 2);
            this.CTP03 = Helper.GetElementValue(valores, 3);
            this.CTP04 = Helper.GetElementValue(valores, 4);
            this.CTP05 = Helper.GetElementValue(valores, 5);
            this.CTP06 = Helper.GetElementValue(valores, 6);
            this.CTP07 = Helper.GetElementValue(valores, 7);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CTP"
                                    , string.Format("CTP{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{8}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(CTP01, Properties)
                                        , Helper.ReleaseValue(CTP02, Properties)
                                        , Helper.ReleaseValue(CTP03, Properties)
                                        , Helper.ReleaseValue(CTP04, Properties)
                                        , Helper.ReleaseValue(CTP05, Properties)
                                        , Helper.ReleaseValue(CTP06, Properties)
                                        , Helper.ReleaseValue(CTP07, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}