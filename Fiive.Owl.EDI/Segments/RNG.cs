using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento RNG</summary>
    public class RNG : EDISegmentBase
    {
        #region 6167

        /// <summary>Calificador de Tipo de Rango</summary>
        public string RNG_6167 { get; set; }

        #endregion // Fin-6167

        #region C280

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string RNG_C280_6411 { get; set; }

        #endregion // Fin-6411

        #region 6162

        /// <summary>L�mite Inferior</summary>
        public string RNG_C280_6162 { get; set; }

        #endregion // Fin-6162

        #region 6152

        /// <summary>L�mite Superior</summary>
        public string RNG_C280_6152 { get; set; }

        #endregion // Fin-6152

        #endregion // Fin-C280

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.RNG_6167 = Helper.GetElementValue(valores, 1, 0);
            this.RNG_C280_6411 = Helper.GetElementValue(valores, 2, 0);
            this.RNG_C280_6162 = Helper.GetElementValue(valores, 2, 1);
            this.RNG_C280_6152 = Helper.GetElementValue(valores, 2, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("RNG"
                                    , string.Format("RNG{0}{3}{0}{4}{1}{5}{1}{6}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(RNG_6167, Properties)
                                        , Helper.ReleaseValue(RNG_C280_6411, Properties)
                                        , Helper.ReleaseValue(RNG_C280_6162, Properties)
                                        , Helper.ReleaseValue(RNG_C280_6152, Properties)
                                    ), Properties);
        }

        #endregion
    }
}