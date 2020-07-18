using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class FOB : ANSISegmentBase
	{

		public string FOB01_146 { get; set; }
		public string FOB02_309 { get; set; }
		public string FOB03_352 { get; set; }


		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.FOB01_146 = Helper.GetElementValue(valores, 1);
            this.FOB02_309 = Helper.GetElementValue(valores, 2);
            this.FOB03_352 = Helper.GetElementValue(valores, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("FOB"
                                    , string.Format("FOB{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(FOB01_146, Properties)
                                        , Helper.ReleaseValue(FOB02_309, Properties)
                                        , Helper.ReleaseValue(FOB03_352, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}