using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento COM</summary>
    public class COM : EDISegmentBase
    {
        #region C076

        #region 3148

        /// <summary>N�mero de Comunicaci�n</summary>
        public string COM_C076_3148 { get; set; }

        #endregion // Fin-3148

        #region 3155

        /// <summary>Calificador de Canal de Comunicaci�n</summary>
        public string COM_C076_3155 { get; set; }

        #endregion // Fin-3155

        #endregion // Fin-C076

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.COM_C076_3148 = Helper.GetElementValue(valores, 1, 0);
            this.COM_C076_3155 = Helper.GetElementValue(valores, 1, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("COM"
                                    , string.Format("COM{0}{3}{1}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(COM_C076_3148, Properties)
                                        , Helper.ReleaseValue(COM_C076_3155, Properties)
                                    ), Properties);
        }

        #endregion
    }
}