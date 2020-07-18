using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G53 : ANSISegmentBase
	{
		public string G5301_875 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G5301_875 = Helper.GetElementValue(valores, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G53"
                                    , string.Format("G53{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G5301_875, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
