using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class ZA : ANSISegmentBase
    {
        public string ZA01_859 { get; set; }
        public string ZA02_380 { get; set; }
        public string ZA03_355 { get; set; }
        public string ZA04_374 { get; set; }
        public string ZA05_373 { get; set; }
        public string ZA06_128 { get; set; }
        public string ZA07_127 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.ZA01_859 = Helper.GetElementValue(valores, 1);
            this.ZA02_380 = Helper.GetElementValue(valores, 2);
            this.ZA03_355 = Helper.GetElementValue(valores, 3);
            this.ZA04_374 = Helper.GetElementValue(valores, 4);
            this.ZA05_373 = Helper.GetElementValue(valores, 5);
            this.ZA06_128 = Helper.GetElementValue(valores, 6);
            this.ZA07_127 = Helper.GetElementValue(valores, 7);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ZA"
                                    , string.Format("ZA{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{8}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(ZA01_859, Properties)
                                        , Helper.ReleaseValue(ZA02_380, Properties)
                                        , Helper.ReleaseValue(ZA03_355, Properties)
                                        , Helper.ReleaseValue(ZA04_374, Properties)
                                        , Helper.ReleaseValue(ZA05_373, Properties)
                                        , Helper.ReleaseValue(ZA06_128, Properties)
                                        , Helper.ReleaseValue(ZA07_127, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
