using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNE</summary>
    public class UNE : EDISegmentBase
    {
        #region 0060

        /// <summary>N�mero de Mensajes</summary>
        public string UNE_0060 { get; set; }

        #endregion // Fin-0060

        #region 0048

        /// <summary>Referencia de Control del Intercambio</summary>
        public string UNE_0048 { get; set; }

        #endregion // Fin-0048

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNE_0060 = Helper.GetElementValue(valores, 1, 0);
            this.UNE_0048 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNE"
                                    , string.Format("UNE{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNE_0060, Properties)
                                        , Helper.ReleaseValue(UNE_0048, Properties)
                                    ), Properties);
        }

        #endregion
    }
}