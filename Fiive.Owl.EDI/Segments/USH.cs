using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento USH</summary>
    public class USH : EDISegmentBase
    {
        #region 0501

        public string USH_0501 { get; set; }

        #endregion // Fin-0501

        #region 0534

        public string USH_0534 { get; set; }

        #endregion // Fin-0534

        #region 0541

        public string USH_0541 { get; set; }

        #endregion // Fin-0541

        #region 0503

        public string USH_0503 { get; set; }

        #endregion // Fin-0503

        #region 0505

        public string USH_0505 { get; set; }

        #endregion // Fin-0505

        #region 0507

        public string USH_0507 { get; set; }

        #endregion // Fin-0507

        #region 0509

        public string USH_0509 { get; set; }

        #endregion // Fin-0509

        #region S500

        public string USH_S500_0577 { get; set; }
        public string USH_S500_0538 { get; set; }
        public string USH_S500_0511 { get; set; }
        public string USH_S500_0513 { get; set; }
        public string USH_S500_0515 { get; set; }
        public string USH_S500_0586 { get; set; }
        public string USH_S500_0586_2 { get; set; }
        public string USH_S500_0586_3 { get; set; }

        #endregion // Fin-S500

        #region 0520

        public string USH_0520 { get; set; }

        #endregion // Fin-0520

        #region S501

        public string USC_S501_0517 { get; set; }
        public string USC_S501_0338 { get; set; }
        public string USC_S501_0314 { get; set; }
        public string USC_S501_0335 { get; set; }

        #endregion // Fin-S501

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.USH_0501 = Helper.GetElementValue(valores, 1, 0);
            this.USH_0534 = Helper.GetElementValue(valores, 2, 0);
            this.USH_0541 = Helper.GetElementValue(valores, 3, 0);
            this.USH_0503 = Helper.GetElementValue(valores, 4, 0);
            this.USH_0505 = Helper.GetElementValue(valores, 5, 0);
            this.USH_0507 = Helper.GetElementValue(valores, 6, 0);
            this.USH_0509 = Helper.GetElementValue(valores, 7, 0);
            this.USH_S500_0577 = Helper.GetElementValue(valores, 8, 0);
            this.USH_S500_0538 = Helper.GetElementValue(valores, 8, 1);
            this.USH_S500_0511 = Helper.GetElementValue(valores, 8, 2);
            this.USH_S500_0513 = Helper.GetElementValue(valores, 8, 3);
            this.USH_S500_0515 = Helper.GetElementValue(valores, 8, 4);
            this.USH_S500_0586 = Helper.GetElementValue(valores, 8, 5);
            this.USH_S500_0586_2 = Helper.GetElementValue(valores, 8, 6);
            this.USH_S500_0586_3 = Helper.GetElementValue(valores, 8, 7);
            this.USH_0520 = Helper.GetElementValue(valores, 9, 0);
            this.USC_S501_0517 = Helper.GetElementValue(valores, 10, 0);
            this.USC_S501_0338 = Helper.GetElementValue(valores, 10, 1);
            this.USC_S501_0314 = Helper.GetElementValue(valores, 10, 2);
            this.USC_S501_0335 = Helper.GetElementValue(valores, 10, 3);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("USH"
                                    , string.Format("USH{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{1}{11}{1}{12}{1}{13}{1}{14}{1}{15}{1}{16}{1}{17}{0}{18}{0}{19}{1}{20}{1}{21}{1}{22}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(USH_0501, Properties)
                                        , Helper.ReleaseValue(USH_0534, Properties)
                                        , Helper.ReleaseValue(USH_0541, Properties)
                                        , Helper.ReleaseValue(USH_0503, Properties)
                                        , Helper.ReleaseValue(USH_0505, Properties)
                                        , Helper.ReleaseValue(USH_0507, Properties)
                                        , Helper.ReleaseValue(USH_0509, Properties)
                                        , Helper.ReleaseValue(USH_S500_0577, Properties)
                                        , Helper.ReleaseValue(USH_S500_0538, Properties)
                                        , Helper.ReleaseValue(USH_S500_0511, Properties)
                                        , Helper.ReleaseValue(USH_S500_0513, Properties)
                                        , Helper.ReleaseValue(USH_S500_0515, Properties)
                                        , Helper.ReleaseValue(USH_S500_0586, Properties)
                                        , Helper.ReleaseValue(USH_S500_0586_2, Properties)
                                        , Helper.ReleaseValue(USH_S500_0586_3, Properties)
                                        , Helper.ReleaseValue(USH_0520, Properties)
                                        , Helper.ReleaseValue(USC_S501_0517, Properties)
                                        , Helper.ReleaseValue(USC_S501_0338, Properties)
                                        , Helper.ReleaseValue(USC_S501_0314, Properties)
                                        , Helper.ReleaseValue(USC_S501_0335, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
