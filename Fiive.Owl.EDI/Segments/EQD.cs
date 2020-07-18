using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento EQD</summary>
    public class EQD : EDISegmentBase
    {
        #region 8053

        /// <summary>Calificador de Equipo</summary>
        public string EQD_8053 { get; set; }

        #endregion // Fin-8053

        #region C237

        #region 8260

        /// <summary>N�mero de Identificaci�n de Equipo</summary>
        public string EQD_C237_8260 { get; set; }

        #endregion // Fin-8260

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string EQD_C237_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string EQD_C237_3055 { get; set; }

        #endregion // Fin-3055

        #region 3207

        /// <summary>Pa�s, Codificado</summary>
        public string EQD_C237_3207 { get; set; }

        #endregion // Fin-3207

        #endregion // Fin-C237

        #region C224

        #region 8155

        /// <summary>Tama�o y Tipo del Equipamiento, Codificado</summary>
        public string EQD_C224_8155 { get; set; }

        #endregion // Fin-8155

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string EQD_C224_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string EQD_C224_3055 { get; set; }

        #endregion // Fin-3055

        #region 8154

        /// <summary>Tama�o y Tipo del Equipamiento</summary>
        public string EQD_C224_8154 { get; set; }

        #endregion // Fin-8154

        #endregion // Fin-C224

        #region 8077

        /// <summary>Proveedor del Equipo, Codificado</summary>
        public string EQD_8077 { get; set; }

        #endregion // Fin-8077

        #region 8249

        /// <summary>Situaci�n del Equipamiento, Codificado</summary>
        public string EQD_8249 { get; set; }

        #endregion // Fin-8249

        #region 8169

        /// <summary>Indicador de Lleno o Vac�o, Codificado</summary>
        public string EQD_8169 { get; set; }

        #endregion // Fin-8169

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.EQD_8053 = Helper.GetElementValue(valores, 1, 0);
            this.EQD_C237_8260 = Helper.GetElementValue(valores, 2, 0);
            this.EQD_C237_1131 = Helper.GetElementValue(valores, 2, 1);
            this.EQD_C237_3055 = Helper.GetElementValue(valores, 2, 2);
            this.EQD_C237_3207 = Helper.GetElementValue(valores, 2, 3);
            this.EQD_C224_8155 = Helper.GetElementValue(valores, 3, 0);
            this.EQD_C224_1131 = Helper.GetElementValue(valores, 3, 1);
            this.EQD_C224_3055 = Helper.GetElementValue(valores, 3, 2);
            this.EQD_C224_8154 = Helper.GetElementValue(valores, 3, 3);
            this.EQD_8077 = Helper.GetElementValue(valores, 4, 0);
            this.EQD_8249 = Helper.GetElementValue(valores, 5, 0);
            this.EQD_8169 = Helper.GetElementValue(valores, 6, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("EQD"
                                    , string.Format("EQD{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{0}{12}{0}{13}{0}{14}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(EQD_8053, Properties)
                                        , Helper.ReleaseValue(EQD_C237_8260, Properties)
                                        , Helper.ReleaseValue(EQD_C237_1131, Properties)
                                        , Helper.ReleaseValue(EQD_C237_3055, Properties)
                                        , Helper.ReleaseValue(EQD_C237_3207, Properties)
                                        , Helper.ReleaseValue(EQD_C224_8155, Properties)
                                        , Helper.ReleaseValue(EQD_C224_1131, Properties)
                                        , Helper.ReleaseValue(EQD_C224_3055, Properties)
                                        , Helper.ReleaseValue(EQD_C224_8154, Properties)
                                        , Helper.ReleaseValue(EQD_8077, Properties)
                                        , Helper.ReleaseValue(EQD_8249, Properties)
                                        , Helper.ReleaseValue(EQD_8169, Properties)
                                    ), Properties);
        }

        #endregion
    }
}