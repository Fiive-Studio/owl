using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PAC</summary>
    public class PAC : EDISegmentBase
    {
        #region 7224

        /// <summary>N�mero de Embalajes</summary>
        public string PAC_7224 { get; set; }

        #endregion // Fin-7224

        #region C531

        #region 7075

        /// <summary>Nivel de Embalaje, Codificado</summary>
        public string PAC_C531_7075 { get; set; }

        #endregion // Fin-7075

        #region 7233

        /// <summary>Informaci�n Asociada al Embalaje, Codificado</summary>
        public string PAC_C531_7233 { get; set; }

        #endregion // Fin-7233

        #region 7073

        /// <summary>Acuerdos y Condiciones de Embalaje, Codificado</summary>
        public string PAC_C531_7073 { get; set; }

        #endregion // Fin-7073

        #endregion // Fin-C531

        #region C202

        #region 7065

        /// <summary>Tipo de Embalaje, Codificado</summary>
        public string PAC_C202_7065 { get; set; }

        #endregion // Fin-7065

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PAC_C202_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PAC_C202_3055 { get; set; }

        #endregion // Fin-3055

        #region 7064

        /// <summary>Tipo de Embalajes</summary>
        public string PAC_C202_7064 { get; set; }

        #endregion // Fin-7064

        #endregion // Fin-C202

        #region C402

        #region 7077

        /// <summary>Tipo de Descripci�n de Art�culo, Codificado</summary>
        public string PAC_C402_7077 { get; set; }

        #endregion // Fin-7077

        #region 7064

        /// <summary>Tipo de Embalajes</summary>
        public string PAC_C402_7064 { get; set; }

        #endregion // Fin-7064

        #region 7143

        /// <summary>Tipo de N�mero de Art�culo</summary>
        public string PAC_C402_7143 { get; set; }

        #endregion // Fin-7143

        #region 7064_2

        /// <summary>Tipo de Embalajes</summary>
        public string PAC_C402_7064_2 { get; set; }

        #endregion // Fin-7064_2

        #region 7143_2

        /// <summary>Tipo de N�mero de Art�culo</summary>
        public string PAC_C402_7143_2 { get; set; }

        #endregion // Fin-7143_2

        #endregion // Fin-C402

        #region C532

        #region 8395

        /// <summary>Pago de Transporte de Embalaje Retornable, Codificado</summary>
        public string PAC_C532_8395 { get; set; }

        #endregion // Fin-8395

        #region 8393

        /// <summary>Contenido de Carga de Embalaje Retornable, Codificado</summary>
        public string PAC_C532_8393 { get; set; }

        #endregion // Fin-8393

        #endregion // Fin-C532

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PAC_7224 = Helper.GetElementValue(valores, 1, 0);
            this.PAC_C531_7075 = Helper.GetElementValue(valores, 2, 0);
            this.PAC_C531_7233 = Helper.GetElementValue(valores, 2, 1);
            this.PAC_C531_7073 = Helper.GetElementValue(valores, 2, 2);
            this.PAC_C202_7065 = Helper.GetElementValue(valores, 3, 0);
            this.PAC_C202_1131 = Helper.GetElementValue(valores, 3, 1);
            this.PAC_C202_3055 = Helper.GetElementValue(valores, 3, 2);
            this.PAC_C202_7064 = Helper.GetElementValue(valores, 3, 3);
            this.PAC_C402_7077 = Helper.GetElementValue(valores, 4, 0);
            this.PAC_C402_7064 = Helper.GetElementValue(valores, 4, 1);
            this.PAC_C402_7143 = Helper.GetElementValue(valores, 4, 2);
            this.PAC_C402_7064_2 = Helper.GetElementValue(valores, 4, 3);
            this.PAC_C402_7143_2 = Helper.GetElementValue(valores, 4, 4);
            this.PAC_C532_8395 = Helper.GetElementValue(valores, 5, 0);
            this.PAC_C532_8393 = Helper.GetElementValue(valores, 5, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PAC"
                                    , string.Format("PAC{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{1}{10}{0}{11}{1}{12}{1}{13}{1}{14}{1}{15}{0}{16}{1}{17}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PAC_7224, Properties)
                                        , Helper.ReleaseValue(PAC_C531_7075, Properties)
                                        , Helper.ReleaseValue(PAC_C531_7233, Properties)
                                        , Helper.ReleaseValue(PAC_C531_7073, Properties)
                                        , Helper.ReleaseValue(PAC_C202_7065, Properties)
                                        , Helper.ReleaseValue(PAC_C202_1131, Properties)
                                        , Helper.ReleaseValue(PAC_C202_3055, Properties)
                                        , Helper.ReleaseValue(PAC_C202_7064, Properties)
                                        , Helper.ReleaseValue(PAC_C402_7077, Properties)
                                        , Helper.ReleaseValue(PAC_C402_7064, Properties)
                                        , Helper.ReleaseValue(PAC_C402_7143, Properties)
                                        , Helper.ReleaseValue(PAC_C402_7064_2, Properties)
                                        , Helper.ReleaseValue(PAC_C402_7143_2, Properties)
                                        , Helper.ReleaseValue(PAC_C532_8395, Properties)
                                        , Helper.ReleaseValue(PAC_C532_8393, Properties)
                                    ), Properties);
        }

        #endregion
    }
}