using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento TDT</summary>
    public class TDT : EDISegmentBase
    {
        #region 8051

        /// <summary>Calificador de Etapa de Transporte</summary>
        public string TDT_8051 { get; set; }

        #endregion // Fin-8051

        #region 8028

        /// <summary>N�mero de Referencia de Transporte</summary>
        public string TDT_8028 { get; set; }

        #endregion // Fin-8028

        #region C220

        #region 8067

        /// <summary>Modo de Transporte, Codificado</summary>
        public string TDT_C220_8067 { get; set; }

        #endregion // Fin-8067

        #region 8066

        /// <summary>Modo de Transporte</summary>
        public string TDT_C220_8066 { get; set; }

        #endregion // Fin-8066

        #endregion // Fin-C220

        #region C228

        #region 8179

        /// <summary>Identificaci�n del Tipo de Medio de Transporte</summary>
        public string TDT_C228_8179 { get; set; }

        #endregion // Fin-8179

        #region 8178

        /// <summary>Tipo de Medio de Transporte</summary>
        public string TDT_C228_8178 { get; set; }

        #endregion // Fin-8178

        #endregion // Fin-C228

        #region C040

        #region 3127

        /// <summary>Identificaci�n del Transportista</summary>
        public string TDT_C040_3127 { get; set; }

        #endregion // Fin-3127

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TDT_C040_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TDT_C040_3055 { get; set; }

        #endregion // Fin-3055

        #region 3128

        /// <summary>Nombre del Transportista</summary>
        public string TDT_C040_3128 { get; set; }

        #endregion // Fin-3128

        #endregion // Fin-C040

        #region 8101

        /// <summary>Direcci�n del Tr�nsito, Codificado</summary>
        public string TDT_8101 { get; set; }

        #endregion // Fin-8101

        #region C401

        #region 8457

        /// <summary>Raz�n del Exceso de Carga en Transporte, Codificado</summary>
        public string TDT_C401_8457 { get; set; }

        #endregion // Fin-8457

        #region 8459

        /// <summary>Responsabilidad de Exceso de Carga en Transporte, Codificado</summary>
        public string TDT_C401_8459 { get; set; }

        #endregion // Fin-8459

        #region 7130

        /// <summary>N�mero de Autorizaci�n del Cliente</summary>
        public string TDT_C401_7130 { get; set; }

        #endregion // Fin-7130

        #endregion // Fin-C401

        #region C222

        #region 8213

        /// <summary>Identificaci�n del Medio de Transporte, Codificado</summary>
        public string TDT_C222_8213 { get; set; }

        #endregion // Fin-8213

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TDT_C222_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TDT_C222_3055 { get; set; }

        #endregion // Fin-3055

        #region 8212

        /// <summary>Identificaci�n del Medio de Transporte</summary>
        public string TDT_C222_8212 { get; set; }

        #endregion // Fin-8212

        #region 8453

        /// <summary>Nacionalidad del Medio de Transporte, Codificado</summary>
        public string TDT_C222_8453 { get; set; }

        #endregion // Fin-8453

        #endregion // Fin-C222

        #region 8281

        /// <summary>Propiedad del Transporte, Codificado</summary>
        public string TDT_8281 { get; set; }

        #endregion // Fin-8281

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.TDT_8051 = Helper.GetElementValue(valores, 1, 0);
            this.TDT_8028 = Helper.GetElementValue(valores, 2, 0);
            this.TDT_C220_8067 = Helper.GetElementValue(valores, 3, 0);
            this.TDT_C220_8066 = Helper.GetElementValue(valores, 3, 1);
            this.TDT_C228_8179 = Helper.GetElementValue(valores, 4, 0);
            this.TDT_C228_8178 = Helper.GetElementValue(valores, 4, 1);
            this.TDT_C040_3127 = Helper.GetElementValue(valores, 5, 0);
            this.TDT_C040_1131 = Helper.GetElementValue(valores, 5, 1);
            this.TDT_C040_3055 = Helper.GetElementValue(valores, 5, 2);
            this.TDT_C040_3128 = Helper.GetElementValue(valores, 5, 3);
            this.TDT_8101 = Helper.GetElementValue(valores, 6, 0);
            this.TDT_C401_8457 = Helper.GetElementValue(valores, 7, 0);
            this.TDT_C401_8459 = Helper.GetElementValue(valores, 7, 1);
            this.TDT_C401_7130 = Helper.GetElementValue(valores, 7, 2);
            this.TDT_C222_8213 = Helper.GetElementValue(valores, 8, 0);
            this.TDT_C222_1131 = Helper.GetElementValue(valores, 8, 1);
            this.TDT_C222_3055 = Helper.GetElementValue(valores, 8, 2);
            this.TDT_C222_8212 = Helper.GetElementValue(valores, 8, 3);
            this.TDT_C222_8453 = Helper.GetElementValue(valores, 8, 4);
            this.TDT_8281 = Helper.GetElementValue(valores, 9, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TDT"
                                    , string.Format("TDT{0}{3}{0}{4}{0}{5}{1}{6}{0}{7}{1}{8}{0}{9}{1}{10}{1}{11}{1}{12}{0}{13}{0}{14}{1}{15}{1}{16}{0}{17}{1}{18}{1}{19}{1}{20}{1}{21}{0}{22}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(TDT_8051, Properties)
                                        , Helper.ReleaseValue(TDT_8028, Properties)
                                        , Helper.ReleaseValue(TDT_C220_8067, Properties)
                                        , Helper.ReleaseValue(TDT_C220_8066, Properties)
                                        , Helper.ReleaseValue(TDT_C228_8179, Properties)
                                        , Helper.ReleaseValue(TDT_C228_8178, Properties)
                                        , Helper.ReleaseValue(TDT_C040_3127, Properties)
                                        , Helper.ReleaseValue(TDT_C040_1131, Properties)
                                        , Helper.ReleaseValue(TDT_C040_3055, Properties)
                                        , Helper.ReleaseValue(TDT_C040_3128, Properties)
                                        , Helper.ReleaseValue(TDT_8101, Properties)
                                        , Helper.ReleaseValue(TDT_C401_8457, Properties)
                                        , Helper.ReleaseValue(TDT_C401_8459, Properties)
                                        , Helper.ReleaseValue(TDT_C401_7130, Properties)
                                        , Helper.ReleaseValue(TDT_C222_8213, Properties)
                                        , Helper.ReleaseValue(TDT_C222_1131, Properties)
                                        , Helper.ReleaseValue(TDT_C222_3055, Properties)
                                        , Helper.ReleaseValue(TDT_C222_8212, Properties)
                                        , Helper.ReleaseValue(TDT_C222_8453, Properties)
                                        , Helper.ReleaseValue(TDT_8281, Properties)
                                    ), Properties);
        }

        #endregion
    }
}