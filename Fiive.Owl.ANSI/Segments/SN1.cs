using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class SN1 : ANSISegmentBase
	{
		public string SN101_350 { get; set; }
		public string SN102_382 { get; set; }
		public string SN103_355 { get; set; }
		public string SN104_646 { get; set; }
		public string SN105_330 { get; set; }
		public string SN106_355 { get; set; }
		public string SN107_728 { get; set; }
		public string SN108_668 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.SN101_350 = Helper.GetElementValue(valores, 1);
            this.SN102_382 = Helper.GetElementValue(valores, 2);
            this.SN103_355 = Helper.GetElementValue(valores, 3);
            this.SN104_646 = Helper.GetElementValue(valores, 4);
            this.SN105_330 = Helper.GetElementValue(valores, 5);
            this.SN106_355 = Helper.GetElementValue(valores, 6);
            this.SN107_728 = Helper.GetElementValue(valores, 7);
            this.SN108_668 = Helper.GetElementValue(valores, 8);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SN1"
                                    , string.Format("SN1{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{9}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(SN101_350, Properties)
                                        , Helper.ReleaseValue(SN102_382, Properties)
                                        , Helper.ReleaseValue(SN103_355, Properties)
                                        , Helper.ReleaseValue(SN104_646, Properties)
                                        , Helper.ReleaseValue(SN105_330, Properties)
                                        , Helper.ReleaseValue(SN106_355, Properties)
                                        , Helper.ReleaseValue(SN107_728, Properties)
                                        , Helper.ReleaseValue(SN108_668, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
