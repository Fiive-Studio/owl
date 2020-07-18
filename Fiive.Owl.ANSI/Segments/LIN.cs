using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

    public class LIN : ANSISegmentBase
    {

        public string LIN01_350 { get; set; }
        public string LIN02_235 { get; set; }
        public string LIN03_234 { get; set; }
        public string LIN04_235 { get; set; }
        public string LIN05_234 { get; set; }
        public string LIN06_235 { get; set; }
        public string LIN07_234 { get; set; }
        public string LIN08_235 { get; set; }
        public string LIN09_234 { get; set; }
        public string LIN10_235 { get; set; }
        public string LIN11_234 { get; set; }
        public string LIN12_235 { get; set; }
        public string LIN13_234 { get; set; }
        public string LIN14_235 { get; set; }
        public string LIN15_234 { get; set; }
        public string LIN16_235 { get; set; }
        public string LIN17_234 { get; set; }
        public string LIN18_235 { get; set; }
        public string LIN19_234 { get; set; }
        public string LIN20_235 { get; set; }
        public string LIN21_234 { get; set; }
        public string LIN22_235 { get; set; }
        public string LIN23_234 { get; set; }
        public string LIN24_235 { get; set; }
        public string LIN25_234 { get; set; }
        public string LIN26_235 { get; set; }
        public string LIN27_234 { get; set; }
        public string LIN28_235 { get; set; }
        public string LIN29_234 { get; set; }
        public string LIN30_235 { get; set; }
        public string LIN31_234 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.LIN01_350 = Helper.GetElementValue(valores, 1);
            this.LIN02_235 = Helper.GetElementValue(valores, 2);
            this.LIN03_234 = Helper.GetElementValue(valores, 3);
            this.LIN04_235 = Helper.GetElementValue(valores, 4);
            this.LIN05_234 = Helper.GetElementValue(valores, 5);
            this.LIN06_235 = Helper.GetElementValue(valores, 6);
            this.LIN07_234 = Helper.GetElementValue(valores, 7);
            this.LIN08_235 = Helper.GetElementValue(valores, 8);
            this.LIN09_234 = Helper.GetElementValue(valores, 9);
            this.LIN10_235 = Helper.GetElementValue(valores, 10);
            this.LIN11_234 = Helper.GetElementValue(valores, 11);
            this.LIN12_235 = Helper.GetElementValue(valores, 12);
            this.LIN13_234 = Helper.GetElementValue(valores, 13);
            this.LIN14_235 = Helper.GetElementValue(valores, 14);
            this.LIN15_234 = Helper.GetElementValue(valores, 15);
            this.LIN16_235 = Helper.GetElementValue(valores, 16);
            this.LIN17_234 = Helper.GetElementValue(valores, 17);
            this.LIN18_235 = Helper.GetElementValue(valores, 18);
            this.LIN19_234 = Helper.GetElementValue(valores, 19);
            this.LIN20_235 = Helper.GetElementValue(valores, 20);
            this.LIN21_234 = Helper.GetElementValue(valores, 21);
            this.LIN22_235 = Helper.GetElementValue(valores, 22);
            this.LIN23_234 = Helper.GetElementValue(valores, 23);
            this.LIN24_235 = Helper.GetElementValue(valores, 24);
            this.LIN25_234 = Helper.GetElementValue(valores, 25);
            this.LIN26_235 = Helper.GetElementValue(valores, 26);
            this.LIN27_234 = Helper.GetElementValue(valores, 27);
            this.LIN28_235 = Helper.GetElementValue(valores, 28);
            this.LIN29_234 = Helper.GetElementValue(valores, 29);
            this.LIN30_235 = Helper.GetElementValue(valores, 30);
            this.LIN31_234 = Helper.GetElementValue(valores, 31);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("LIN"
                                    , string.Format("LIN{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{0}{21}{0}{22}{0}{23}{0}{24}{0}{25}{0}{26}{0}{27}{0}{28}{0}{29}{0}{30}{0}{31}{32}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(LIN01_350, Properties)
                                        , Helper.ReleaseValue(LIN02_235, Properties)
                                        , Helper.ReleaseValue(LIN03_234, Properties)
                                        , Helper.ReleaseValue(LIN04_235, Properties)
                                        , Helper.ReleaseValue(LIN05_234, Properties)
                                        , Helper.ReleaseValue(LIN06_235, Properties)
                                        , Helper.ReleaseValue(LIN07_234, Properties)
                                        , Helper.ReleaseValue(LIN08_235, Properties)
                                        , Helper.ReleaseValue(LIN09_234, Properties)
                                        , Helper.ReleaseValue(LIN10_235, Properties)
                                        , Helper.ReleaseValue(LIN11_234, Properties)
                                        , Helper.ReleaseValue(LIN12_235, Properties)
                                        , Helper.ReleaseValue(LIN13_234, Properties)
                                        , Helper.ReleaseValue(LIN14_235, Properties)
                                        , Helper.ReleaseValue(LIN15_234, Properties)
                                        , Helper.ReleaseValue(LIN16_235, Properties)
                                        , Helper.ReleaseValue(LIN17_234, Properties)
                                        , Helper.ReleaseValue(LIN18_235, Properties)
                                        , Helper.ReleaseValue(LIN19_234, Properties)
                                        , Helper.ReleaseValue(LIN20_235, Properties)
                                        , Helper.ReleaseValue(LIN21_234, Properties)
                                        , Helper.ReleaseValue(LIN22_235, Properties)
                                        , Helper.ReleaseValue(LIN23_234, Properties)
                                        , Helper.ReleaseValue(LIN24_235, Properties)
                                        , Helper.ReleaseValue(LIN25_234, Properties)
                                        , Helper.ReleaseValue(LIN26_235, Properties)
                                        , Helper.ReleaseValue(LIN27_234, Properties)
                                        , Helper.ReleaseValue(LIN28_235, Properties)
                                        , Helper.ReleaseValue(LIN29_234, Properties)
                                        , Helper.ReleaseValue(LIN30_235, Properties)
                                        , Helper.ReleaseValue(LIN31_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}