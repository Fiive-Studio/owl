using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento RTE</summary>
    public class RTE : EDISegmentBase
    {
        #region C128

        #region 5419

        /// <summary>Calificador del Tipo de Tasa</summary>
        public string RTE_C128_5419 { get; set; }

        #endregion // Fin-5419

        #region 5420

        /// <summary>Tasa por Unidad</summary>
        public string RTE_C128_5420 { get; set; }

        #endregion // Fin-5420

        #region 5284

        /// <summary>Base Precio Unitario</summary>
        public string RTE_C128_5284 { get; set; }

        #endregion // Fin-5284

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string RTE_C128_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C128

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.RTE_C128_5419 = Helper.GetElementValue(valores, 1, 0);
            this.RTE_C128_5420 = Helper.GetElementValue(valores, 1, 1);
            this.RTE_C128_5284 = Helper.GetElementValue(valores, 1, 2);
            this.RTE_C128_6411 = Helper.GetElementValue(valores, 1, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("RTE"
                                    , string.Format("RTE{0}{3}{1}{4}{1}{5}{1}{6}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(RTE_C128_5419, Properties)
                                        , Helper.ReleaseValue(RTE_C128_5420, Properties)
                                        , Helper.ReleaseValue(RTE_C128_5284, Properties)
                                        , Helper.ReleaseValue(RTE_C128_6411, Properties)
                                    ), Properties);
        }

        #endregion
    }
}