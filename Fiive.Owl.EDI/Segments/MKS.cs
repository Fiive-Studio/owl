using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento MKS</summary>
    public class MKS : EDISegmentBase
    {
        #region 7293

        /// <summary>Identificaci�n del Sector</summary>
        public string MKS_7293 { get; set; }

        #endregion // Fin-7293

        #region C332

        #region 3496

        /// <summary>Identificador del Canal de Ventas</summary>
        public string MKS_C332_3496 { get; set; }

        #endregion // Fin-3496

        #endregion // Fin-C332

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.MKS_7293 = Helper.GetElementValue(valores, 1, 0);
            this.MKS_C332_3496 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MKS"
                                    , string.Format("MKS{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(MKS_7293, Properties)
                                        , Helper.ReleaseValue(MKS_C332_3496, Properties)
                                    ), Properties);
        }

        #endregion
    }
}