using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PGI</summary>
    public class PGI : EDISegmentBase
    {
        #region 5379

        /// <summary>Tipo de Tarifa o Precio, Codificado</summary>
        public string PGI_5379 { get; set; }

        #endregion // Fin-5379

        #region C288

        #region 5389

        /// <summary>Grupo de Precios, Codificado</summary>
        public string PGI_C288_5389 { get; set; }

        #endregion // Fin-5389

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PGI_C288_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PGI_C288_3055 { get; set; }

        #endregion // Fin-3055

        #region 5388

        /// <summary>Grupo de Precios</summary>
        public string PGI_C288_5388 { get; set; }

        #endregion // Fin-5388

        #endregion // Fin-C288

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PGI_5379 = Helper.GetElementValue(valores, 1, 0);
            this.PGI_C288_5389 = Helper.GetElementValue(valores, 2, 0);
            this.PGI_C288_1131 = Helper.GetElementValue(valores, 2, 1);
            this.PGI_C288_3055 = Helper.GetElementValue(valores, 2, 2);
            this.PGI_C288_5388 = Helper.GetElementValue(valores, 2, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PGI"
                                    , string.Format("PGI{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PGI_5379, Properties)
                                        , Helper.ReleaseValue(PGI_C288_5389, Properties)
                                        , Helper.ReleaseValue(PGI_C288_1131, Properties)
                                        , Helper.ReleaseValue(PGI_C288_3055, Properties)
                                        , Helper.ReleaseValue(PGI_C288_5388, Properties)
                                    ), Properties);
        }

        #endregion
    }
}