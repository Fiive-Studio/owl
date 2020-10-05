using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PCD</summary>
    public class PCD : EDISegmentBase
    {
        #region C501

        #region 5245

        /// <summary>Calificador de Porcentaje</summary>
        public string PCD_C501_5245 { get; set; }

        #endregion // Fin-5245

        #region 5482

        /// <summary>Porcentaje</summary>
        public string PCD_C501_5482 { get; set; }

        #endregion // Fin-5482

        #region 5249

        /// <summary>Base del Porcentaje, Codificado</summary>
        public string PCD_C501_5249 { get; set; }

        #endregion // Fin-5249

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PCD_C501_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PCD_C501_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C501

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PCD_C501_5245 = Helper.GetElementValue(valores, 1, 0);
            this.PCD_C501_5482 = Helper.GetElementValue(valores, 1, 1);
            this.PCD_C501_5249 = Helper.GetElementValue(valores, 1, 2);
            this.PCD_C501_1131 = Helper.GetElementValue(valores, 1, 3);
            this.PCD_C501_3055 = Helper.GetElementValue(valores, 1, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PCD"
                                    , string.Format("PCD{0}{3}{1}{4}{1}{5}{1}{6}{1}{7}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PCD_C501_5245, Properties)
                                        , Helper.ReleaseValue(PCD_C501_5482, Properties)
                                        , Helper.ReleaseValue(PCD_C501_5249, Properties)
                                        , Helper.ReleaseValue(PCD_C501_1131, Properties)
                                        , Helper.ReleaseValue(PCD_C501_3055, Properties)
                                    ), Properties);
        }

        #endregion
    }
}