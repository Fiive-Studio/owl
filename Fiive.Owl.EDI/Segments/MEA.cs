using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento MEA</summary>
    public class MEA : EDISegmentBase
    {
        #region 6311

        /// <summary>Calificador de Aplicaci�n de Medida</summary>
        public string MEA_6311 { get; set; }

        #endregion // Fin-6311

        #region C502

        #region 6313

        /// <summary>Dimensi�n de Medida, Codificado</summary>
        public string MEA_C502_6313 { get; set; }

        #endregion // Fin-6313

        #region 6321

        /// <summary>Significado de la Medida, Codificado</summary>
        public string MEA_C502_6321 { get; set; }

        #endregion // Fin-6321

        #region 6155

        /// <summary>Atributo de Medida, Codificado</summary>
        public string MEA_C502_6155 { get; set; }

        #endregion // Fin-6155

        #region 6154

        /// <summary>Atributo de Medida</summary>
        public string MEA_C502_6154 { get; set; }

        #endregion // Fin-6154

        #endregion // Fin-C502

        #region C174

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string MEA_C174_6411 { get; set; }

        #endregion // Fin-6411

        #region 6314

        /// <summary>Valor de la Medida</summary>
        public string MEA_C174_6314 { get; set; }

        #endregion // Fin-6314

        #region 6162

        /// <summary>L�mite Inferior</summary>
        public string MEA_C174_6162 { get; set; }

        #endregion // Fin-6162

        #region 6152

        /// <summary>L�mite Superior</summary>
        public string MEA_C174_6152 { get; set; }

        #endregion // Fin-6152

        #region 6432

        /// <summary>Digitos Significativos</summary>
        public string MEA_C174_6432 { get; set; }

        #endregion // Fin-6432

        #endregion // Fin-C174

        #region 7383

        /// <summary>Indicador de Superficie o Capa</summary>
        public string MEA_7383 { get; set; }

        #endregion // Fin-7383

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.MEA_6311 = Helper.GetElementValue(valores, 1, 0);
            this.MEA_C502_6313 = Helper.GetElementValue(valores, 2, 0);
            this.MEA_C502_6321 = Helper.GetElementValue(valores, 2, 1);
            this.MEA_C502_6155 = Helper.GetElementValue(valores, 2, 2);
            this.MEA_C502_6154 = Helper.GetElementValue(valores, 2, 3);
            this.MEA_C174_6411 = Helper.GetElementValue(valores, 3, 0);
            this.MEA_C174_6314 = Helper.GetElementValue(valores, 3, 1);
            this.MEA_C174_6162 = Helper.GetElementValue(valores, 3, 2);
            this.MEA_C174_6152 = Helper.GetElementValue(valores, 3, 3);
            this.MEA_C174_6432 = Helper.GetElementValue(valores, 3, 4);
            this.MEA_7383 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MEA"
                                    , string.Format("MEA{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{1}{12}{0}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(MEA_6311, Properties)
                                        , Helper.ReleaseValue(MEA_C502_6313, Properties)
                                        , Helper.ReleaseValue(MEA_C502_6321, Properties)
                                        , Helper.ReleaseValue(MEA_C502_6155, Properties)
                                        , Helper.ReleaseValue(MEA_C502_6154, Properties)
                                        , Helper.ReleaseValue(MEA_C174_6411, Properties)
                                        , Helper.ReleaseValue(MEA_C174_6314, Properties)
                                        , Helper.ReleaseValue(MEA_C174_6162, Properties)
                                        , Helper.ReleaseValue(MEA_C174_6152, Properties)
                                        , Helper.ReleaseValue(MEA_C174_6432, Properties)
                                        , Helper.ReleaseValue(MEA_7383, Properties)
                                    ), Properties);
        }

        #endregion
    }
}