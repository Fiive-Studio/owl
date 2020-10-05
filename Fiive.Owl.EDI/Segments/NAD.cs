using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento NAD</summary>
    public class NAD : EDISegmentBase
    {
        #region 3035

        /// <summary>Calificador de parte</summary>
        public string NAD_3035 { get; set; }

        #endregion // Fin-3035

        #region C082

        #region 3039

        /// <summary>Identificaci�n de Parte, Codificado</summary>
        public string NAD_C082_3039 { get; set; }

        #endregion // Fin-3039

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string NAD_C082_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string NAD_C082_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C082

        #region C058

        #region 3124

        /// <summary>L�nea de Nombre y Direcci�n 1</summary>
        public string NAD_C058_3124 { get; set; }

        #endregion // Fin-3124

        #region 3124_2

        /// <summary>L�nea de Nombre y Direcci�n 2</summary>
        public string NAD_C058_3124_2 { get; set; }

        #endregion // Fin-3124_2

        #region 3124_3

        /// <summary>L�nea de Nombre y Direcci�n 3</summary>
        public string NAD_C058_3124_3 { get; set; }

        #endregion // Fin-3124_3

        #region 3124_4

        /// <summary>L�nea de Nombre y Direcci�n 4</summary>
        public string NAD_C058_3124_4 { get; set; }

        #endregion // Fin-3124_4

        #region 3124_5

        /// <summary>L�nea de Nombre y Direcci�n 5</summary>
        public string NAD_C058_3124_5 { get; set; }

        #endregion // Fin-3124_5

        #endregion // Fin-C058

        #region C080

        #region 3036

        /// <summary>Nombre de la Parte 1</summary>
        public string NAD_C080_3036 { get; set; }

        #endregion // Fin-3036

        #region 3036_2

        /// <summary>Nombre de la Parte 2</summary>
        public string NAD_C080_3036_2 { get; set; }

        #endregion // Fin-3036_2

        #region 3036_3

        /// <summary>Nombre de la Parte 3</summary>
        public string NAD_C080_3036_3 { get; set; }

        #endregion // Fin-3036_3

        #region 3036_4

        /// <summary>Nombre de la Parte 4</summary>
        public string NAD_C080_3036_4 { get; set; }

        #endregion // Fin-3036_4

        #region 3036_5

        /// <summary>Nombre de la Parte 5</summary>
        public string NAD_C080_3036_5 { get; set; }

        #endregion // Fin-3036_5

        #region 3045

        /// <summary>Formato del Nombre de una Parte, Codificado</summary>
        public string NAD_C080_3045 { get; set; }

        #endregion // Fin-3045

        #endregion // Fin-C080

        #region C059

        #region 3042

        /// <summary>Calle y N�mero o Apartado Postal 1</summary>
        public string NAD_C059_3042 { get; set; }

        #endregion // Fin-3042

        #region 3042_2

        /// <summary>Calle y N�mero o Apartado Postal 2</summary>
        public string NAD_C059_3042_2 { get; set; }

        #endregion // Fin-3042_2

        #region 3042_3

        /// <summary>Calle y N�mero o Apartado Postal 3</summary>
        public string NAD_C059_3042_3 { get; set; }

        #endregion // Fin-3042_3

        #region 3042_4

        /// <summary>Calle y N�mero o Apartado Postal 4</summary>
        public string NAD_C059_3042_4 { get; set; }

        #endregion // Fin-3042_4

        #endregion // Fin-C059

        #region 3164

        /// <summary>Nombre de Ciudad</summary>
        public string NAD_3164 { get; set; }

        #endregion // Fin-3164

		#region C819

		#region 3229

		/// <summary>Sub-Entidad de Pa�s, Codificado</summary>
		public string NAD_3229 { get; set; }

		#endregion // Fin-3229

		#region 1131

		/// <summary>Codigo de identificacion</summary>
		public string NAD_C819_1131 { get; set; }

		#endregion // Fin-1131

		#region 3055

		/// <summary>Codigo de Agencia Responsable</summary>
		public string NAD_C819_3055 { get; set; }

		#endregion // Fin-3055

		#region 3228

		/// <summary>Nombre de Subdivision de Pais</summary>
		public string NAD_C819_3228 { get; set; }

		#endregion // Fin-3228

		#endregion

		#region 3251

		/// <summary>C�digo Postal</summary>
        public string NAD_3251 { get; set; }

        #endregion // Fin-3251

        #region 3207

        /// <summary>Pa�s, Codificado</summary>
        public string NAD_3207 { get; set; }

        #endregion // Fin-3207

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.NAD_3035 = Helper.GetElementValue(valores, 1, 0);
            this.NAD_C082_3039 = Helper.GetElementValue(valores, 2, 0);
            this.NAD_C082_1131 = Helper.GetElementValue(valores, 2, 1);
            this.NAD_C082_3055 = Helper.GetElementValue(valores, 2, 2);
            this.NAD_C058_3124 = Helper.GetElementValue(valores, 3, 0);
            this.NAD_C058_3124_2 = Helper.GetElementValue(valores, 3, 1);
            this.NAD_C058_3124_3 = Helper.GetElementValue(valores, 3, 2);
            this.NAD_C058_3124_4 = Helper.GetElementValue(valores, 3, 3);
            this.NAD_C058_3124_5 = Helper.GetElementValue(valores, 3, 4);
            this.NAD_C080_3036 = Helper.GetElementValue(valores, 4, 0);
            this.NAD_C080_3036_2 = Helper.GetElementValue(valores, 4, 1);
            this.NAD_C080_3036_3 = Helper.GetElementValue(valores, 4, 2);
            this.NAD_C080_3036_4 = Helper.GetElementValue(valores, 4, 3);
            this.NAD_C080_3036_5 = Helper.GetElementValue(valores, 4, 4);
            this.NAD_C080_3045 = Helper.GetElementValue(valores, 4, 5);
            this.NAD_C059_3042 = Helper.GetElementValue(valores, 5, 0);
            this.NAD_C059_3042_2 = Helper.GetElementValue(valores, 5, 1);
            this.NAD_C059_3042_3 = Helper.GetElementValue(valores, 5, 2);
            this.NAD_C059_3042_4 = Helper.GetElementValue(valores, 5, 3);
            this.NAD_3164 = Helper.GetElementValue(valores, 6, 0);
            this.NAD_3229 = Helper.GetElementValue(valores, 7, 0);
            this.NAD_C819_1131 = Helper.GetElementValue(valores, 7, 1);
            this.NAD_C819_3055 = Helper.GetElementValue(valores, 7, 2);
            this.NAD_C819_3228 = Helper.GetElementValue(valores, 7, 3);
            this.NAD_3251 = Helper.GetElementValue(valores, 8, 0);
            this.NAD_3207 = Helper.GetElementValue(valores, 9, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("NAD"
                                    , string.Format("NAD{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{1}{10}{1}{11}{0}{12}{1}{13}{1}{14}{1}{15}{1}{16}{1}{17}{0}{18}{1}{19}{1}{20}{1}{21}{0}{22}{0}{23}{1}{24}{1}{25}{1}{26}{0}{27}{0}{28}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(NAD_3035, Properties)
                                        , Helper.ReleaseValue(NAD_C082_3039, Properties)
                                        , Helper.ReleaseValue(NAD_C082_1131, Properties)
                                        , Helper.ReleaseValue(NAD_C082_3055, Properties)
                                        , Helper.ReleaseValue(NAD_C058_3124, Properties)
                                        , Helper.ReleaseValue(NAD_C058_3124_2, Properties)
                                        , Helper.ReleaseValue(NAD_C058_3124_3, Properties)
                                        , Helper.ReleaseValue(NAD_C058_3124_4, Properties)
                                        , Helper.ReleaseValue(NAD_C058_3124_5, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3036, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3036_2, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3036_3, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3036_4, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3036_5, Properties)
                                        , Helper.ReleaseValue(NAD_C080_3045, Properties)
                                        , Helper.ReleaseValue(NAD_C059_3042, Properties)
                                        , Helper.ReleaseValue(NAD_C059_3042_2, Properties)
                                        , Helper.ReleaseValue(NAD_C059_3042_3, Properties)
                                        , Helper.ReleaseValue(NAD_C059_3042_4, Properties)
                                        , Helper.ReleaseValue(NAD_3164, Properties)
                                        , Helper.ReleaseValue(NAD_3229, Properties)
                                        , Helper.ReleaseValue(NAD_C819_1131, Properties)
                                        , Helper.ReleaseValue(NAD_C819_3055, Properties)
                                        , Helper.ReleaseValue(NAD_C819_3228, Properties)
                                        , Helper.ReleaseValue(NAD_3251, Properties)
                                        , Helper.ReleaseValue(NAD_3207, Properties)
                                    ), Properties);
        }

        #endregion
    }
}