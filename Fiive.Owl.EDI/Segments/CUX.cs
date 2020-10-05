using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CUX</summary>
    public class CUX : EDISegmentBase
    {
        #region C504

        #region 6347

        /// <summary>Calificador de Informaci�n de Divisas</summary>
        public string CUX_C504_6347 { get; set; }

        #endregion // Fin-6347

        #region 6345

        /// <summary>Moneda, Codificado</summary>
        public string CUX_C504_6345 { get; set; }

        #endregion // Fin-6345

        #region 6343

        /// <summary>Calificador de Moneda</summary>
        public string CUX_C504_6343 { get; set; }

        #endregion // Fin-6343

        #region 6348

        /// <summary>Base de Cambio de Divisas</summary>
        public string CUX_C504_6348 { get; set; }

        #endregion // Fin-6348

        #endregion // Fin-C504

        #region C504

        #region 6347_2

        /// <summary>Calificador de Informaci�n de Divisas</summary>
        public string CUX_C504_6347_2 { get; set; }

        #endregion // Fin-6347_2

        #region 6345_2

        /// <summary>Moneda, Codificado</summary>
        public string CUX_C504_6345_2 { get; set; }

        #endregion // Fin-6345_2

        #region 6343_2

        /// <summary>Calificador de Moneda</summary>
        public string CUX_C504_6343_2 { get; set; }

        #endregion // Fin-6343_2

        #region 6348_2

        /// <summary>Base de Cambio de Divisas</summary>
        public string CUX_C504_6348_2 { get; set; }

        #endregion // Fin-6348_2

        #endregion // Fin-C504

        #region 5402

        /// <summary>Tasa de Cambio</summary>
        public string CUX_5402 { get; set; }

        #endregion // Fin-5402

        #region 6341

        /// <summary>Mercado de Cambio de Moneda, Codificado</summary>
        public string CUX_6341 { get; set; }

        #endregion // Fin-6341

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CUX_C504_6347 = Helper.GetElementValue(valores, 1, 0);
            this.CUX_C504_6345 = Helper.GetElementValue(valores, 1, 1);
            this.CUX_C504_6343 = Helper.GetElementValue(valores, 1, 2);
            this.CUX_C504_6348 = Helper.GetElementValue(valores, 1, 3);
            this.CUX_C504_6347_2 = Helper.GetElementValue(valores, 2, 0);
            this.CUX_C504_6345_2 = Helper.GetElementValue(valores, 2, 1);
            this.CUX_C504_6343_2 = Helper.GetElementValue(valores, 2, 2);
            this.CUX_C504_6348_2 = Helper.GetElementValue(valores, 2, 3);
            this.CUX_5402 = Helper.GetElementValue(valores, 3, 0);
            this.CUX_6341 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Segmentos

        /// <summary>Lista DTMs</summary>
        public List<DTM> DTMs { get; set; }

        #endregion // Fin-Segmentos

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CUX"
                                    , string.Format("CUX{0}{3}{1}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{1}{10}{0}{11}{0}{12}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CUX_C504_6347, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6345, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6343, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6348, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6347_2, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6345_2, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6343_2, Properties)
                                        , Helper.ReleaseValue(CUX_C504_6348_2, Properties)
                                        , Helper.ReleaseValue(CUX_5402, Properties)
                                        , Helper.ReleaseValue(CUX_6341, Properties)
                                    ), Properties);
        }

        #endregion
    }
}