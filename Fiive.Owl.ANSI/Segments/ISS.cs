using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class ISS : ANSISegmentBase
	{
		public string ISS01_382 { get; set; }
		public string ISS02_355 { get; set; }
		public string ISS03_383 { get; set; }
		public string ISS04_384 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.ISS01_382 = Helper.GetElementValue(valores, 1);
            this.ISS02_355 = Helper.GetElementValue(valores, 2);
            this.ISS03_383 = Helper.GetElementValue(valores, 3);
            this.ISS04_384 = Helper.GetElementValue(valores, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ISS"
                                    , string.Format("ISS{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(ISS01_382, Properties)
                                        , Helper.ReleaseValue(ISS02_355, Properties)
                                        , Helper.ReleaseValue(ISS03_383, Properties)
                                        , Helper.ReleaseValue(ISS04_384, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
