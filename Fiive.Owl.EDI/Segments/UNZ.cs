using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNZ</summary>
    public class UNZ : EDISegmentBase
    {
        #region 0036

        /// <summary>Contador de Control del Intercambio</summary>
        public string UNZ_0036 { get; set; }

        #endregion // Fin-0036

        #region 0020

        /// <summary>Referencia de Control del Intercambio</summary>
        public string UNZ_0020 { get; set; }

        #endregion // Fin-0020

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNZ_0036 = Helper.GetElementValue(valores, 1, 0);
            this.UNZ_0020 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNZ"
                                    , string.Format("UNZ{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNZ_0036, Properties)
                                        , Helper.ReleaseValue(UNZ_0020, Properties)
                                    ), Properties);
        }

        #endregion
    }
}