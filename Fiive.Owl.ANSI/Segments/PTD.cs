using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class PTD : ANSISegmentBase
    {
        public string PTD01_521 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PTD01_521 = Helper.GetElementValue(valores, 1);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PTD"
                                    , string.Format("PTD{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PTD01_521, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
