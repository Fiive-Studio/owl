using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class BPT : ANSISegmentBase
    {
        public string BPT01_353 { get; set; }
        public string BPT02_127 { get; set; }
        public string BPT03_373 { get; set; }
        public string BPT04_755 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BPT01_353 = Helper.GetElementValue(valores, 1);
            this.BPT02_127 = Helper.GetElementValue(valores, 2);
            this.BPT03_373 = Helper.GetElementValue(valores, 3);
            this.BPT04_755 = Helper.GetElementValue(valores, 4);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BPT"
                                    , string.Format("BPT{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BPT01_353, Properties)
                                        , Helper.ReleaseValue(BPT02_127, Properties)
                                        , Helper.ReleaseValue(BPT03_373, Properties)
                                        , Helper.ReleaseValue(BPT04_755, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
