using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento ALC</summary>
    public class ALC : EDISegmentBase
    {
        #region 5463

        /// <summary>Indicador de Descuento o Cargo, Codificado</summary>
        public string ALC_5463 { get; set; }

        #endregion // Fin-5463

        #region C552

        #region 1230

        /// <summary>N�mero de Descuento o Cargo</summary>
        public string ALC_C552_1230 { get; set; }

        #endregion // Fin-1230

        #region 5189

        /// <summary>Descripci�n del Descuento o Cargo, Codificado</summary>
        public string ALC_C552_5189 { get; set; }

        #endregion // Fin-5189

        #endregion // Fin-C552

        #region 4471

        /// <summary>Imputaci�n de Descuento o Cargo, Codificado</summary>
        public string ALC_4471 { get; set; }

        #endregion // Fin-4471

        #region 1227

        /// <summary>Indicador de Secuencia de C�lculo, Codificado</summary>
        public string ALC_1227 { get; set; }

        #endregion // Fin-1227

        #region C214

        #region 7161

        /// <summary>Servicios Especiales, Codificado</summary>
        public string ALC_C214_7161 { get; set; }

        #endregion // Fin-7161

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string ALC_C214_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string ALC_C214_3055 { get; set; }

        #endregion // Fin-3055

        #region 7160

        /// <summary>Servicio Especial 1</summary>
        public string ALC_C214_7160 { get; set; }

        #endregion // Fin-7160

        #region 7160_2

        /// <summary>Servicio Especial 2</summary>
        public string ALC_C214_7160_2 { get; set; }

        #endregion // Fin-7160_2

        #endregion // Fin-C214

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.ALC_5463 = Helper.GetElementValue(valores, 1, 0);
            this.ALC_C552_1230 = Helper.GetElementValue(valores, 2, 0);
            this.ALC_C552_5189 = Helper.GetElementValue(valores, 2, 1);
            this.ALC_4471 = Helper.GetElementValue(valores, 3, 0);
            this.ALC_1227 = Helper.GetElementValue(valores, 4, 0);
            this.ALC_C214_7161 = Helper.GetElementValue(valores, 5, 0);
            this.ALC_C214_1131 = Helper.GetElementValue(valores, 5, 1);
            this.ALC_C214_3055 = Helper.GetElementValue(valores, 5, 2);
            this.ALC_C214_7160 = Helper.GetElementValue(valores, 5, 3);
            this.ALC_C214_7160_2 = Helper.GetElementValue(valores, 5, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ALC"
                                    , string.Format("ALC{0}{3}{0}{4}{1}{5}{0}{6}{0}{7}{0}{8}{1}{9}{1}{10}{1}{11}{1}{12}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(ALC_5463, Properties)
                                        , Helper.ReleaseValue(ALC_C552_1230, Properties)
                                        , Helper.ReleaseValue(ALC_C552_5189, Properties)
                                        , Helper.ReleaseValue(ALC_4471, Properties)
                                        , Helper.ReleaseValue(ALC_1227, Properties)
                                        , Helper.ReleaseValue(ALC_C214_7161, Properties)
                                        , Helper.ReleaseValue(ALC_C214_1131, Properties)
                                        , Helper.ReleaseValue(ALC_C214_3055, Properties)
                                        , Helper.ReleaseValue(ALC_C214_7160, Properties)
                                        , Helper.ReleaseValue(ALC_C214_7160_2, Properties)
                                    ), Properties);
        }

        #endregion
    }
}