using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNS</summary>
    public class UNS : EDISegmentBase
    {
        #region 0081

        /// <summary>Identificaci�n de Secci�n</summary>
        public string UNS_0081 { get; set; }

        #endregion // Fin-0081

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNS_0081 = Helper.GetElementValue(valores, 1, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNS"
                                    , string.Format("UNS{0}{3}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNS_0081, Properties)
                                    ), Properties);
        }

        #endregion
    }
}