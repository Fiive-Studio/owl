using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class SE : ANSISegmentBase
	{
		public string SE01_96 { get; set; }
		public string SE02_329 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.SE01_96 = Helper.GetElementValue(valores, 1);
            this.SE02_329 = Helper.GetElementValue(valores, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SE"
                                    , string.Format("SE{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(SE01_96, Properties)
                                        , Helper.ReleaseValue(SE02_329, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
