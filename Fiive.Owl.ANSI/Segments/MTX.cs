using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class MTX : ANSISegmentBase
    {
        public string MTX01_363 { get; set; }
        public string MTX02_1551 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.MTX01_363 = Helper.GetElementValue(valores, 1);
            this.MTX02_1551 = Helper.GetElementValue(valores, 2);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MTX"
                                    , string.Format("MTX{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(MTX01_363, Properties)
                                        , Helper.ReleaseValue(MTX02_1551, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
