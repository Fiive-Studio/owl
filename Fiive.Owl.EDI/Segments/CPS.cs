using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CPS</summary>
    public class CPS : EDISegmentBase
    {
        #region 7164

        /// <summary>N�mero de Identificaci�n de Jerarqu�a</summary>
        public string CPS_7164 { get; set; }

        #endregion // Fin-7164

        #region 7166

        /// <summary>Identificador del Predecesor Jer�rquico</summary>
        public string CPS_7166 { get; set; }

        #endregion // Fin-7166

        #region 7075

        /// <summary>Nivel de Embalaje, Codificado</summary>
        public string CPS_7075 { get; set; }

        #endregion // Fin-7075

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CPS_7164 = Helper.GetElementValue(valores, 1, 0);
            this.CPS_7166 = Helper.GetElementValue(valores, 2, 0);
            this.CPS_7075 = Helper.GetElementValue(valores, 3, 0);
        }

		#endregion

        #region Segmentos

        /// <summary>Lista PACs</summary>
        public List<PAC> PACs { get; set; }

        /// <summary>Lista LINs</summary>
        public List<LIN> LINs { get; set; }

        #endregion // Fin-Segmentos

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CPS"
                                    , string.Format("CPS{0}{3}{0}{4}{0}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CPS_7164, Properties)
                                        , Helper.ReleaseValue(CPS_7166, Properties)
                                        , Helper.ReleaseValue(CPS_7075, Properties)
                                    ), Properties);
        }

        #endregion
    }
}