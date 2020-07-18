using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNT</summary>
    public class UNT : EDISegmentBase
    {
        #region 0074

        /// <summary>N�mero de Segmentos en el Mensaje</summary>
        public string UNT_0074 { get; set; }

        #endregion // Fin-0074

        #region 0062

        /// <summary>N�mero de Referencia del Mensaje</summary>
        public string UNT_0062 { get; set; }

        #endregion // Fin-0062

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNT_0074 = Helper.GetElementValue(valores, 1, 0);
            this.UNT_0062 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNT"
                                    , string.Format("UNT{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNT_0074, Properties)
                                        , Helper.ReleaseValue(UNT_0062, Properties)
                                    ), Properties);
        }

        #endregion
    }
}