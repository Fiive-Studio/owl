using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class MEA : ANSISegmentBase
	{
		public string MEA01_737 { get; set; }
		public string MEA02_738 { get; set; }
		public string MEA03_739 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.MEA01_737 = Helper.GetElementValue(valores, 1);
            this.MEA02_738 = Helper.GetElementValue(valores, 2);
            this.MEA03_739 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MEA"
                                    , string.Format("MEA{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(MEA01_737, Properties)
                                        , Helper.ReleaseValue(MEA02_738, Properties)
                                        , Helper.ReleaseValue(MEA03_739, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
