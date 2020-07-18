using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class CTT : ANSISegmentBase
	{
		public string CTT01_354 { get; set; }
        public string CTT02_347 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.CTT01_354 = Helper.GetElementValue(valores, 1);
            this.CTT02_347 = Helper.GetElementValue(valores, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CTT"
                                    , string.Format("CTT{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(CTT01_354, Properties)
                                        , Helper.ReleaseValue(CTT02_347, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}