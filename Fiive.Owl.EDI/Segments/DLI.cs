using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento DLI</summary>
    public class DLI : EDISegmentBase
    {
        #region 1073

        /// <summary>Indicador de L�nea del Documento, Codificado</summary>
        public string DLI_1073 { get; set; }

        #endregion // Fin-1073

        #region 1082

        /// <summary>N�mero de L�nea de Art�culo</summary>
        public string DLI_1082 { get; set; }

        #endregion // Fin-1082

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.DLI_1073 = Helper.GetElementValue(valores, 1, 0);
            this.DLI_1082 = Helper.GetElementValue(valores, 2, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DLI"
                                    , string.Format("DLI{0}{3}{0}{4}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(DLI_1073, Properties)
                                        , Helper.ReleaseValue(DLI_1082, Properties)
                                    ), Properties);
        }

        #endregion
    }
}