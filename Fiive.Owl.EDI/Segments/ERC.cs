using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento ERC</summary>
    public class ERC : EDISegmentBase
    {
        #region C901

        #region 9321

        /// <summary>Error de Aplicaci�n, Codificado</summary>
        public string ERC_C901_9321 { get; set; }

        #endregion // Fin-9321

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string ERC_C901_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string ERC_C901_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C901

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.ERC_C901_9321 = Helper.GetElementValue(valores, 1, 0);
            this.ERC_C901_1131 = Helper.GetElementValue(valores, 1, 1);
            this.ERC_C901_3055 = Helper.GetElementValue(valores, 1, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ERC"
                                    , string.Format("ERC{0}{3}{1}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(ERC_C901_9321, Properties)
                                        , Helper.ReleaseValue(ERC_C901_1131, Properties)
                                        , Helper.ReleaseValue(ERC_C901_3055, Properties)
                                    ), Properties);
        }

        #endregion
    }
}