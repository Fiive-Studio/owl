using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UCS</summary>
    public class UCS : EDISegmentBase
    {
        #region 0096

        /// <summary>Posici�n del Segmento en el Mensaje</summary>
        public string UCS_0096 { get; set; }

        #endregion // Fin-0096

        #region 0085

        /// <summary>Error de Sintaxis, Codificado</summary>
        public string UCS_0085 { get; set; }

        #endregion // Fin-0085

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UCS_0096 = Helper.GetElementValue(valores, 1, 0);
            this.UCS_0085 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UCS"
                                    , string.Format("UCS{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UCS_0096, Properties)
                                        , Helper.ReleaseValue(UCS_0085, Properties)
                                    ), Properties);
        }

        #endregion
    }
}