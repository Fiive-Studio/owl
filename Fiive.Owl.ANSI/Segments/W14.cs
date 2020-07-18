using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W14 : ANSISegmentBase
	{
		public string W1401_413 { get; set; }
		public string W1402_382 { get; set; }
		public string W1403_452 { get; set; }
		public string W1404_414 { get; set; }
		public string W1405_80 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W1401_413 = Helper.GetElementValue(valores, 1);
            this.W1402_382 = Helper.GetElementValue(valores, 2);
            this.W1403_452 = Helper.GetElementValue(valores, 3);
            this.W1404_414 = Helper.GetElementValue(valores, 4);
            this.W1405_80 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W14"
                                    , string.Format("W14{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W1401_413, Properties)
                                        , Helper.ReleaseValue(W1402_382, Properties)
                                        , Helper.ReleaseValue(W1403_452, Properties)
                                        , Helper.ReleaseValue(W1404_414, Properties)
                                        , Helper.ReleaseValue(W1405_80, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
