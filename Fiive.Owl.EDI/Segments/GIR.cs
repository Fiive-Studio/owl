using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento GIR</summary>
    public class GIR : EDISegmentBase
    {
        #region 7297

        public string GIR_7297 { get; set; }

        #endregion // Fin-4465

        #region C206

        public string GIR_C206_7402 { get; set; }
        public string GIR_C206_7405 { get; set; }
        public string GIR_C206_4405 { get; set; }

        #endregion // Fin-1082

        #region C206

        public string GIR_C206_7402_2 { get; set; }
        public string GIR_C206_7405_2 { get; set; }
        public string GIR_C206_4405_2 { get; set; }

        #endregion // Fin-1082

        #region C206

        public string GIR_C206_7402_3 { get; set; }
        public string GIR_C206_7405_3 { get; set; }
        public string GIR_C206_4405_3 { get; set; }

        #endregion // Fin-1082

        #region C206

        public string GIR_C206_7402_4 { get; set; }
        public string GIR_C206_7405_4 { get; set; }
        public string GIR_C206_4405_4 { get; set; }

        #endregion // Fin-1082

        #region C206

        public string GIR_C206_7402_5 { get; set; }
        public string GIR_C206_7405_5 { get; set; }
        public string GIR_C206_4405_5 { get; set; }

        #endregion // Fin-1082

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.GIR_7297 = Helper.GetElementValue(valores, 1, 0);
            this.GIR_C206_7402 = Helper.GetElementValue(valores, 2, 0);
            this.GIR_C206_7405 = Helper.GetElementValue(valores, 2, 1);
            this.GIR_C206_4405 = Helper.GetElementValue(valores, 2, 2);
            this.GIR_C206_7402_2 = Helper.GetElementValue(valores, 3, 0);
            this.GIR_C206_7405_2 = Helper.GetElementValue(valores, 3, 1);
            this.GIR_C206_4405_2 = Helper.GetElementValue(valores, 3, 2);
            this.GIR_C206_7402_3 = Helper.GetElementValue(valores, 4, 0);
            this.GIR_C206_7405_3 = Helper.GetElementValue(valores, 4, 1);
            this.GIR_C206_4405_3 = Helper.GetElementValue(valores, 4, 2);
            this.GIR_C206_7402_4 = Helper.GetElementValue(valores, 5, 0);
            this.GIR_C206_7405_4 = Helper.GetElementValue(valores, 5, 1);
            this.GIR_C206_4405_4 = Helper.GetElementValue(valores, 5, 2);
            this.GIR_C206_7402_5 = Helper.GetElementValue(valores, 6, 0);
            this.GIR_C206_7405_5 = Helper.GetElementValue(valores, 6, 1);
            this.GIR_C206_4405_5 = Helper.GetElementValue(valores, 6, 2);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("GIR"
                                    , string.Format("GIR{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{0}{10}{1}{11}{1}{12}{0}{13}{1}{14}{1}{15}{0}{16}{1}{17}{1}{18}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(GIR_7297, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7402, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7405, Properties)
                                        , Helper.ReleaseValue(GIR_C206_4405, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7402_2, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7405_2, Properties)
                                        , Helper.ReleaseValue(GIR_C206_4405_2, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7402_3, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7405_3, Properties)
                                        , Helper.ReleaseValue(GIR_C206_4405_3, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7402_4, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7405_4, Properties)
                                        , Helper.ReleaseValue(GIR_C206_4405_4, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7402_5, Properties)
                                        , Helper.ReleaseValue(GIR_C206_7405_5, Properties)
                                        , Helper.ReleaseValue(GIR_C206_4405_5, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
