using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento SEL</summary>
    public class SEL : EDISegmentBase
    {
        #region 9308

        /// <summary>N�mero de Sello</summary>
        public string SEL_9308 { get; set; }

        #endregion // Fin-9308

        #region C215

        #region 9303

        /// <summary>Parte Emisora del Sello, Codificado</summary>
        public string SEL_C215_9303 { get; set; }

        #endregion // Fin-9303

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string SEL_C215_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string SEL_C215_3055 { get; set; }

        #endregion // Fin-3055

        #region 9302

        /// <summary>Parte Emisora del Sello</summary>
        public string SEL_C215_9302 { get; set; }

        #endregion // Fin-9302

        #endregion // Fin-C215

        #region 4517

        /// <summary>Condici�n de la Garant�a, Codificado</summary>
        public string SEL_4517 { get; set; }

        #endregion // Fin-4517

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.SEL_9308 = Helper.GetElementValue(valores, 1, 0);
            this.SEL_C215_9303 = Helper.GetElementValue(valores, 2, 0);
            this.SEL_C215_1131 = Helper.GetElementValue(valores, 2, 1);
            this.SEL_C215_3055 = Helper.GetElementValue(valores, 2, 2);
            this.SEL_C215_9302 = Helper.GetElementValue(valores, 2, 3);
            this.SEL_4517 = Helper.GetElementValue(valores, 3, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SEL"
                                    , string.Format("SEL{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(SEL_9308, Properties)
                                        , Helper.ReleaseValue(SEL_C215_9303, Properties)
                                        , Helper.ReleaseValue(SEL_C215_1131, Properties)
                                        , Helper.ReleaseValue(SEL_C215_3055, Properties)
                                        , Helper.ReleaseValue(SEL_C215_9302, Properties)
                                        , Helper.ReleaseValue(SEL_4517, Properties)
                                    ), Properties);
        }

        #endregion
    }
}