using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CNT</summary>
    public class CNT : EDISegmentBase
    {
        #region C270

        #region 6069

        /// <summary>Calificador de Control</summary>
        public string CNT_C270_6069 { get; set; }

        #endregion // Fin-6069

        #region 6066

        /// <summary>Valor de Control</summary>
        public string CNT_C270_6066 { get; set; }

        #endregion // Fin-6066

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string CNT_C270_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C270

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CNT_C270_6069 = Helper.GetElementValue(valores, 1, 0);
            this.CNT_C270_6066 = Helper.GetElementValue(valores, 1, 1);
            this.CNT_C270_6411 = Helper.GetElementValue(valores, 1, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CNT"
                                    , string.Format("CNT{0}{3}{1}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CNT_C270_6069, Properties)
                                        , Helper.ReleaseValue(CNT_C270_6066, Properties)
                                        , Helper.ReleaseValue(CNT_C270_6411, Properties)
                                    ), Properties);
        }

        #endregion
    }
}