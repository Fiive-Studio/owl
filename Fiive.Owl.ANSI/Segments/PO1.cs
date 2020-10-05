using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

    public class PO1 : ANSISegmentBase
    {
        public string PO101_350 { get; set; }
        public string PO102_330 { get; set; }
        public string PO103_355 { get; set; }
        public string PO104_212 { get; set; }
        public string PO105_639 { get; set; }
        public string PO106_235 { get; set; }
        public string PO107_234 { get; set; }
        public string PO108_235 { get; set; }
        public string PO109_234 { get; set; }
        public string PO110_235 { get; set; }
        public string PO111_234 { get; set; }
        public string PO112_235 { get; set; }
        public string PO113_234 { get; set; }
        public string PO114_235 { get; set; }
        public string PO115_234 { get; set; }
        public string PO116_235 { get; set; }
        public string PO117_234 { get; set; }
        public string PO118_235 { get; set; }
        public string PO119_234 { get; set; }
        public string PO120_235 { get; set; }
        public string PO121_234 { get; set; }
        public string PO122_235 { get; set; }
        public string PO123_234 { get; set; }
        public string PO124_235 { get; set; }
        public string PO125_234 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<string> valores = Helper.ProcessSegment(content, Properties);

            this.PO101_350 = Helper.GetElementValue(valores, 1);
            this.PO102_330 = Helper.GetElementValue(valores, 2);
            this.PO103_355 = Helper.GetElementValue(valores, 3);
            this.PO104_212 = Helper.GetElementValue(valores, 4);
            this.PO105_639 = Helper.GetElementValue(valores, 5);
            this.PO106_235 = Helper.GetElementValue(valores, 6);
            this.PO107_234 = Helper.GetElementValue(valores, 7);
            this.PO108_235 = Helper.GetElementValue(valores, 8);
            this.PO109_234 = Helper.GetElementValue(valores, 9);
            this.PO110_235 = Helper.GetElementValue(valores, 10);
            this.PO111_234 = Helper.GetElementValue(valores, 11);
            this.PO112_235 = Helper.GetElementValue(valores, 12);
            this.PO113_234 = Helper.GetElementValue(valores, 13);
            this.PO114_235 = Helper.GetElementValue(valores, 14);
            this.PO115_234 = Helper.GetElementValue(valores, 15);
            this.PO116_235 = Helper.GetElementValue(valores, 16);
            this.PO117_234 = Helper.GetElementValue(valores, 17);
            this.PO118_235 = Helper.GetElementValue(valores, 18);
            this.PO119_234 = Helper.GetElementValue(valores, 19);
            this.PO120_235 = Helper.GetElementValue(valores, 20);
            this.PO121_234 = Helper.GetElementValue(valores, 21);
            this.PO122_235 = Helper.GetElementValue(valores, 22);
            this.PO123_234 = Helper.GetElementValue(valores, 23);
            this.PO124_235 = Helper.GetElementValue(valores, 24);
            this.PO125_234 = Helper.GetElementValue(valores, 25);

        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PO1"
                                    , string.Format("PO1{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{0}{21}{0}{22}{0}{23}{0}{24}{0}{25}{26}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(PO101_350, Properties)
                                        , Helper.ReleaseValue(PO102_330, Properties)
                                        , Helper.ReleaseValue(PO103_355, Properties)
                                        , Helper.ReleaseValue(PO104_212, Properties)
                                        , Helper.ReleaseValue(PO105_639, Properties)
                                        , Helper.ReleaseValue(PO106_235, Properties)
                                        , Helper.ReleaseValue(PO107_234, Properties)
                                        , Helper.ReleaseValue(PO108_235, Properties)
                                        , Helper.ReleaseValue(PO109_234, Properties)
                                        , Helper.ReleaseValue(PO110_235, Properties)
                                        , Helper.ReleaseValue(PO111_234, Properties)
                                        , Helper.ReleaseValue(PO112_235, Properties)
                                        , Helper.ReleaseValue(PO113_234, Properties)
                                        , Helper.ReleaseValue(PO114_235, Properties)
                                        , Helper.ReleaseValue(PO115_234, Properties)
                                        , Helper.ReleaseValue(PO116_235, Properties)
                                        , Helper.ReleaseValue(PO117_234, Properties)
                                        , Helper.ReleaseValue(PO118_235, Properties)
                                        , Helper.ReleaseValue(PO119_234, Properties)
                                        , Helper.ReleaseValue(PO120_235, Properties)
                                        , Helper.ReleaseValue(PO121_234, Properties)
                                        , Helper.ReleaseValue(PO122_235, Properties)
                                        , Helper.ReleaseValue(PO123_234, Properties)
                                        , Helper.ReleaseValue(PO124_235, Properties)
                                        , Helper.ReleaseValue(PO125_234, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
    }
}
