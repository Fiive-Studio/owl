using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CTA</summary>
    public class CTA : EDISegmentBase
    {
        #region 3139

        /// <summary>Funci�n de Contacto, Codificado</summary>
        public string CTA_3139 { get; set; }

        #endregion // Fin-3139

        #region C056

        #region 3413

        /// <summary>Departamento o Empleado, Codificado</summary>
        public string CTA_C056_3413 { get; set; }

        #endregion // Fin-3413

        #region 3412

        /// <summary>Departamento o Empleado</summary>
        public string CTA_C056_3412 { get; set; }

        #endregion // Fin-3412

        #endregion // Fin-C056

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CTA_3139 = Helper.GetElementValue(valores, 1, 0);
            this.CTA_C056_3413 = Helper.GetElementValue(valores, 2, 0);
            this.CTA_C056_3412 = Helper.GetElementValue(valores, 2, 1);
        }

		#endregion

        #region Segmentos

        /// <summary>Lista COMs</summary>
        public List<COM> COMs { get; set; }

        #endregion // Fin-Segmentos

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CTA"
                                    , string.Format("CTA{0}{3}{0}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CTA_3139, Properties)
                                        , Helper.ReleaseValue(CTA_C056_3413, Properties)
                                        , Helper.ReleaseValue(CTA_C056_3412, Properties)
                                    ), Properties);
        }

        #endregion
    }
}