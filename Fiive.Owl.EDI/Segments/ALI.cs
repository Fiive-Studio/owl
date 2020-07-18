using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento ALI</summary>
    public class ALI : EDISegmentBase
    {
        #region 3239

        /// <summary>Pa�s de Origen, Codificado</summary>
        public string ALI_3239 { get; set; }

        #endregion // Fin-3239

        #region 9213

        /// <summary>Tipo de R�gimen Arancelario, Codificado</summary>
        public string ALI_9213 { get; set; }

        #endregion // Fin-9213

        #region 4183

        /// <summary>Condiciones Especiales, Codificado 1</summary>
        public string ALI_4183 { get; set; }

        #endregion // Fin-4183

        #region 4183_2

        /// <summary>Condiciones Especiales, Codificado 2</summary>
        public string ALI_4183_2 { get; set; }

        #endregion // Fin-4183_2

        #region 4183_3

        /// <summary>Condiciones Especiales, Codificado 3</summary>
        public string ALI_4183_3 { get; set; }

        #endregion // Fin-4183_3

        #region 4183_4

        /// <summary>Condiciones Especiales, Codificado 4</summary>
        public string ALI_4183_4 { get; set; }

        #endregion // Fin-4183_4

        #region 4183_5

        /// <summary>Condiciones Especiales, Codificado 5</summary>
        public string ALI_4183_5 { get; set; }

        #endregion // Fin-4183_5

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.ALI_3239 = Helper.GetElementValue(valores, 1, 0);
            this.ALI_9213 = Helper.GetElementValue(valores, 2, 0);
            this.ALI_4183 = Helper.GetElementValue(valores, 3, 0);
            this.ALI_4183_2 = Helper.GetElementValue(valores, 4, 0);
            this.ALI_4183_3 = Helper.GetElementValue(valores, 5, 0);
            this.ALI_4183_4 = Helper.GetElementValue(valores, 6, 0);
            this.ALI_4183_5 = Helper.GetElementValue(valores, 7, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("ALI"
                                    , string.Format("ALI{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(ALI_3239, Properties)
                                        , Helper.ReleaseValue(ALI_9213, Properties)
                                        , Helper.ReleaseValue(ALI_4183, Properties)
                                        , Helper.ReleaseValue(ALI_4183_2, Properties)
                                        , Helper.ReleaseValue(ALI_4183_3, Properties)
                                        , Helper.ReleaseValue(ALI_4183_4, Properties)
                                        , Helper.ReleaseValue(ALI_4183_5, Properties)
                                    ), Properties);
        }

        #endregion
    }
}