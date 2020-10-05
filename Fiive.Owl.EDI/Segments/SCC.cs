using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento SCC</summary>
    public class SCC : EDISegmentBase
    {
        #region 4017

        /// <summary>Indicador de Categor�a del Plan de Entrega</summary>
        public string SCC_4017 { get; set; }

        #endregion // Fin-4017

        #region 4493

        /// <summary>Requerimientos de Entrega, Codificado</summary>
        public string SCC_4493 { get; set; }

        #endregion // Fin-4493

        #region C329

        #region 2013

        /// <summary>Frecuencia, Codificado</summary>
        public string SCC_C329_2013 { get; set; }

        #endregion // Fin-2013

        #region 2015

        /// <summary>Patr�n de Env�o, Codificado</summary>
        public string SCC_C329_2015 { get; set; }

        #endregion // Fin-2015

        #region 2017

        /// <summary>Programaci�n del Patr�n de Env�o, Codificado</summary>
        public string SCC_C329_2017 { get; set; }

        #endregion // Fin-2017

        #endregion // Fin-C329

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.SCC_4017 = Helper.GetElementValue(valores, 1, 0);
            this.SCC_4493 = Helper.GetElementValue(valores, 2, 0);
            this.SCC_C329_2013 = Helper.GetElementValue(valores, 3, 0);
            this.SCC_C329_2015 = Helper.GetElementValue(valores, 3, 1);
            this.SCC_C329_2017 = Helper.GetElementValue(valores, 3, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SCC"
                                    , string.Format("SCC{0}{3}{0}{4}{0}{5}{1}{6}{1}{7}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(SCC_4017, Properties)
                                        , Helper.ReleaseValue(SCC_4493, Properties)
                                        , Helper.ReleaseValue(SCC_C329_2013, Properties)
                                        , Helper.ReleaseValue(SCC_C329_2015, Properties)
                                        , Helper.ReleaseValue(SCC_C329_2017, Properties)
                                    ), Properties);
        }

        #endregion
    }
}