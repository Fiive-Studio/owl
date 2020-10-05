using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G62 : ANSISegmentBase
	{
		public string G6201_432 { get; set; }
		public string G6202_373 { get; set; }
		public string G6203_176 { get; set; }
		public string G6204_337 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G6201_432 = Helper.GetElementValue(valores, 1);
            this.G6202_373 = Helper.GetElementValue(valores, 2);
            this.G6203_176 = Helper.GetElementValue(valores, 3);
            this.G6204_337 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G62"
                                    , string.Format("G62{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G6201_432, Properties)
                                        , Helper.ReleaseValue(G6202_373, Properties)
                                        , Helper.ReleaseValue(G6203_176, Properties)
                                        , Helper.ReleaseValue(G6204_337, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
