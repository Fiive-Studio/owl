using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class BAA : ANSISegmentBase
    {
        public string BAA01_353 { get; set; }
        public string BAA02_640 { get; set; }
        public string BAA03_373 { get; set; }
        public string BAA04_128 { get; set; }
        public string BAA05_127 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BAA01_353 = Helper.GetElementValue(valores, 1);
            this.BAA02_640 = Helper.GetElementValue(valores, 2);
            this.BAA03_373 = Helper.GetElementValue(valores, 3);
            this.BAA04_128 = Helper.GetElementValue(valores, 3);
            this.BAA05_127 = Helper.GetElementValue(valores, 3);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BAA"
                                    , string.Format("BAA{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BAA01_353, Properties)
                                        , Helper.ReleaseValue(BAA02_640, Properties)
                                        , Helper.ReleaseValue(BAA03_373, Properties)
                                        , Helper.ReleaseValue(BAA04_128, Properties)
                                        , Helper.ReleaseValue(BAA05_127, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
