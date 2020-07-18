using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento IMD</summary>
    public class IMD : EDISegmentBase
    {
        #region 7077

        /// <summary>Tipo de Descripci�n de Art�culo, Codificado</summary>
        public string IMD_7077 { get; set; }

        #endregion // Fin-7077

        #region 7081

        /// <summary>Caracter�stica del Art�culo, Codificado</summary>
        public string IMD_7081 { get; set; }

        public string IMD_C272_1131 { get; set; }

        public string IMD_C272_3055 { get; set; }

        #endregion // Fin-7081

        #region C273

        #region 7009

        /// <summary>Descripci�n del Art�culo, Codificado</summary>
        public string IMD_C273_7009 { get; set; }

        #endregion // Fin-7009

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string IMD_C273_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string IMD_C273_3055 { get; set; }

        #endregion // Fin-3055

        #region 7008

        /// <summary>Descripci�n del Art�culo 1</summary>
        public string IMD_C273_7008 { get; set; }

        #endregion // Fin-7008

        #region 7008_2

        /// <summary>Descripci�n del Art�culo 2</summary>
        public string IMD_C273_7008_2 { get; set; }

        #endregion // Fin-7008_2

        #region 3453

        /// <summary>Idioma, Codificado</summary>
        public string IMD_C273_3453 { get; set; }

        #endregion // Fin-3453

        #endregion // Fin-C273

        #region 7383

        /// <summary>Indicador de Superficie o Capa</summary>
        public string IMD_7383 { get; set; }

        #endregion // Fin-7383

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.IMD_7077 = Helper.GetElementValue(valores, 1, 0);
            this.IMD_7081 = Helper.GetElementValue(valores, 2, 0);
            this.IMD_C272_1131 = Helper.GetElementValue(valores, 2, 1);
            this.IMD_C272_3055 = Helper.GetElementValue(valores, 2, 2);
            this.IMD_C273_7009 = Helper.GetElementValue(valores, 3, 0);
            this.IMD_C273_1131 = Helper.GetElementValue(valores, 3, 1);
            this.IMD_C273_3055 = Helper.GetElementValue(valores, 3, 2);
            this.IMD_C273_7008 = Helper.GetElementValue(valores, 3, 3);
            this.IMD_C273_7008_2 = Helper.GetElementValue(valores, 3, 4);
            this.IMD_C273_3453 = Helper.GetElementValue(valores, 3, 5);
            this.IMD_7383 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("IMD"
                                    , string.Format("IMD{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{1}{10}{1}{11}{1}{12}{0}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(IMD_7077, Properties)
                                        , Helper.ReleaseValue(IMD_7081, Properties)
                                        , Helper.ReleaseValue(IMD_C272_1131, Properties)
                                        , Helper.ReleaseValue(IMD_C272_3055, Properties)
                                        , Helper.ReleaseValue(IMD_C273_7009, Properties)
                                        , Helper.ReleaseValue(IMD_C273_1131, Properties)
                                        , Helper.ReleaseValue(IMD_C273_3055, Properties)
                                        , Helper.ReleaseValue(IMD_C273_7008, Properties)
                                        , Helper.ReleaseValue(IMD_C273_7008_2, Properties)
                                        , Helper.ReleaseValue(IMD_C273_3453, Properties)
                                        , Helper.ReleaseValue(IMD_7383, Properties)
                                    ), Properties);
        }

        #endregion
    }
}