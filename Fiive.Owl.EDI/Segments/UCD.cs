using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UCD</summary>
    public class UCD : EDISegmentBase
    {
        #region 0085

        /// <summary>Error de Sintaxis, Codificado</summary>
        public string UCD_0085 { get; set; }

        #endregion // Fin-0085

        #region S011

        #region 0098

        /// <summary>Posici�n del Elemento de Dato Err�neo dentro del Segmento</summary>
        public string UCD_S011_0098 { get; set; }

        #endregion // Fin-0098

        #region 0104

        /// <summary>Posici�n del Elemento de Dato Componente Err�neo</summary>
        public string UCD_S011_0104 { get; set; }

        #endregion // Fin-0104

        #endregion // Fin-S011

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UCD_0085 = Helper.GetElementValue(valores, 1, 0);
            this.UCD_S011_0098 = Helper.GetElementValue(valores, 2, 0);
            this.UCD_S011_0104 = Helper.GetElementValue(valores, 2, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UCD"
                                    , string.Format("UCD{0}{3}{0}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UCD_0085, Properties)
                                        , Helper.ReleaseValue(UCD_S011_0098, Properties)
                                        , Helper.ReleaseValue(UCD_S011_0104, Properties)
                                    ), Properties);
        }

        #endregion
    }
}