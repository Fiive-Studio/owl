using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento USA</summary>
    public class USA : EDISegmentBase
    {
        #region S502

        public string USA_S502_0523 { get; set; }
        public string USA_S502_0525 { get; set; }
        public string USA_S502_0533 { get; set; }
        public string USA_S502_0527 { get; set; }
        public string USA_S502_0529 { get; set; }
        public string USA_S502_0591 { get; set; }
        public string USA_S502_0601 { get; set; }

        #endregion // Fin-S502

        #region S503

        public string USA_S503_0531 { get; set; }
        public string USA_S503_0554 { get; set; }

        #endregion // Fin-S503

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.USA_S502_0523 = Helper.GetElementValue(valores, 1, 0);
            this.USA_S502_0525 = Helper.GetElementValue(valores, 1, 1);
            this.USA_S502_0533 = Helper.GetElementValue(valores, 1, 2);
            this.USA_S502_0527 = Helper.GetElementValue(valores, 1, 3);
            this.USA_S502_0529 = Helper.GetElementValue(valores, 1, 4);
            this.USA_S502_0591 = Helper.GetElementValue(valores, 1, 5);
            this.USA_S502_0601 = Helper.GetElementValue(valores, 1, 6);
            this.USA_S503_0531 = Helper.GetElementValue(valores, 2, 0);
            this.USA_S503_0554 = Helper.GetElementValue(valores, 2, 1);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("USA"
                                    , string.Format("USA{0}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{0}{10}{1}{11}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(USA_S502_0523, Properties)
                                        , Helper.ReleaseValue(USA_S502_0525, Properties)
                                        , Helper.ReleaseValue(USA_S502_0533, Properties)
                                        , Helper.ReleaseValue(USA_S502_0527, Properties)
                                        , Helper.ReleaseValue(USA_S502_0529, Properties)
                                        , Helper.ReleaseValue(USA_S502_0591, Properties)
                                        , Helper.ReleaseValue(USA_S502_0601, Properties)
                                        , Helper.ReleaseValue(USA_S503_0531, Properties)
                                        , Helper.ReleaseValue(USA_S503_0554, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
