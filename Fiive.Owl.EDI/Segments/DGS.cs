using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento DGS</summary>
    public class DGS : EDISegmentBase
    {
        #region 8273

        /// <summary>Regulaciones de Mercanc�as Peligrosas, Codificado</summary>
        public string DGS_8273 { get; set; }

        #endregion // Fin-8273

        #region C205

        #region 8351

        /// <summary>Identificaci�n de C�digo de Riesgo</summary>
        public string DGS_C205_8351 { get; set; }

        #endregion // Fin-8351

        #region 8078

        /// <summary>N�mero de P�gina de Art�culo o Sustancia Peligrosa</summary>
        public string DGS_C205_8078 { get; set; }

        #endregion // Fin-8078

        #region 8092

        /// <summary>N�mero de Versi�n del C�digo de Riesgo</summary>
        public string DGS_C205_8092 { get; set; }

        #endregion // Fin-8092

        #endregion // Fin-C205

        #region C234

        #region 7124

        /// <summary>N�mero UNDG</summary>
        public string DGS_C234_7124 { get; set; }

        #endregion // Fin-7124

        #region 7088

        /// <summary>Punto de Inflamaci�n de Mercanc�as Peligrosas</summary>
        public string DGS_C234_7088 { get; set; }

        #endregion // Fin-7088

        #endregion // Fin-C234

        #region C223

        #region 7106

        /// <summary>Punto de Inflamaci�n del Env�o</summary>
        public string DGS_C223_7106 { get; set; }

        #endregion // Fin-7106

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string DGS_C223_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C223

        #region 8339

        /// <summary>Grupo de Embalajes, Codificado</summary>
        public string DGS_8339 { get; set; }

        #endregion // Fin-8339

        #region 8364

        /// <summary>N�mero EMS</summary>
        public string DGS_8364 { get; set; }

        #endregion // Fin-8364

        #region 8410

        /// <summary>MFAG</summary>
        public string DGS_8410 { get; set; }

        #endregion // Fin-8410

        #region 8126

        /// <summary>N�mero de Tarjeta TREM</summary>
        public string DGS_8126 { get; set; }

        #endregion // Fin-8126

        #region C235

        #region 8158

        /// <summary>N�mero de Identificaci�n de Riesgo, Parte Superior</summary>
        public string DGS_C235_8158 { get; set; }

        #endregion // Fin-8158

        #region 8186

        /// <summary>N�mero de Identificaci�n de Sustancia, Parte Inferior</summary>
        public string DGS_C235_8186 { get; set; }

        #endregion // Fin-8186

        #endregion // Fin-C235

        #region C236

        #region 8246

        /// <summary>Marcaje con Etiqueta de Mercanc�a Peligrosa 1</summary>
        public string DGS_C236_8246 { get; set; }

        #endregion // Fin-8246

        #region 8246_2

        /// <summary>Marcaje con Etiqueta de Mercanc�a Peligrosa 2</summary>
        public string DGS_C236_8246_2 { get; set; }

        #endregion // Fin-8246_2

        #region 8246_3

        /// <summary>Marcaje con Etiqueta de Mercanc�a Peligrosa 3</summary>
        public string DGS_C236_8246_3 { get; set; }

        #endregion // Fin-8246_3

        #endregion // Fin-C236

        #region 8255

        /// <summary>Instrucci�n de Embalaje, Codificado</summary>
        public string DGS_8255 { get; set; }

        #endregion // Fin-8255

        #region 8325

        /// <summary>Categoria de los Medios de Transporte, Codificado</summary>
        public string DGS_8325 { get; set; }

        #endregion // Fin-8325

        #region 8211

        /// <summary>Permiso de Transporte, Codificado</summary>
        public string DGS_8211 { get; set; }

        #endregion // Fin-8211

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.DGS_8273 = Helper.GetElementValue(valores, 1, 0);
            this.DGS_C205_8351 = Helper.GetElementValue(valores, 2, 0);
            this.DGS_C205_8078 = Helper.GetElementValue(valores, 2, 1);
            this.DGS_C205_8092 = Helper.GetElementValue(valores, 2, 2);
            this.DGS_C234_7124 = Helper.GetElementValue(valores, 3, 0);
            this.DGS_C234_7088 = Helper.GetElementValue(valores, 3, 1);
            this.DGS_C223_7106 = Helper.GetElementValue(valores, 4, 0);
            this.DGS_C223_6411 = Helper.GetElementValue(valores, 4, 1);
            this.DGS_8339 = Helper.GetElementValue(valores, 5, 0);
            this.DGS_8364 = Helper.GetElementValue(valores, 6, 0);
            this.DGS_8410 = Helper.GetElementValue(valores, 7, 0);
            this.DGS_8126 = Helper.GetElementValue(valores, 8, 0);
            this.DGS_C235_8158 = Helper.GetElementValue(valores, 9, 0);
            this.DGS_C235_8186 = Helper.GetElementValue(valores, 9, 1);
            this.DGS_C236_8246 = Helper.GetElementValue(valores, 10, 0);
            this.DGS_C236_8246_2 = Helper.GetElementValue(valores, 10, 1);
            this.DGS_C236_8246_3 = Helper.GetElementValue(valores, 10, 2);
            this.DGS_8255 = Helper.GetElementValue(valores, 11, 0);
            this.DGS_8325 = Helper.GetElementValue(valores, 12, 0);
            this.DGS_8211 = Helper.GetElementValue(valores, 13, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DGS"
                                    , string.Format("DGS{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{0}{9}{1}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{1}{16}{0}{17}{1}{18}{1}{19}{0}{20}{0}{21}{0}{22}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(DGS_8273, Properties)
                                        , Helper.ReleaseValue(DGS_C205_8351, Properties)
                                        , Helper.ReleaseValue(DGS_C205_8078, Properties)
                                        , Helper.ReleaseValue(DGS_C205_8092, Properties)
                                        , Helper.ReleaseValue(DGS_C234_7124, Properties)
                                        , Helper.ReleaseValue(DGS_C234_7088, Properties)
                                        , Helper.ReleaseValue(DGS_C223_7106, Properties)
                                        , Helper.ReleaseValue(DGS_C223_6411, Properties)
                                        , Helper.ReleaseValue(DGS_8339, Properties)
                                        , Helper.ReleaseValue(DGS_8364, Properties)
                                        , Helper.ReleaseValue(DGS_8410, Properties)
                                        , Helper.ReleaseValue(DGS_8126, Properties)
                                        , Helper.ReleaseValue(DGS_C235_8158, Properties)
                                        , Helper.ReleaseValue(DGS_C235_8186, Properties)
                                        , Helper.ReleaseValue(DGS_C236_8246, Properties)
                                        , Helper.ReleaseValue(DGS_C236_8246_2, Properties)
                                        , Helper.ReleaseValue(DGS_C236_8246_3, Properties)
                                        , Helper.ReleaseValue(DGS_8255, Properties)
                                        , Helper.ReleaseValue(DGS_8325, Properties)
                                        , Helper.ReleaseValue(DGS_8211, Properties)
                                    ), Properties);
        }

        #endregion
    }
}