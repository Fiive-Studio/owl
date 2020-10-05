using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class PAD : ANSISegmentBase
    {
        public string PAD01_350 { get; set; }
        public string PAD02_521 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PAD01_350 = Helper.GetElementValue(valores, 1);
            this.PAD02_521 = Helper.GetElementValue(valores, 2);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PAD"
                                    , string.Format("PAD{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PAD01_350, Properties)
                                        , Helper.ReleaseValue(PAD02_521, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
