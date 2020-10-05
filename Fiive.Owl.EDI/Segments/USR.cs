using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento USR</summary>
    public class USR : EDISegmentBase
    {
        #region S508

        public string USR_S508_0563 { get; set; }
        public string USR_S508_0560 { get; set; }

        #endregion // Fin-S508

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.USR_S508_0563 = Helper.GetElementValue(valores, 1, 0);
            this.USR_S508_0560 = Helper.GetElementValue(valores, 1, 1);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("USR"
                                    , string.Format("USR{0}{3}{1}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(USR_S508_0563, Properties)
                                        , Helper.ReleaseValue(USR_S508_0560, Properties)
                                    ), Properties);
        }

        #endregion
    }
}
