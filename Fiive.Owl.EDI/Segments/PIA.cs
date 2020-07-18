using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PIA</summary>
    public class PIA : EDISegmentBase
    {
        #region 4347

        /// <summary>Calificador de Funci�n del C�digo de Producto</summary>
        public string PIA_4347 { get; set; }

        #endregion // Fin-4347

        #region C212

        #region 7140

        /// <summary>N�mero de Art�culo 1</summary>
        public string PIA_C212_7140 { get; set; }

        #endregion // Fin-7140

        #region 7143

        /// <summary>Tipo de N�mero de Art�culo 1</summary>
        public string PIA_C212_7143 { get; set; }

        #endregion // Fin-7143

        #region 1131

        /// <summary>Calificador de Lista de C�digos 1</summary>
        public string PIA_C212_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 1</summary>
        public string PIA_C212_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C212

        #region C212

        #region 7140_2

        /// <summary>N�mero de Art�culo 2</summary>
        public string PIA_C212_7140_2 { get; set; }

        #endregion // Fin-7140_2

        #region 7143_2

        /// <summary>Tipo de N�mero de Art�culo 2</summary>
        public string PIA_C212_7143_2 { get; set; }

        #endregion // Fin-7143_2

        #region 1131_2

        /// <summary>Calificador de Lista de C�digos 2</summary>
        public string PIA_C212_1131_2 { get; set; }

        #endregion // Fin-1131_2

        #region 3055_2

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 2</summary>
        public string PIA_C212_3055_2 { get; set; }

        #endregion // Fin-3055_2

        #endregion // Fin-C212

        #region C212

        #region 7140_3

        /// <summary>N�mero de Art�culo 3</summary>
        public string PIA_C212_7140_3 { get; set; }

        #endregion // Fin-7140_3

        #region 7143_3

        /// <summary>Tipo de N�mero de Art�culo 3</summary>
        public string PIA_C212_7143_3 { get; set; }

        #endregion // Fin-7143_3

        #region 1131_3

        /// <summary>Calificador de Lista de C�digos 3</summary>
        public string PIA_C212_1131_3 { get; set; }

        #endregion // Fin-1131_3

        #region 3055_3

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 3</summary>
        public string PIA_C212_3055_3 { get; set; }

        #endregion // Fin-3055_3

        #endregion // Fin-C212

        #region C212

        #region 7140_4

        /// <summary>N�mero de Art�culo 4</summary>
        public string PIA_C212_7140_4 { get; set; }

        #endregion // Fin-7140_4

        #region 7143_4

        /// <summary>Tipo de N�mero de Art�culo 4</summary>
        public string PIA_C212_7143_4 { get; set; }

        #endregion // Fin-7143_4

        #region 1131_4

        /// <summary>Calificador de Lista de C�digos 4</summary>
        public string PIA_C212_1131_4 { get; set; }

        #endregion // Fin-1131_4

        #region 3055_4

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 4</summary>
        public string PIA_C212_3055_4 { get; set; }

        #endregion // Fin-3055_4

        #endregion // Fin-C212

        #region C212

        #region 7140_5

        /// <summary>N�mero de Art�culo 5</summary>
        public string PIA_C212_7140_5 { get; set; }

        #endregion // Fin-7140_5

        #region 7143_5

        /// <summary>Tipo de N�mero de Art�culo 5</summary>
        public string PIA_C212_7143_5 { get; set; }

        #endregion // Fin-7143_5

        #region 1131_5

        /// <summary>Calificador de Lista de C�digos 5</summary>
        public string PIA_C212_1131_5 { get; set; }

        #endregion // Fin-1131_5

        #region 3055_5

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 5</summary>
        public string PIA_C212_3055_5 { get; set; }

        #endregion // Fin-3055_5

        #endregion // Fin-C212

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PIA_4347 = Helper.GetElementValue(valores, 1, 0);
            this.PIA_C212_7140 = Helper.GetElementValue(valores, 2, 0);
            this.PIA_C212_7143 = Helper.GetElementValue(valores, 2, 1);
            this.PIA_C212_1131 = Helper.GetElementValue(valores, 2, 2);
            this.PIA_C212_3055 = Helper.GetElementValue(valores, 2, 3);
            this.PIA_C212_7140_2 = Helper.GetElementValue(valores, 3, 0);
            this.PIA_C212_7143_2 = Helper.GetElementValue(valores, 3, 1);
            this.PIA_C212_1131_2 = Helper.GetElementValue(valores, 3, 2);
            this.PIA_C212_3055_2 = Helper.GetElementValue(valores, 3, 3);
            this.PIA_C212_7140_3 = Helper.GetElementValue(valores, 4, 0);
            this.PIA_C212_7143_3 = Helper.GetElementValue(valores, 4, 1);
            this.PIA_C212_1131_3 = Helper.GetElementValue(valores, 4, 2);
            this.PIA_C212_3055_3 = Helper.GetElementValue(valores, 4, 3);
            this.PIA_C212_7140_4 = Helper.GetElementValue(valores, 5, 0);
            this.PIA_C212_7143_4 = Helper.GetElementValue(valores, 5, 1);
            this.PIA_C212_1131_4 = Helper.GetElementValue(valores, 5, 2);
            this.PIA_C212_3055_4 = Helper.GetElementValue(valores, 5, 3);
            this.PIA_C212_7140_5 = Helper.GetElementValue(valores, 6, 0);
            this.PIA_C212_7143_5 = Helper.GetElementValue(valores, 6, 1);
            this.PIA_C212_1131_5 = Helper.GetElementValue(valores, 6, 2);
            this.PIA_C212_3055_5 = Helper.GetElementValue(valores, 6, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PIA"
                                    , string.Format("PIA{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{0}{12}{1}{13}{1}{14}{1}{15}{0}{16}{1}{17}{1}{18}{1}{19}{0}{20}{1}{21}{1}{22}{1}{23}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PIA_4347, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7140, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7143, Properties)
                                        , Helper.ReleaseValue(PIA_C212_1131, Properties)
                                        , Helper.ReleaseValue(PIA_C212_3055, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7140_2, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7143_2, Properties)
                                        , Helper.ReleaseValue(PIA_C212_1131_2, Properties)
                                        , Helper.ReleaseValue(PIA_C212_3055_2, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7140_3, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7143_3, Properties)
                                        , Helper.ReleaseValue(PIA_C212_1131_3, Properties)
                                        , Helper.ReleaseValue(PIA_C212_3055_3, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7140_4, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7143_4, Properties)
                                        , Helper.ReleaseValue(PIA_C212_1131_4, Properties)
                                        , Helper.ReleaseValue(PIA_C212_3055_4, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7140_5, Properties)
                                        , Helper.ReleaseValue(PIA_C212_7143_5, Properties)
                                        , Helper.ReleaseValue(PIA_C212_1131_5, Properties)
                                        , Helper.ReleaseValue(PIA_C212_3055_5, Properties)
                                    ), Properties);
        }

        #endregion
    }
}