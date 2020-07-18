using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class B2A : ANSISegmentBase
	{
		public string B2A01_353 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.B2A01_353 = Helper.GetElementValue(valores, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("B2A"
                                    , string.Format("B2A{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(B2A01_353, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
