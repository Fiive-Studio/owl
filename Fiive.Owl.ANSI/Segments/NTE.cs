using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class NTE : ANSISegmentBase
	{
		public string NTE01_363 { get; set; }
		public string NTE02_352 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.NTE01_363 = Helper.GetElementValue(valores, 1);
            this.NTE02_352 = Helper.GetElementValue(valores, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("NTE"
                                    , string.Format("NTE{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(NTE01_363, Properties)
                                        , Helper.ReleaseValue(NTE02_352, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
