using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class BPA : ANSISegmentBase
    {
        public string BPA01_353 { get; set; }
        public string BPA02_373 { get; set; }
        public string BPA03_128 { get; set; }
        public string BPA04_127 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BPA01_353 = Helper.GetElementValue(valores, 1);
            this.BPA02_373 = Helper.GetElementValue(valores, 2);
            this.BPA03_128 = Helper.GetElementValue(valores, 3);
            this.BPA04_127 = Helper.GetElementValue(valores, 4);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BPA"
                                    , string.Format("BPA{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BPA01_353, Properties)
                                        , Helper.ReleaseValue(BPA02_373, Properties)
                                        , Helper.ReleaseValue(BPA03_128, Properties)
                                        , Helper.ReleaseValue(BPA04_127, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
