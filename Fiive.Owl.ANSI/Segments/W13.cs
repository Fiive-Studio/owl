using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W13 : ANSISegmentBase
	{
		public string W1301_380 { get; set; }
		public string W1302_355 { get; set; }
		public string W1303_412 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W1301_380 = Helper.GetElementValue(valores, 1);
            this.W1302_355 = Helper.GetElementValue(valores, 2);
            this.W1303_412 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W13"
                                    , string.Format("W13{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W1301_380, Properties)
                                        , Helper.ReleaseValue(W1302_355, Properties)
                                        , Helper.ReleaseValue(W1303_412, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
