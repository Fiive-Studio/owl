using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UCM</summary>
    public class UCM : EDISegmentBase
    {
        #region 0062

        /// <summary>N�mero de Referencia del Mensaje</summary>
        public string UCM_0062 { get; set; }

        #endregion // Fin-0062

        #region S009

        #region 0065

        /// <summary>Identificador del Tipo de Mensaje</summary>
        public string UCM_S009_0065 { get; set; }

        #endregion // Fin-0065

        #region 0052

        /// <summary>N�mero de Versi�n del Tipo de Mensaje</summary>
        public string UCM_S009_0052 { get; set; }

        #endregion // Fin-0052

        #region 0054

        /// <summary>N�mero de Sub-Versi�n del Tipo de Mensaje</summary>
        public string UCM_S009_0054 { get; set; }

        #endregion // Fin-0054

        #region 0051

        /// <summary>Agencia Controladora</summary>
        public string UCM_S009_0051 { get; set; }

        #endregion // Fin-0051

        #region 0057

        /// <summary>C�digo Asignado por la Asociaci�n</summary>
        public string UCM_S009_0057 { get; set; }

        #endregion // Fin-0057

        #endregion // Fin-S009

        #region 0083

        /// <summary>Acci�n, Codificada</summary>
        public string UCM_0083 { get; set; }

        #endregion // Fin-0083

        #region 0085

        /// <summary>Error de Sintaxis, Codificado</summary>
        public string UCM_0085 { get; set; }

        #endregion // Fin-0085

        #region 0135

        /// <summary>Etiqueta (tag) de Segmento, Codificada</summary>
        public string UCM_0135 { get; set; }

        #endregion // Fin-0013

        #region S011

        #region 0098

        /// <summary>Posici�n del Elemento de Dato Err�neo dentro del Segmento</summary>
        public string UCM_S011_0098 { get; set; }

        #endregion // Fin-0098

        #region 0104

        /// <summary>Posici�n del Elemento de Dato Componente Err�neo</summary>
        public string UCM_S011_0104 { get; set; }

        #endregion // Fin-0104

        #endregion // Fin-S011

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UCM_0062 = Helper.GetElementValue(valores, 1, 0);
            this.UCM_S009_0065 = Helper.GetElementValue(valores, 2, 0);
            this.UCM_S009_0052 = Helper.GetElementValue(valores, 2, 1);
            this.UCM_S009_0054 = Helper.GetElementValue(valores, 2, 2);
            this.UCM_S009_0051 = Helper.GetElementValue(valores, 2, 3);
            this.UCM_S009_0057 = Helper.GetElementValue(valores, 2, 4);
            this.UCM_0083 = Helper.GetElementValue(valores, 3, 0);
            this.UCM_0085 = Helper.GetElementValue(valores, 4, 0);
            this.UCM_0135 = Helper.GetElementValue(valores, 5, 0);
            this.UCM_S011_0098 = Helper.GetElementValue(valores, 6, 0);
            this.UCM_S011_0104 = Helper.GetElementValue(valores, 6, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UCM"
                                    , string.Format("UCM{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{0}{10}{0}{11}{0}{12}{1}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UCM_0062, Properties)
                                        , Helper.ReleaseValue(UCM_S009_0065, Properties)
                                        , Helper.ReleaseValue(UCM_S009_0052, Properties)
                                        , Helper.ReleaseValue(UCM_S009_0054, Properties)
                                        , Helper.ReleaseValue(UCM_S009_0051, Properties)
                                        , Helper.ReleaseValue(UCM_S009_0057, Properties)
                                        , Helper.ReleaseValue(UCM_0083, Properties)
                                        , Helper.ReleaseValue(UCM_0085, Properties)
                                        , Helper.ReleaseValue(UCM_0135, Properties)
                                        , Helper.ReleaseValue(UCM_S011_0098, Properties)
                                        , Helper.ReleaseValue(UCM_S011_0104, Properties)
                                    ), Properties);
        }

        #endregion
    }
}