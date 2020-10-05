using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class CON_ : ANSISegmentBase
    {
        public string CON01_128 { get; set; }
        public string CON02_127 { get; set; }
        public string CON03_846 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.CON01_128 = Helper.GetElementValue(valores, 1);
            this.CON02_127 = Helper.GetElementValue(valores, 2);
            this.CON03_846 = Helper.GetElementValue(valores, 3);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CON"
                                    , string.Format("CON{0}{1}{0}{2}{0}{3}{4}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(CON01_128, Properties)
                                        , Helper.ReleaseValue(CON02_127, Properties)
                                        , Helper.ReleaseValue(CON03_846, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
