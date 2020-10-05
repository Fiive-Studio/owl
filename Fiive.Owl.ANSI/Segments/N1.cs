using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class N1 : ANSISegmentBase
	{
		public string N101_98 { get; set; }
		public string N102_93 { get; set; }
		public string N103_66 { get; set; }
		public string N104_67 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.N101_98 = Helper.GetElementValue(valores, 1);
            this.N102_93 = Helper.GetElementValue(valores, 2);
            this.N103_66 = Helper.GetElementValue(valores, 3);
            this.N104_67 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("N1"
                                    , string.Format("N1{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(N101_98, Properties)
                                        , Helper.ReleaseValue(N102_93, Properties)
                                        , Helper.ReleaseValue(N103_66, Properties)
                                        , Helper.ReleaseValue(N104_67, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
