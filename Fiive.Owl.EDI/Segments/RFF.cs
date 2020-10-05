using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento RFF</summary>
    public class RFF : EDISegmentBase
    {
        #region C506

        #region 1153

        /// <summary>Calificador de Referencia</summary>
        public string RFF_C506_1153 { get; set; }

        #endregion // Fin-1153

        #region 1154

        /// <summary>N�mero de Referencia</summary>
        public string RFF_C506_1154 { get; set; }

        #endregion // Fin-1154

        #region 1156

        /// <summary>N�mero de L�nea</summary>
        public string RFF_C506_1156 { get; set; }

        #endregion // Fin-1156

        #region 4000

        /// <summary>N�mero de Versi�n de una Referencia</summary>
        public string RFF_C506_4000 { get; set; }

        #endregion // Fin-4000

        #endregion // Fin-C506

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.RFF_C506_1153 = Helper.GetElementValue(valores, 1, 0);
            this.RFF_C506_1154 = Helper.GetElementValue(valores, 1, 1);
            this.RFF_C506_1156 = Helper.GetElementValue(valores, 1, 2);
            this.RFF_C506_4000 = Helper.GetElementValue(valores, 1, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("RFF"
                                    , string.Format("RFF{0}{3}{1}{4}{1}{5}{1}{6}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(RFF_C506_1153, Properties)
                                        , Helper.ReleaseValue(RFF_C506_1154, Properties)
                                        , Helper.ReleaseValue(RFF_C506_1156, Properties)
                                        , Helper.ReleaseValue(RFF_C506_4000, Properties)
                                    ), Properties);
        }

        #endregion
    }
}