using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento USC</summary>
    public class USC : EDISegmentBase
    {
        #region 0536

        public string USC_0536 { get; set; }

        #endregion // Fin-0536

        #region S500

        public string USC_S500_0500 { get; set; }
        public string USC_S500_0577 { get; set; }
        public string USC_S500_0538 { get; set; }
        public string USC_S500_0511 { get; set; }
        public string USC_S500_0513 { get; set; }
        public string USC_S500_0515 { get; set; }
        public string USC_S500_0586 { get; set; }
        public string USC_S500_0586_2 { get; set; }
        public string USC_S500_0586_3 { get; set; }

        #endregion // Fin-S500

        #region 0545

        public string USC_0545 { get; set; }

        #endregion // Fin-0545

        #region 0505

        public string USC_0505 { get; set; }

        #endregion // Fin-0505

        #region 0507

        public string USC_0507 { get; set; }

        #endregion // Fin-0507

        #region 0543

        public string USC_0543 { get; set; }

        #endregion // Fin-0543

        #region 0546

        public string USC_0546 { get; set; }

        #endregion // Fin-0546

        #region S505

        public string USC_S505_0505 { get; set; }
        public string USC_S505_0551 { get; set; }
        public string USC_S505_0548 { get; set; }

        #endregion // Fin-S505

        #region S501

        public string USC_S501_0501 { get; set; }
        public string USC_S501_0517 { get; set; }
        public string USC_S501_0338 { get; set; }
        public string USC_S501_0314 { get; set; }
        public string USC_S501_0335 { get; set; }

        #endregion // Fin-S501

        #region 0567

        public string USC_0567 { get; set; }

        #endregion // Fin-0567

        #region 0569

        public string USC_0569 { get; set; }

        #endregion // Fin-0569

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.USC_0536 = Helper.GetElementValue(valores, 1, 0);
            this.USC_S500_0577 = Helper.GetElementValue(valores, 2, 0);
            this.USC_S500_0500 = Helper.GetElementValue(valores, 2, 1);
            this.USC_S500_0538 = Helper.GetElementValue(valores, 2, 2);
            this.USC_S500_0511 = Helper.GetElementValue(valores, 2, 3);
            this.USC_S500_0513 = Helper.GetElementValue(valores, 2, 4);
            this.USC_S500_0515 = Helper.GetElementValue(valores, 2, 5);
            this.USC_S500_0586 = Helper.GetElementValue(valores, 2, 6);
            this.USC_S500_0586_2 = Helper.GetElementValue(valores, 2, 7);
            this.USC_S500_0586_3 = Helper.GetElementValue(valores, 2, 8);
            this.USC_0545 = Helper.GetElementValue(valores, 3, 0);
            this.USC_0505 = Helper.GetElementValue(valores, 4, 0);
            this.USC_0507 = Helper.GetElementValue(valores, 5, 0);
            this.USC_0543 = Helper.GetElementValue(valores, 6, 0);
            this.USC_0546 = Helper.GetElementValue(valores, 7, 0);
            this.USC_S505_0505 = Helper.GetElementValue(valores, 8, 0);
            this.USC_S505_0551 = Helper.GetElementValue(valores, 8, 1);
            this.USC_S505_0548 = Helper.GetElementValue(valores, 8, 2);
            this.USC_S501_0501 = Helper.GetElementValue(valores, 9, 0);
            this.USC_S501_0517 = Helper.GetElementValue(valores, 9, 1);
            this.USC_S501_0338 = Helper.GetElementValue(valores, 9, 2);
            this.USC_S501_0314 = Helper.GetElementValue(valores, 9, 3);
            this.USC_S501_0335 = Helper.GetElementValue(valores, 9, 4);
            this.USC_0567 = Helper.GetElementValue(valores, 10, 0);
            this.USC_0569 = Helper.GetElementValue(valores, 11, 0);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("USC"
                                    , string.Format("USC{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{1}{10}{1}{11}{1}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{1}{19}{1}{20}{0}{21}{1}{22}{1}{23}{1}{24}{1}{25}{0}{26}{0}{27}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(USC_0536, Properties)
                                        , Helper.ReleaseValue(USC_S500_0500, Properties)
                                        , Helper.ReleaseValue(USC_S500_0577, Properties)
                                        , Helper.ReleaseValue(USC_S500_0538, Properties)
                                        , Helper.ReleaseValue(USC_S500_0511, Properties)
                                        , Helper.ReleaseValue(USC_S500_0513, Properties)
                                        , Helper.ReleaseValue(USC_S500_0515, Properties)
                                        , Helper.ReleaseValue(USC_S500_0586, Properties)
                                        , Helper.ReleaseValue(USC_S500_0586_2, Properties)
                                        , Helper.ReleaseValue(USC_S500_0586_3, Properties)
                                        , Helper.ReleaseValue(USC_0545, Properties)
                                        , Helper.ReleaseValue(USC_0505, Properties)
                                        , Helper.ReleaseValue(USC_0507, Properties)
                                        , Helper.ReleaseValue(USC_0543, Properties)
                                        , Helper.ReleaseValue(USC_0546, Properties)
                                        , Helper.ReleaseValue(USC_S505_0505, Properties)
                                        , Helper.ReleaseValue(USC_S505_0551, Properties)
                                        , Helper.ReleaseValue(USC_S505_0548, Properties)
                                        , Helper.ReleaseValue(USC_S501_0501, Properties)
                                        , Helper.ReleaseValue(USC_S501_0517, Properties)
                                        , Helper.ReleaseValue(USC_S501_0338, Properties)
                                        , Helper.ReleaseValue(USC_S501_0314, Properties)
                                        , Helper.ReleaseValue(USC_S501_0335, Properties)
                                        , Helper.ReleaseValue(USC_0567, Properties)
                                        , Helper.ReleaseValue(USC_0569, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
