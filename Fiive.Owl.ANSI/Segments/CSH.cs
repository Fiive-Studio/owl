using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class CSH : ANSISegmentBase
	{
		public string CSH01_563 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.CSH01_563 = Helper.GetElementValue(valores, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CSH"
                                    , string.Format("CSH{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(CSH01_563, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
