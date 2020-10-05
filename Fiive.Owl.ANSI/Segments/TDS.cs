using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class TDS : ANSISegmentBase
	{
		public string TDS01_610 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.TDS01_610 = Helper.GetElementValue(valores, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TDS"
                                    , string.Format("TDS{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(TDS01_610, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
