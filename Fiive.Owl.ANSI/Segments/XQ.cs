using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class XQ : ANSISegmentBase
    {
        public string XQ01_305 { get; set; }
        public string XQ02_373 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.XQ01_305 = Helper.GetElementValue(valores, 1);
            this.XQ02_373 = Helper.GetElementValue(valores, 2);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("XQ"
                                    , string.Format("XQ{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(XQ01_305, Properties)
                                        , Helper.ReleaseValue(XQ02_373, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
