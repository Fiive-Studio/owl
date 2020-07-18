using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento APR</summary>
    public class APR : EDISegmentBase
    {
        #region 4043

        /// <summary>Tipo de Comercio, Codificado</summary>
        public string APR_4043 { get; set; }

        #endregion // Fin-4043

        #region C138

        #region 5394

        /// <summary>Multiplicador del Precio</summary>
        public string APR_C138_5394 { get; set; }

        #endregion // Fin-5394

        #region 5393

        /// <summary>Calificador del Multiplicador del Precio</summary>
        public string APR_C138_5393 { get; set; }

        #endregion // Fin-5393

        #endregion // Fin-C138

        #region C960

        #region 4295

        /// <summary>Raz�n del Cambio, Codificado</summary>
        public string APR_C960_4295 { get; set; }

        #endregion // Fin-4295

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string APR_C960_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string APR_C960_3055 { get; set; }

        #endregion // Fin-3055

        #region 4294

        /// <summary>Raz�n del Cambio</summary>
        public string APR_C960_4294 { get; set; }

        #endregion // Fin-4294

        #endregion // Fin-C960

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.APR_4043 = Helper.GetElementValue(valores, 1, 0);
            this.APR_C138_5394 = Helper.GetElementValue(valores, 2, 0);
            this.APR_C138_5393 = Helper.GetElementValue(valores, 2, 1);
            this.APR_C960_4295 = Helper.GetElementValue(valores, 3, 0);
            this.APR_C960_1131 = Helper.GetElementValue(valores, 3, 1);
            this.APR_C960_3055 = Helper.GetElementValue(valores, 3, 2);
            this.APR_C960_4294 = Helper.GetElementValue(valores, 3, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("APR"
                                    , string.Format("APR{0}{3}{0}{4}{1}{5}{0}{6}{1}{7}{1}{8}{1}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(APR_4043, Properties)
                                        , Helper.ReleaseValue(APR_C138_5394, Properties)
                                        , Helper.ReleaseValue(APR_C138_5393, Properties)
                                        , Helper.ReleaseValue(APR_C960_4295, Properties)
                                        , Helper.ReleaseValue(APR_C960_1131, Properties)
                                        , Helper.ReleaseValue(APR_C960_3055, Properties)
                                        , Helper.ReleaseValue(APR_C960_4294, Properties)
                                    ), Properties);
        }

        #endregion
    }
}