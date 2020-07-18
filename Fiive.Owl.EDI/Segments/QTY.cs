using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento QTY</summary>
    public class QTY : EDISegmentBase
    {
        #region C186

        #region 6063

        /// <summary>Calificador de Cantidad</summary>
        public string QTY_C186_6063 { get; set; }

        #endregion // Fin-6063

        #region 6060

        /// <summary>Cantidad</summary>
        public string QTY_C186_6060 { get; set; }

        #endregion // Fin-6060

        #region 6411

        /// <summary>Especificador de Unidad de Medida</summary>
        public string QTY_C186_6411 { get; set; }

        #endregion // Fin-6411

        #endregion // Fin-C186

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.QTY_C186_6063 = Helper.GetElementValue(valores, 1, 0);
            this.QTY_C186_6060 = Helper.GetElementValue(valores, 1, 1);
            this.QTY_C186_6411 = Helper.GetElementValue(valores, 1, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("QTY"
                                    , string.Format("QTY{0}{3}{1}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(QTY_C186_6063, Properties)
                                        , Helper.ReleaseValue(QTY_C186_6060, Properties)
                                        , Helper.ReleaseValue(QTY_C186_6411, Properties)
                                    ), Properties);
        }

        #endregion
    }
}