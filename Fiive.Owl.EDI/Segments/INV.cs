using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento INV</summary>
    public class INV : EDISegmentBase
    {
        #region 4501

        /// <summary>Direcci�n de un Movimiento de Inventario, Codificada</summary>
        public string INV_4501 { get; set; }

        #endregion // Fin-4501

        #region 7491

        /// <summary>Tipo de Inventario Afectado, Codificado</summary>
        public string INV_7491 { get; set; }

        #endregion // Fin-7491

        #region 4499

        /// <summary>Raz�n para un Movimiento de Inventario, Codificada</summary>
        public string INV_4499 { get; set; }

        #endregion // Fin-4499

        #region 4503

        /// <summary>Metodo de Balance de Inventario, Codificado</summary>
        public string INV_4503 { get; set; }

        #endregion // Fin-4503

        #region C522

        #region 4403

        /// <summary>Calificador de Instrucci�n</summary>
        public string INV_C522_4403 { get; set; }

        #endregion // Fin-4403

        #region 4401

        /// <summary>Instrucci�n, Codificada</summary>
        public string INV_C522_4401 { get; set; }

        #endregion // Fin-4401

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string INV_C522_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string INV_C522_3055 { get; set; }

        #endregion // Fin-3055

        #region 4400

        /// <summary>Instrucci�n</summary>
        public string INV_C522_4400 { get; set; }

        #endregion // Fin-4400

        #endregion // Fin-C522

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.INV_4501 = Helper.GetElementValue(valores, 1, 0);
            this.INV_7491 = Helper.GetElementValue(valores, 2, 0);
            this.INV_4499 = Helper.GetElementValue(valores, 3, 0);
            this.INV_4503 = Helper.GetElementValue(valores, 4, 0);
            this.INV_C522_4403 = Helper.GetElementValue(valores, 5, 0);
            this.INV_C522_4401 = Helper.GetElementValue(valores, 5, 1);
            this.INV_C522_1131 = Helper.GetElementValue(valores, 5, 2);
            this.INV_C522_3055 = Helper.GetElementValue(valores, 5, 3);
            this.INV_C522_4400 = Helper.GetElementValue(valores, 5, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("INV"
                                    , string.Format("INV{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{1}{8}{1}{9}{1}{10}{1}{11}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(INV_4501, Properties)
                                        , Helper.ReleaseValue(INV_7491, Properties)
                                        , Helper.ReleaseValue(INV_4499, Properties)
                                        , Helper.ReleaseValue(INV_4503, Properties)
                                        , Helper.ReleaseValue(INV_C522_4403, Properties)
                                        , Helper.ReleaseValue(INV_C522_4401, Properties)
                                        , Helper.ReleaseValue(INV_C522_1131, Properties)
                                        , Helper.ReleaseValue(INV_C522_3055, Properties)
                                        , Helper.ReleaseValue(INV_C522_4400, Properties)
                                    ), Properties);
        }

        #endregion
    }
}