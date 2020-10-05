using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CCI</summary>
    public class CCI : EDISegmentBase
    {
        #region 7059

        /// <summary>Tipo de Clase</summary>
        public string CCI_7059 { get; set; }

        #endregion // Fin-7059

        #region C502

        #region 6313

        /// <summary>Dimensi�n de Medida, Codificado</summary>
        public string CCI_C502_6313 { get; set; }

        #endregion // Fin-6313

        #region 6321

        /// <summary>Significado de la Medida, Codificado</summary>
        public string CCI_C502_6321 { get; set; }

        #endregion // Fin-6321

        #region 6155

        /// <summary>Atributo de Medida, Codificado</summary>
        public string CCI_C502_6155 { get; set; }

        #endregion // Fin-6155

        #region 6154

        /// <summary>Atributo de Medida</summary>
        public string CCI_C502_6154 { get; set; }

        #endregion // Fin-6154

        #endregion // Fin-C502

        #region C240

        #region 7037

        /// <summary>Identificaci�n de Caracter�stica</summary>
        public string CCI_C240_7037 { get; set; }

        #endregion // Fin-7037

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string CCI_C240_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string CCI_C240_3055 { get; set; }

        #endregion // Fin-3055

        #region 7036

        /// <summary>Caracter�stica 1</summary>
        public string CCI_C240_7036 { get; set; }

        #endregion // Fin-7036

        #region 7036_2

        /// <summary>Caracter�stica 2</summary>
        public string CCI_C240_7036_2 { get; set; }

        #endregion // Fin-7036_2

        #endregion // Fin-C240

        #region 4051

        /// <summary>Caracter�stica Relevante, Codificado</summary>
        public string CCI_4051 { get; set; }

        #endregion // Fin-4051

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CCI_7059 = Helper.GetElementValue(valores, 1, 0);
            this.CCI_C502_6313 = Helper.GetElementValue(valores, 2, 0);
            this.CCI_C502_6321 = Helper.GetElementValue(valores, 2, 1);
            this.CCI_C502_6155 = Helper.GetElementValue(valores, 2, 2);
            this.CCI_C502_6154 = Helper.GetElementValue(valores, 2, 3);
            this.CCI_C240_7037 = Helper.GetElementValue(valores, 3, 0);
            this.CCI_C240_1131 = Helper.GetElementValue(valores, 3, 1);
            this.CCI_C240_3055 = Helper.GetElementValue(valores, 3, 2);
            this.CCI_C240_7036 = Helper.GetElementValue(valores, 3, 3);
            this.CCI_C240_7036_2 = Helper.GetElementValue(valores, 3, 4);
            this.CCI_4051 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CCI"
                                    , string.Format("CCI{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{1}{12}{0}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CCI_7059, Properties)
                                        , Helper.ReleaseValue(CCI_C502_6313, Properties)
                                        , Helper.ReleaseValue(CCI_C502_6321, Properties)
                                        , Helper.ReleaseValue(CCI_C502_6155, Properties)
                                        , Helper.ReleaseValue(CCI_C502_6154, Properties)
                                        , Helper.ReleaseValue(CCI_C240_7037, Properties)
                                        , Helper.ReleaseValue(CCI_C240_1131, Properties)
                                        , Helper.ReleaseValue(CCI_C240_3055, Properties)
                                        , Helper.ReleaseValue(CCI_C240_7036, Properties)
                                        , Helper.ReleaseValue(CCI_C240_7036_2, Properties)
                                        , Helper.ReleaseValue(CCI_4051, Properties)
                                    ), Properties);
        }

        #endregion
    }
}