using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PAI</summary>
    public class PAI : EDISegmentBase
    {
        #region C534

        #region 4439

        /// <summary>M�todo de Pago, Codificado</summary>
        public string PAI_C534_4439 { get; set; }

        #endregion // Fin-4439

        #region 4431

        /// <summary>Garantia de Pago, Codificado</summary>
        public string PAI_C534_4431 { get; set; }

        #endregion // Fin-4431

        #region 4461

        /// <summary>Medio de Pago, Codificado</summary>
        public string PAI_C534_4461 { get; set; }

        #endregion // Fin-4461

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PAI_C534_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PAI_C534_3055 { get; set; }

        #endregion // Fin-3055

        #region 4435

        /// <summary>Canal de Pago, Codificado</summary>
        public string PAI_C534_4435 { get; set; }

        #endregion // Fin-4435

        #endregion // Fin-C534

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PAI_C534_4439 = Helper.GetElementValue(valores, 1, 0);
            this.PAI_C534_4431 = Helper.GetElementValue(valores, 1, 1);
            this.PAI_C534_4461 = Helper.GetElementValue(valores, 1, 2);
            this.PAI_C534_1131 = Helper.GetElementValue(valores, 1, 3);
            this.PAI_C534_3055 = Helper.GetElementValue(valores, 1, 4);
            this.PAI_C534_4435 = Helper.GetElementValue(valores, 1, 5);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PAI"
                                    , string.Format("PAI{0}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PAI_C534_4439, Properties)
                                        , Helper.ReleaseValue(PAI_C534_4431, Properties)
                                        , Helper.ReleaseValue(PAI_C534_4461, Properties)
                                        , Helper.ReleaseValue(PAI_C534_1131, Properties)
                                        , Helper.ReleaseValue(PAI_C534_3055, Properties)
                                        , Helper.ReleaseValue(PAI_C534_4435, Properties)
                                    ), Properties);
        }

        #endregion
    }
}