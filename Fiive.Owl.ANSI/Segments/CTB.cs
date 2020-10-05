using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class CTB : ANSISegmentBase
    {
        public string CTB01_668 { get; set; }
        public string CTB02_352 { get; set; }
        public string CTB03_673 { get; set; }
        public string CTB04_380 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.CTB01_668 = Helper.GetElementValue(valores, 1);
            this.CTB02_352 = Helper.GetElementValue(valores, 2);
            this.CTB03_673 = Helper.GetElementValue(valores, 3);
            this.CTB04_380 = Helper.GetElementValue(valores, 4);


        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CTB"
                                    , string.Format("CTB{0}{1}{0}{2}{0}{3}{0}{4}{5}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(CTB01_668, Properties)
                                        , Helper.ReleaseValue(CTB02_352, Properties)
                                        , Helper.ReleaseValue(CTB03_673, Properties)
                                        , Helper.ReleaseValue(CTB04_380, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
