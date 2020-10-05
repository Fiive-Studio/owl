using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento STG</summary>
    public class STG : EDISegmentBase
    {
        #region 9421

        /// <summary>Calificador Etapa de Proceso</summary>
        public string STG_9421 { get; set; }

        #endregion // Fin-9421

        #region 6426

        /// <summary>Cantidad de Etapas de Proceso</summary>
        public string STG_6426 { get; set; }

        #endregion // Fin-6426

        #region 6428

        /// <summary>Cantidad Real de Etapas de Proceso</summary>
        public string STG_6428 { get; set; }

        #endregion // Fin-6428

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.STG_9421 = Helper.GetElementValue(valores, 1, 0);
            this.STG_6426 = Helper.GetElementValue(valores, 2, 0);
            this.STG_6428 = Helper.GetElementValue(valores, 3, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("STG"
                                    , string.Format("STG{0}{3}{0}{4}{0}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(STG_9421, Properties)
                                        , Helper.ReleaseValue(STG_6426, Properties)
                                        , Helper.ReleaseValue(STG_6428, Properties)
                                    ), Properties);
        }

        #endregion
    }
}