using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UST</summary>
    public class UST : EDISegmentBase
    {
        #region 0534

        public string UST_0534 { get; set; }

        #endregion // Fin-0534

        #region 0588

        public string UST_0588 { get; set; }

        #endregion // Fin-0588

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UST_0534 = Helper.GetElementValue(valores, 1, 0);
            this.UST_0588 = Helper.GetElementValue(valores, 2, 0);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UST"
                                    , string.Format("UST{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UST_0534, Properties)
                                        , Helper.ReleaseValue(UST_0588, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
