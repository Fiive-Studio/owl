using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class PKG : ANSISegmentBase
	{
        public string PKG01_349 { get; set; }
        public string PKG02_753 { get; set; }
        public string PKG03_559 { get; set; }
        public string PKG04_754 { get; set; }
        public string PKG05_352 { get; set; }
        public string PKG06_400 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PKG01_349 = Helper.GetElementValue(valores, 1);
            this.PKG02_753 = Helper.GetElementValue(valores, 2);
            this.PKG03_559 = Helper.GetElementValue(valores, 3);
            this.PKG04_754 = Helper.GetElementValue(valores, 4);
            this.PKG05_352 = Helper.GetElementValue(valores, 5);
            this.PKG06_400 = Helper.GetElementValue(valores, 6);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PKG"
                                    , string.Format("PKG{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PKG01_349, Properties)
                                        , Helper.ReleaseValue(PKG02_753, Properties)
                                        , Helper.ReleaseValue(PKG03_559, Properties)
                                        , Helper.ReleaseValue(PKG04_754, Properties)
                                        , Helper.ReleaseValue(PKG05_352, Properties)
                                        , Helper.ReleaseValue(PKG06_400, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
