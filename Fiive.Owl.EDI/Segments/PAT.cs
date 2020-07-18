using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PAT</summary>
    public class PAT : EDISegmentBase
    {
        #region 4279

        /// <summary>Calificador de las Condiciones de Pago</summary>
        public string PAT_4279 { get; set; }

        #endregion // Fin-4279

        #region C110

        #region 4277

        /// <summary>Condiciones de Pago, Codificado</summary>
        public string PAT_C110_4277 { get; set; }

        #endregion // Fin-4277

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PAT_C110_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PAT_C110_3055 { get; set; }

        #endregion // Fin-3055

        #region 4276

        /// <summary>Condiciones de Pago 1</summary>
        public string PAT_C110_4276 { get; set; }

        #endregion // Fin-4276

        #region 4276_2

        /// <summary>Condiciones de Pago 2</summary>
        public string PAT_C110_4276_2 { get; set; }

        #endregion // Fin-4276_2

        #endregion // Fin-C110

        #region C112

        #region 2475

        /// <summary>Referencia del Tiempo de Pago, Codificado</summary>
        public string PAT_C112_2475 { get; set; }

        #endregion // Fin-2475

        #region 2009

        /// <summary>Relaci�n de Tiempo, Codificado</summary>
        public string PAT_C112_2009 { get; set; }

        #endregion // Fin-2009

        #region 2151

        /// <summary>Tipo de Per�odo, Codificado</summary>
        public string PAT_C112_2151 { get; set; }

        #endregion // Fin-2151

        #region 2152

        /// <summary>N�mero de Per�odos</summary>
        public string PAT_C112_2152 { get; set; }

        #endregion // Fin-2152

        #endregion // Fin-C112

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PAT_4279 = Helper.GetElementValue(valores, 1, 0);
            this.PAT_C110_4277 = Helper.GetElementValue(valores, 2, 0);
            this.PAT_C110_1131 = Helper.GetElementValue(valores, 2, 1);
            this.PAT_C110_3055 = Helper.GetElementValue(valores, 2, 2);
            this.PAT_C110_4276 = Helper.GetElementValue(valores, 2, 3);
            this.PAT_C110_4276_2 = Helper.GetElementValue(valores, 2, 4);
            this.PAT_C112_2475 = Helper.GetElementValue(valores, 3, 0);
            this.PAT_C112_2009 = Helper.GetElementValue(valores, 3, 1);
            this.PAT_C112_2151 = Helper.GetElementValue(valores, 3, 2);
            this.PAT_C112_2152 = Helper.GetElementValue(valores, 3, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PAT"
                                    , string.Format("PAT{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{1}{10}{1}{11}{1}{12}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PAT_4279, Properties)
                                        , Helper.ReleaseValue(PAT_C110_4277, Properties)
                                        , Helper.ReleaseValue(PAT_C110_1131, Properties)
                                        , Helper.ReleaseValue(PAT_C110_3055, Properties)
                                        , Helper.ReleaseValue(PAT_C110_4276, Properties)
                                        , Helper.ReleaseValue(PAT_C110_4276_2, Properties)
                                        , Helper.ReleaseValue(PAT_C112_2475, Properties)
                                        , Helper.ReleaseValue(PAT_C112_2009, Properties)
                                        , Helper.ReleaseValue(PAT_C112_2151, Properties)
                                        , Helper.ReleaseValue(PAT_C112_2152, Properties)
                                    ), Properties);
        }

        #endregion
    }
}