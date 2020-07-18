using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class N4 : ANSISegmentBase
	{
		public string N401_19 { get; set; }
		public string N402_156 { get; set; }
		public string N403_116 { get; set; }
		public string N404_26 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.N401_19 = Helper.GetElementValue(valores, 1);
            this.N402_156 = Helper.GetElementValue(valores, 2);
            this.N403_116 = Helper.GetElementValue(valores, 3);
            this.N404_26 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("N4"
                                    , string.Format("N4{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(N401_19, Properties)
                                        , Helper.ReleaseValue(N402_156, Properties)
                                        , Helper.ReleaseValue(N403_116, Properties)
                                        , Helper.ReleaseValue(N404_26, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
