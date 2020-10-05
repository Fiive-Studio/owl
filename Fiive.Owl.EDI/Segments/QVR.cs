using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento QVR</summary>
    public class QVR : EDISegmentBase
    {
        #region C279

        #region 6064

        /// <summary>Diferencias en Cantidad</summary>
        public string QVR_C279_6064 { get; set; }

        #endregion // Fin-6064

        #region 6063

        /// <summary>Calificador de Cantidad</summary>
        public string QVR_C279_6063 { get; set; }

        #endregion // Fin-6063

        #endregion // Fin-C279

        #region 4221

        /// <summary>Discrepancia, Codificado</summary>
        public string QVR_4221 { get; set; }

        #endregion // Fin-4221

        #region C960

        #region 4295

        /// <summary>Raz�n del Cambio, Codificado</summary>
        public string QVR_C960_4295 { get; set; }

        #endregion // Fin-4295

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string QVR_C960_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string QVR_C960_3055 { get; set; }

        #endregion // Fin-3055

        #region 4294

        /// <summary>Raz�n del Cambio</summary>
        public string QVR_C960_4294 { get; set; }

        #endregion // Fin-4294

        #endregion // Fin-C960

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.QVR_C279_6064 = Helper.GetElementValue(valores, 1, 0);
            this.QVR_C279_6063 = Helper.GetElementValue(valores, 1, 1);
            this.QVR_4221 = Helper.GetElementValue(valores, 2, 0);
            this.QVR_C960_4295 = Helper.GetElementValue(valores, 3, 0);
            this.QVR_C960_1131 = Helper.GetElementValue(valores, 3, 1);
            this.QVR_C960_3055 = Helper.GetElementValue(valores, 3, 2);
            this.QVR_C960_4294 = Helper.GetElementValue(valores, 3, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("QVR"
                                    , string.Format("QVR{0}{3}{1}{4}{0}{5}{0}{6}{1}{7}{1}{8}{1}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(QVR_C279_6064, Properties)
                                        , Helper.ReleaseValue(QVR_C279_6063, Properties)
                                        , Helper.ReleaseValue(QVR_4221, Properties)
                                        , Helper.ReleaseValue(QVR_C960_4295, Properties)
                                        , Helper.ReleaseValue(QVR_C960_1131, Properties)
                                        , Helper.ReleaseValue(QVR_C960_3055, Properties)
                                        , Helper.ReleaseValue(QVR_C960_4294, Properties)
                                    ), Properties);
        }

        #endregion
    }
}