using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento RCS</summary>
    public class RCS : EDISegmentBase
    {
        #region 7293

        /// <summary>C�digo de Identificaci�n de �rea de Sector</summary>
        public string RCS_7293 { get; set; }

        #endregion // Fin-7293

        #region C550

        #region 7295

        /// <summary>Identificador de Descripci�n del Requisito o Condici�n</summary>
        public string RCS_C550_7295 { get; set; }

        #endregion // Fin-7295

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string RCS_C550_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string RCS_C550_3055 { get; set; }

        #endregion // Fin-3055

        #region 7294

        /// <summary>Descripci�n del Requisito o Condici�n</summary>
        public string RCS_C550_7294 { get; set; }

        #endregion // Fin-7294

        #endregion // Fin-C550

        #region 1229

        /// <summary>Solicitud de Acci�n o Notificaci�n, Codificado</summary>
        public string RCS_1229 { get; set; }

        #endregion // Fin-1229

        #region 3207

        /// <summary>Pa�s, Codificado</summary>
        public string RCS_3207 { get; set; }

        #endregion // Fin-3207

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.RCS_7293 = Helper.GetElementValue(valores, 1, 0);
            this.RCS_C550_7295 = Helper.GetElementValue(valores, 2, 0);
            this.RCS_C550_1131 = Helper.GetElementValue(valores, 2, 1);
            this.RCS_C550_3055 = Helper.GetElementValue(valores, 2, 2);
            this.RCS_C550_7294 = Helper.GetElementValue(valores, 2, 3);
            this.RCS_1229 = Helper.GetElementValue(valores, 3, 0);
            this.RCS_3207 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("RCS"
                                    , string.Format("RCS{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{0}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(RCS_7293, Properties)
                                        , Helper.ReleaseValue(RCS_C550_7295, Properties)
                                        , Helper.ReleaseValue(RCS_C550_1131, Properties)
                                        , Helper.ReleaseValue(RCS_C550_3055, Properties)
                                        , Helper.ReleaseValue(RCS_C550_7294, Properties)
                                        , Helper.ReleaseValue(RCS_1229, Properties)
                                        , Helper.ReleaseValue(RCS_3207, Properties)
                                    ), Properties);
        }

        #endregion
    }
}