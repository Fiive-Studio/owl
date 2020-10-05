using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class N9 : ANSISegmentBase
	{
		public string N901_128 { get; set; }
		public string N902_127 { get; set; }
		public string N903_369 { get; set; }
		public string N904_373 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.N901_128 = Helper.GetElementValue(valores, 1);
            this.N902_127 = Helper.GetElementValue(valores, 2);
            this.N903_369 = Helper.GetElementValue(valores, 3);
            this.N904_373 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("N9"
                                    , string.Format("N9{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(N901_128, Properties)
                                        , Helper.ReleaseValue(N902_127, Properties)
                                        , Helper.ReleaseValue(N903_369, Properties)
                                        , Helper.ReleaseValue(N904_373, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
