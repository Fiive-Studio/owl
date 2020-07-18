using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento CDI</summary>
    public class CDI : EDISegmentBase
    {
        #region 7001

        /// <summary>Calificador de Estado F�sico o L�gico</summary>
        public string CDI_7001 { get; set; }

        #endregion // Fin-7001

        #region C564

        #region 7007

        /// <summary>Estado F�sico o L�gico, Codificado</summary>
        public string CDI_C564_7007 { get; set; }

        #endregion // Fin-7007

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string CDI_C564_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string CDI_C564_3055 { get; set; }

        #endregion // Fin-3055

        #region 7006

        /// <summary>Estado F�sico o L�gico</summary>
        public string CDI_C564_7006 { get; set; }

        #endregion // Fin-7006

        #endregion // Fin-C564

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.CDI_7001 = Helper.GetElementValue(valores, 1, 0);
            this.CDI_C564_7007 = Helper.GetElementValue(valores, 2, 0);
            this.CDI_C564_1131 = Helper.GetElementValue(valores, 2, 1);
            this.CDI_C564_3055 = Helper.GetElementValue(valores, 2, 2);
            this.CDI_C564_7006 = Helper.GetElementValue(valores, 2, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("CDI"
                                    , string.Format("CDI{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(CDI_7001, Properties)
                                        , Helper.ReleaseValue(CDI_C564_7007, Properties)
                                        , Helper.ReleaseValue(CDI_C564_1131, Properties)
                                        , Helper.ReleaseValue(CDI_C564_3055, Properties)
                                        , Helper.ReleaseValue(CDI_C564_7006, Properties)
                                    ), Properties);
        }

        #endregion
    }
}