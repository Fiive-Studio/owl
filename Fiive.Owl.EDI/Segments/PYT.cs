using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PYT</summary>
    public class PYT : EDISegmentBase
    {
        #region 4279

        /// <summary>Tipo de T�rminos de Pago</summary>
        public string PYT_4279 { get; set; }

        #endregion // Fin-4279

        #region C019

        #region 4277

        /// <summary>Descripci�n T�rminos de Pago, Identificador</summary>
        public string PYT_C019_4277 { get; set; }

        #endregion // Fin-4277

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PYT_C019_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PYT_C019_3055 { get; set; }

        #endregion // Fin-3055

        #region 4276

        /// <summary>Descripci�n T�rminos de Pago</summary>
        public string PYT_C019_4276 { get; set; }

        #endregion // Fin-4276

        #endregion // Fin-C019

        #region 2475

        /// <summary>Referencia de Tiempo para Pago</summary>
        public string PYT_2475 { get; set; }

        #endregion // Fin-2475

        #region 2009

        /// <summary>Relaci�n con el Tiempo para Pago</summary>
        public string PYT_2009 { get; set; }

        #endregion // Fin-2009

        #region 2151

        /// <summary>Tipo de Periodo</summary>
        public string PYT_2151 { get; set; }

        #endregion // Fin-2151

        #region 2152

        /// <summary>N�mero de Periodos</summary>
        public string PYT_2152 { get; set; }

        #endregion // Fin-2152

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PYT_4279 = Helper.GetElementValue(valores, 1, 0);
            this.PYT_C019_4277 = Helper.GetElementValue(valores, 2, 0);
            this.PYT_C019_1131 = Helper.GetElementValue(valores, 2, 1);
            this.PYT_C019_3055 = Helper.GetElementValue(valores, 2, 2);
            this.PYT_C019_4276 = Helper.GetElementValue(valores, 2, 3);
            this.PYT_2475 = Helper.GetElementValue(valores, 3, 0);
            this.PYT_2009 = Helper.GetElementValue(valores, 4, 0);
            this.PYT_2151 = Helper.GetElementValue(valores, 5, 0);
            this.PYT_2152 = Helper.GetElementValue(valores, 6, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PYT"
                                    , string.Format("PYT{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{0}{9}{0}{10}{0}{11}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PYT_4279, Properties)
                                        , Helper.ReleaseValue(PYT_C019_4277, Properties)
                                        , Helper.ReleaseValue(PYT_C019_1131, Properties)
                                        , Helper.ReleaseValue(PYT_C019_3055, Properties)
                                        , Helper.ReleaseValue(PYT_C019_4276, Properties)
                                        , Helper.ReleaseValue(PYT_2475, Properties)
                                        , Helper.ReleaseValue(PYT_2009, Properties)
                                        , Helper.ReleaseValue(PYT_2151, Properties)
                                        , Helper.ReleaseValue(PYT_2152, Properties)
                                    ), Properties);
        }

        #endregion
    }
}