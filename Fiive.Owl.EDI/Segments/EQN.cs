using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento EQN</summary>
    public class EQN : EDISegmentBase
    {
        #region C523

        #region 6350

        /// <summary>N�mero de Unidades</summary>
        public string EQN_C523_6350 { get; set; }

        #endregion // Fin-6350

        #region 6353

        /// <summary>Calificador de N�mero de Unidades</summary>
        public string EQN_C523_6353 { get; set; }

        #endregion // Fin-6353

        #endregion // Fin-C523

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.EQN_C523_6350 = Helper.GetElementValue(valores, 1, 0);
            this.EQN_C523_6353 = Helper.GetElementValue(valores, 1, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("EQN"
                                    , string.Format("EQN{0}{3}{1}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(EQN_C523_6350, Properties)
                                        , Helper.ReleaseValue(EQN_C523_6353, Properties)
                                    ), Properties);
        }

        #endregion
    }
}