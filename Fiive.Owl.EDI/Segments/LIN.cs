using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento LIN</summary>
    public class LIN : EDISegmentBase
    {
        #region 1082

        /// <summary>N�mero de L�nea de Art�culo</summary>
        public string LIN_1082 { get; set; }

        #endregion // Fin-1082

        #region 1229

        /// <summary>Solicitud de Acci�n o Notificaci�n, Codificado</summary>
        public string LIN_1229 { get; set; }

        #endregion // Fin-1229

        #region C212

        #region 7140

        /// <summary>N�mero de Art�culo</summary>
        public string LIN_C212_7140 { get; set; }

        #endregion // Fin-7140

        #region 7143

        /// <summary>Tipo de N�mero de Art�culo</summary>
        public string LIN_C212_7143 { get; set; }

        #endregion // Fin-7143

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string LIN_C212_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string LIN_C212_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C212

        #region C829

        #region 5495

        /// <summary>Indicador de Sub-l�nea, Codificado</summary>
        public string LIN_C829_5495 { get; set; }

        #endregion // Fin-5495

        #region 1082

        /// <summary>N�mero de L�nea de Art�culo</summary>
        public string LIN_C829_1082 { get; set; }

        #endregion // Fin-1082

        #endregion // Fin-C829

        #region 1222

        /// <summary>Nivel de Configuraci�n</summary>
        public string LIN_1222 { get; set; }

        #endregion // Fin-1222

        #region 7083

        /// <summary>Configuraci�n, Codificado</summary>
        public string LIN_7083 { get; set; }

        #endregion // Fin-7083

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.LIN_1082 = Helper.GetElementValue(valores, 1, 0);
            this.LIN_1229 = Helper.GetElementValue(valores, 2, 0);
            this.LIN_C212_7140 = Helper.GetElementValue(valores, 3, 0);
            this.LIN_C212_7143 = Helper.GetElementValue(valores, 3, 1);
            this.LIN_C212_1131 = Helper.GetElementValue(valores, 3, 2);
            this.LIN_C212_3055 = Helper.GetElementValue(valores, 3, 3);
            this.LIN_C829_5495 = Helper.GetElementValue(valores, 4, 0);
            this.LIN_C829_1082 = Helper.GetElementValue(valores, 4, 1);
            this.LIN_1222 = Helper.GetElementValue(valores, 5, 0);
            this.LIN_7083 = Helper.GetElementValue(valores, 6, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("LIN"
                                    , string.Format("LIN{0}{3}{0}{4}{0}{5}{1}{6}{1}{7}{1}{8}{0}{9}{1}{10}{0}{11}{0}{12}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(LIN_1082, Properties)
                                        , Helper.ReleaseValue(LIN_1229, Properties)
                                        , Helper.ReleaseValue(LIN_C212_7140, Properties)
                                        , Helper.ReleaseValue(LIN_C212_7143, Properties)
                                        , Helper.ReleaseValue(LIN_C212_1131, Properties)
                                        , Helper.ReleaseValue(LIN_C212_3055, Properties)
                                        , Helper.ReleaseValue(LIN_C829_5495, Properties)
                                        , Helper.ReleaseValue(LIN_C829_1082, Properties)
                                        , Helper.ReleaseValue(LIN_1222, Properties)
                                        , Helper.ReleaseValue(LIN_7083, Properties)
                                    ), Properties);
        }

        #endregion
    }
}