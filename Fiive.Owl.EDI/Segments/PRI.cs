using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PRI</summary>
    public class PRI : EDISegmentBase
    {
        #region C509

        #region 5125

        /// <summary>Calificador de Precio</summary>
        public string PRI_C509_5125 { get; set; }

        #endregion // Fin-5125

        #region 5118

        /// <summary>Precio</summary>
        public string PRI_C509_5118 { get; set; }

        #endregion // Fin-5118

        #region 5375

        /// <summary>Tipo de Precio, Codificado</summary>
        public string PRI_C509_5375 { get; set; }

        #endregion // Fin-5375

        #region 5387

        /// <summary>Calificador del Tipo de Precio</summary>
        public string PRI_C509_5387 { get; set; }

        #endregion // Fin-5387

        #region 5284

        /// <summary>Base Precio Unitario</summary>
        public string PRI_C509_5284 { get; set; }

        #endregion // Fin-5284

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string PRI_C509_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C509

        #region 5213

        /// <summary>Cambio de Precio de Sub-l�nea, Codificado</summary>
        public string PRI_5213 { get; set; }

        #endregion // Fin-5213

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PRI_C509_5125 = Helper.GetElementValue(valores, 1, 0);
            this.PRI_C509_5118 = Helper.GetElementValue(valores, 1, 1);
            this.PRI_C509_5375 = Helper.GetElementValue(valores, 1, 2);
            this.PRI_C509_5387 = Helper.GetElementValue(valores, 1, 3);
            this.PRI_C509_5284 = Helper.GetElementValue(valores, 1, 4);
            this.PRI_C509_6411 = Helper.GetElementValue(valores, 1, 5);
            this.PRI_5213 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PRI"
                                    , string.Format("PRI{0}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PRI_C509_5125, Properties)
                                        , Helper.ReleaseValue(PRI_C509_5118, Properties)
                                        , Helper.ReleaseValue(PRI_C509_5375, Properties)
                                        , Helper.ReleaseValue(PRI_C509_5387, Properties)
                                        , Helper.ReleaseValue(PRI_C509_5284, Properties)
                                        , Helper.ReleaseValue(PRI_C509_6411, Properties)
                                        , Helper.ReleaseValue(PRI_5213, Properties)
                                    ), Properties);
        }

        #endregion
    }
}