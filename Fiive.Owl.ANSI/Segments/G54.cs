using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class G54 : ANSISegmentBase
	{
		public string G5401_380 { get; set; }
		public string G5402_355 { get; set; }
		public string G5403_438 { get; set; }
		public string G5404_235 { get; set; }
		public string G5405_234 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G5401_380 = Helper.GetElementValue(valores, 1);
            this.G5402_355 = Helper.GetElementValue(valores, 2);
            this.G5403_438 = Helper.GetElementValue(valores, 3);
            this.G5404_235 = Helper.GetElementValue(valores, 4);
            this.G5405_234 = Helper.GetElementValue(valores, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G54"
                                    , string.Format("G54{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G5401_380, Properties)
                                        , Helper.ReleaseValue(G5402_355, Properties)
                                        , Helper.ReleaseValue(G5403_438, Properties)
                                        , Helper.ReleaseValue(G5404_235, Properties)
                                        , Helper.ReleaseValue(G5405_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
