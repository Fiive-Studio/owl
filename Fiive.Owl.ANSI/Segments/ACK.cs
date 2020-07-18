using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.ANSI.Segments
{
    public class ACK : ANSISegmentBase
    {
        public string ACK01_668 { get; set; }
        public string ACK02_380 { get; set; }
        public string ACK03_355 { get; set; }
        public string ACK04_374 { get; set; }
        public string ACK05_373 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.ACK01_668 = Helper.GetElementValue(valores, 1);
            this.ACK02_380 = Helper.GetElementValue(valores, 2);
            this.ACK03_355 = Helper.GetElementValue(valores, 3);
            this.ACK04_374 = Helper.GetElementValue(valores, 4);
            this.ACK05_373 = Helper.GetElementValue(valores, 5);


        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ACK"
                                    , string.Format("ACK{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(ACK01_668, Properties)
                                        , Helper.ReleaseValue(ACK02_380, Properties)
                                        , Helper.ReleaseValue(ACK03_355, Properties)
                                        , Helper.ReleaseValue(ACK04_374, Properties)
                                        , Helper.ReleaseValue(ACK05_373, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
