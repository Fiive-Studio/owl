using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class N2 : ANSISegmentBase
	{
		public string N201_93 { get; set; }
		public string N202_93 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.N201_93 = Helper.GetElementValue(valores, 1);
            this.N202_93 = Helper.GetElementValue(valores, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("N2"
                                    , string.Format("N2{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(N201_93, Properties)
                                        , Helper.ReleaseValue(N202_93, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
