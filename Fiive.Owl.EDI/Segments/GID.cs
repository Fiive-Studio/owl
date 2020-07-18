using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento GID</summary>
    public class GID : EDISegmentBase
    {
        #region 1496

        /// <summary>N�mero de Componente de Mercanc�a</summary>
        public string GID_1496 { get; set; }

        #endregion // Fin-1496

        #region C213

        #region 7224

        /// <summary>N�mero de Embalajes 1</summary>
        public string GID_C213_7224 { get; set; }

        #endregion // Fin-7224

        #region 7065

        /// <summary>Tipo de Embalaje, Codificado 1</summary>
        public string GID_C213_7065 { get; set; }

        #endregion // Fin-7065

        #region 1131

        /// <summary>Calificador de Lista de C�digos 1</summary>
        public string GID_C213_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 1</summary>
        public string GID_C213_3055 { get; set; }

        #endregion // Fin-3055

        #region 7064

        /// <summary>Tipo de Embalajes 1</summary>
        public string GID_C213_7064 { get; set; }

        #endregion // Fin-7064

        #endregion // Fin-C213

        #region C213

        #region 7224_2

        /// <summary>N�mero de Embalajes 2</summary>
        public string GID_C213_7224_2 { get; set; }

        #endregion // Fin-7224_2

        #region 7065_2

        /// <summary>Tipo de Embalaje, Codificado 2</summary>
        public string GID_C213_7065_2 { get; set; }

        #endregion // Fin-7065_2

        #region 1131_2

        /// <summary>Calificador de Lista de C�digos 2</summary>
        public string GID_C213_1131_2 { get; set; }

        #endregion // Fin-1131_2

        #region 3055_2

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 2</summary>
        public string GID_C213_3055_2 { get; set; }

        #endregion // Fin-3055_2

        #region 7064_2

        /// <summary>Tipo de Embalajes 2</summary>
        public string GID_C213_7064_2 { get; set; }

        #endregion // Fin-7064_2

        #endregion // Fin-C213

        #region C213

        #region 7224_3

        /// <summary>N�mero de Embalajes 3</summary>
        public string GID_C213_7224_3 { get; set; }

        #endregion // Fin-7224_3

        #region 7065_3

        /// <summary>Tipo de Embalaje, Codificado 3</summary>
        public string GID_C213_7065_3 { get; set; }

        #endregion // Fin-7065_3

        #region 1131_3

        /// <summary>Calificador de Lista de C�digos 3</summary>
        public string GID_C213_1131_3 { get; set; }

        #endregion // Fin-1131_3

        #region 3055_3

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 3</summary>
        public string GID_C213_3055_3 { get; set; }

        #endregion // Fin-3055_3

        #region 7064_3

        /// <summary>Tipo de Embalajes 3</summary>
        public string GID_C213_7064_3 { get; set; }

        #endregion // Fin-7064_3

        #endregion // Fin-C213

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.GID_1496 = Helper.GetElementValue(valores, 1, 0);
            this.GID_C213_7224 = Helper.GetElementValue(valores, 2, 0);
            this.GID_C213_7065 = Helper.GetElementValue(valores, 2, 1);
            this.GID_C213_1131 = Helper.GetElementValue(valores, 2, 2);
            this.GID_C213_3055 = Helper.GetElementValue(valores, 2, 3);
            this.GID_C213_7064 = Helper.GetElementValue(valores, 2, 4);
            this.GID_C213_7224_2 = Helper.GetElementValue(valores, 3, 0);
            this.GID_C213_7065_2 = Helper.GetElementValue(valores, 3, 1);
            this.GID_C213_1131_2 = Helper.GetElementValue(valores, 3, 2);
            this.GID_C213_3055_2 = Helper.GetElementValue(valores, 3, 3);
            this.GID_C213_7064_2 = Helper.GetElementValue(valores, 3, 4);
            this.GID_C213_7224_3 = Helper.GetElementValue(valores, 4, 0);
            this.GID_C213_7065_3 = Helper.GetElementValue(valores, 4, 1);
            this.GID_C213_1131_3 = Helper.GetElementValue(valores, 4, 2);
            this.GID_C213_3055_3 = Helper.GetElementValue(valores, 4, 3);
            this.GID_C213_7064_3 = Helper.GetElementValue(valores, 4, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("GID"
                                    , string.Format("GID{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{1}{10}{1}{11}{1}{12}{1}{13}{0}{14}{1}{15}{1}{16}{1}{17}{1}{18}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(GID_1496, Properties)
                                        , Helper.ReleaseValue(GID_C213_7224, Properties)
                                        , Helper.ReleaseValue(GID_C213_7065, Properties)
                                        , Helper.ReleaseValue(GID_C213_1131, Properties)
                                        , Helper.ReleaseValue(GID_C213_3055, Properties)
                                        , Helper.ReleaseValue(GID_C213_7064, Properties)
                                        , Helper.ReleaseValue(GID_C213_7224_2, Properties)
                                        , Helper.ReleaseValue(GID_C213_7065_2, Properties)
                                        , Helper.ReleaseValue(GID_C213_1131_2, Properties)
                                        , Helper.ReleaseValue(GID_C213_3055_2, Properties)
                                        , Helper.ReleaseValue(GID_C213_7064_2, Properties)
                                        , Helper.ReleaseValue(GID_C213_7224_3, Properties)
                                        , Helper.ReleaseValue(GID_C213_7065_3, Properties)
                                        , Helper.ReleaseValue(GID_C213_1131_3, Properties)
                                        , Helper.ReleaseValue(GID_C213_3055_3, Properties)
                                        , Helper.ReleaseValue(GID_C213_7064_3, Properties)
                                    ), Properties);
        }

        #endregion
    }
}