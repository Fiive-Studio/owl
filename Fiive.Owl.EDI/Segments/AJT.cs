using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento AJT</summary>
    public class AJT : EDISegmentBase
    {
        #region 4465

        /// <summary>Raz�n del Ajuste, Codificado</summary>
        public string AJT_4465 { get; set; }

        #endregion // Fin-4465

        #region 1082

        /// <summary>N�mero de L�nea de Art�culo</summary>
        public string AJT_1082 { get; set; }

        #endregion // Fin-1082

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.AJT_4465 = Helper.GetElementValue(valores, 1, 0);
            this.AJT_1082 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("AJT"
                                    , string.Format("AJT{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(AJT_4465, Properties)
                                        , Helper.ReleaseValue(AJT_1082, Properties)
                                    ), Properties);
        }

        #endregion
    }
}