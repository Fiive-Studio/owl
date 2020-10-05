using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento TOD</summary>
    public class TOD : EDISegmentBase
    {
        #region 4055

        /// <summary>Funci�n de las Condiciones de Entrega</summary>
        public string TOD_4055 { get; set; }

        #endregion // Fin-4055

        #region 4215

        /// <summary>M�todo de Pago de Costes de Transporte, Codificado</summary>
        public string TOD_4215 { get; set; }

        #endregion // Fin-4215

        #region C100

        #region 4053

        /// <summary>Condiciones de Entrega, Codificado</summary>
        public string TOD_C100_4053 { get; set; }

        #endregion // Fin-4053

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TOD_C100_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TOD_C100_3055 { get; set; }

        #endregion // Fin-3055

        #region 4052

        /// <summary>Condiciones de Entrega</summary>
        public string TOD_C100_4052 { get; set; }

        #endregion // Fin-4052

        #region 4052_2

        /// <summary>Condiciones de Entrega 2</summary>
        public string TOD_C100_4052_2 { get; set; }

        #endregion // Fin-4052_2

        #endregion // Fin-C100

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.TOD_4055 = Helper.GetElementValue(valores, 1, 0);
            this.TOD_4215 = Helper.GetElementValue(valores, 2, 0);
            this.TOD_C100_4053 = Helper.GetElementValue(valores, 3, 0);
            this.TOD_C100_1131 = Helper.GetElementValue(valores, 3, 1);
            this.TOD_C100_3055 = Helper.GetElementValue(valores, 3, 2);
            this.TOD_C100_4052 = Helper.GetElementValue(valores, 3, 3);
            this.TOD_C100_4052_2 = Helper.GetElementValue(valores, 3, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TOD"
                                    , string.Format("TOD{0}{3}{0}{4}{0}{5}{1}{6}{1}{7}{1}{8}{1}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(TOD_4055, Properties)
                                        , Helper.ReleaseValue(TOD_4215, Properties)
                                        , Helper.ReleaseValue(TOD_C100_4053, Properties)
                                        , Helper.ReleaseValue(TOD_C100_1131, Properties)
                                        , Helper.ReleaseValue(TOD_C100_3055, Properties)
                                        , Helper.ReleaseValue(TOD_C100_4052, Properties)
                                        , Helper.ReleaseValue(TOD_C100_4052_2, Properties)
                                    ), Properties);
        }

        #endregion
    }
}