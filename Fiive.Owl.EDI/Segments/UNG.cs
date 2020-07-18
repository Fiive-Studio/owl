using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNG</summary>
    public class UNG : EDISegmentBase
    {
        #region 0038

        /// <summary>Identificaci�n Grupo Funcional</summary>
        public string UNG_0038 { get; set; }

        #endregion // Fin-0038

        #region S006

        #region 0040

        /// <summary>Identificador del Emisor</summary>
        public string UNG_S006_0040 { get; set; }

        #endregion // Fin-0040

        #region 0007

        /// <summary>Calificador del C�digo de Identificaci�n</summary>
        public string UNG_S006_0007 { get; set; }

        #endregion // Fin-0007

        #endregion // Fin-S006

        #region S007

        #region 0044

        /// <summary>Identificaci�n del Receptor</summary>
        public string UNG_S007_0044 { get; set; }

        #endregion // Fin-0044

        #region 0007

        /// <summary>Calificador del C�digo de Identificaci�n</summary>
        public string UNG_S007_0007 { get; set; }

        #endregion // Fin-0007

        #endregion // Fin-S007

        #region S004

        #region 0017

        /// <summary>Fecha de Generaci�n</summary>
        public string UNG_S004_0017 { get; set; }

        #endregion // Fin-0017

        #region 0019

        /// <summary>Hora y Minutos de Generaci�n</summary>
        public string UNG_S004_0019 { get; set; }

        #endregion // Fin-0019

        #endregion // Fin-S004

        #region 0048

        /// <summary>Referencia de Control del Intercambio</summary>
        public string UNG_0048 { get; set; }

        #endregion // Fin-0048

        #region 0051

        /// <summary>Agencia Controladora</summary>
        public string UNG_0051 { get; set; }

        #endregion // Fin-0051

        #region S008

        #region 0052

        /// <summary>N�mero de Versi�n del Tipo de Mensaje</summary>
        public string UNG_S008_0052 { get; set; }

        #endregion // Fin-0052

        #region 0054

        /// <summary>N�mero de Sub-Versi�n del Tipo de Mensaje</summary>
        public string UNG_S008_0054 { get; set; }

        #endregion // Fin-0054

        #region 0057

        /// <summary>C�digo Asignado por la Asociaci�n</summary>
        public string UNG_S008_0057 { get; set; }

        #endregion // Fin-0057

        #endregion // Fin-S008

        #region 0058

        /// <summary>Password de la Aplicaci�n</summary>
        public string UNG_0058 { get; set; }

        #endregion // Fin-0058

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNG_0038 = Helper.GetElementValue(valores, 1, 0);
            this.UNG_S006_0040 = Helper.GetElementValue(valores, 2, 0);
            this.UNG_S006_0007 = Helper.GetElementValue(valores, 2, 1);
            this.UNG_S007_0044 = Helper.GetElementValue(valores, 3, 0);
            this.UNG_S007_0007 = Helper.GetElementValue(valores, 3, 1);
            this.UNG_S004_0017 = Helper.GetElementValue(valores, 4, 0);
            this.UNG_S004_0019 = Helper.GetElementValue(valores, 4, 1);
            this.UNG_0048 = Helper.GetElementValue(valores, 5, 0);
            this.UNG_0051 = Helper.GetElementValue(valores, 6, 0);
            this.UNG_S008_0052 = Helper.GetElementValue(valores, 7, 0);
            this.UNG_S008_0054 = Helper.GetElementValue(valores, 7, 1);
            this.UNG_S008_0057 = Helper.GetElementValue(valores, 7, 2);
            this.UNG_0058 = Helper.GetElementValue(valores, 8, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNG"
                                    , string.Format("UNG{0}{3}{0}{4}{1}{5}{0}{6}{1}{7}{0}{8}{1}{9}{0}{10}{0}{11}{0}{12}{1}{13}{1}{14}{0}{15}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNG_0038, Properties)
                                        , Helper.ReleaseValue(UNG_S006_0040, Properties)
                                        , Helper.ReleaseValue(UNG_S006_0007, Properties)
                                        , Helper.ReleaseValue(UNG_S007_0044, Properties)
                                        , Helper.ReleaseValue(UNG_S007_0007, Properties)
                                        , Helper.ReleaseValue(UNG_S004_0017, Properties)
                                        , Helper.ReleaseValue(UNG_S004_0019, Properties)
                                        , Helper.ReleaseValue(UNG_0048, Properties)
                                        , Helper.ReleaseValue(UNG_0051, Properties)
                                        , Helper.ReleaseValue(UNG_S008_0052, Properties)
                                        , Helper.ReleaseValue(UNG_S008_0054, Properties)
                                        , Helper.ReleaseValue(UNG_S008_0057, Properties)
                                        , Helper.ReleaseValue(UNG_0058, Properties)
                                    ), Properties);
        }

        #endregion
    }
}