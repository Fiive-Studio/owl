using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento TMP</summary>
    public class TMP : EDISegmentBase
    {
        #region 6245

        /// <summary>Calificador de Temperatura</summary>
        public string TMP_6245 { get; set; }

        #endregion // Fin-6245

        #region C239

        #region 6246

        /// <summary>Especificaci�n de Temperatura</summary>
        public string TMP_C239_6246 { get; set; }

        #endregion // Fin-6246

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string TMP_C239_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C239

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.TMP_6245 = Helper.GetElementValue(valores, 1, 0);
            this.TMP_C239_6246 = Helper.GetElementValue(valores, 2, 0);
            this.TMP_C239_6411 = Helper.GetElementValue(valores, 2, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TMP"
                                    , string.Format("TMP{0}{3}{0}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(TMP_6245, Properties)
                                        , Helper.ReleaseValue(TMP_C239_6246, Properties)
                                        , Helper.ReleaseValue(TMP_C239_6411, Properties)
                                    ), Properties);
        }

        #endregion
    }
}