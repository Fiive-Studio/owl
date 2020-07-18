using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento MOA</summary>
    public class MOA : EDISegmentBase
    {
        #region C516

        #region 5025

        /// <summary>Calificador de Tipo de Importe Monetario</summary>
        public string MOA_C516_5025 { get; set; }

        #endregion // Fin-5025

        #region 5004

        /// <summary>Importe Monetario</summary>
        public string MOA_C516_5004 { get; set; }

        #endregion // Fin-5004

        #region 6345

        /// <summary>Moneda, Codificado</summary>
        public string MOA_C516_6345 { get; set; }

        #endregion // Fin-6345

        #region 6343

        /// <summary>Calificador de Moneda</summary>
        public string MOA_C516_6343 { get; set; }

        #endregion // Fin-6343

        #region 4405

        /// <summary>Categor�a, Codificada</summary>
        public string MOA_C516_4405 { get; set; }

        #endregion // Fin-4405

        #endregion // Fin-C516

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.MOA_C516_5025 = Helper.GetElementValue(valores, 1, 0);
            this.MOA_C516_5004 = Helper.GetElementValue(valores, 1, 1);
            this.MOA_C516_6345 = Helper.GetElementValue(valores, 1, 2);
            this.MOA_C516_6343 = Helper.GetElementValue(valores, 1, 3);
            this.MOA_C516_4405 = Helper.GetElementValue(valores, 1, 4);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("MOA"
                                    , string.Format("MOA{0}{3}{1}{4}{1}{5}{1}{6}{1}{7}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(MOA_C516_5025, Properties)
                                        , Helper.ReleaseValue(MOA_C516_5004, Properties)
                                        , Helper.ReleaseValue(MOA_C516_6345, Properties)
                                        , Helper.ReleaseValue(MOA_C516_6343, Properties)
                                        , Helper.ReleaseValue(MOA_C516_4405, Properties)
                                    ), Properties);
        }

        #endregion
    }
}