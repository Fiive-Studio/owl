using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;
using System.Xml.Serialization;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNH</summary>
    public class UNH : EDISegmentBase
    {
        #region 0062

        /// <summary>N�mero de Referencia del Mensaje</summary>
        public string UNH_0062 { get; set; }

        #endregion // Fin-0062

        #region S009

        #region 0065

        /// <summary>Identificador del Tipo de Mensaje</summary>
        public string UNH_S009_0065 { get; set; }

        #endregion // Fin-0065

        #region 0052

        /// <summary>N�mero de Versi�n del Tipo de Mensaje</summary>
        public string UNH_S009_0052 { get; set; }

        #endregion // Fin-0052

        #region 0054

        /// <summary>N�mero de Sub-Versi�n del Tipo de Mensaje</summary>
        public string UNH_S009_0054 { get; set; }

        #endregion // Fin-0054

        #region 0051

        /// <summary>Agencia Controladora</summary>
        public string UNH_S009_0051 { get; set; }

        #endregion // Fin-0051

        #region 0057

        /// <summary>C�digo Asignado por la Asociaci�n</summary>
        public string UNH_S009_0057 { get; set; }

        #endregion // Fin-0057

        #endregion // Fin-S009

        #region 0068

        /// <summary>Referencia de Acceso Com�n</summary>
        public string UNH_0068 { get; set; }

        #endregion // Fin-0068

        #region S010

        #region 0070

        /// <summary>N�mero de Secuencia de Transferencia del Mensaje</summary>
        public string UNH_S010_0070 { get; set; }

        #endregion // Fin-0070

        #region 0073

        /// <summary>Indicador de Primer/Ultimo Mensaje de una Secuencia</summary>
        public string UNH_S010_0073 { get; set; }

        #endregion // Fin-0073

        #endregion // Fin-S010

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNH_0062 = Helper.GetElementValue(valores, 1, 0);
            this.UNH_S009_0065 = Helper.GetElementValue(valores, 2, 0);
            this.UNH_S009_0052 = Helper.GetElementValue(valores, 2, 1);
            this.UNH_S009_0054 = Helper.GetElementValue(valores, 2, 2);
            this.UNH_S009_0051 = Helper.GetElementValue(valores, 2, 3);
            this.UNH_S009_0057 = Helper.GetElementValue(valores, 2, 4);
            this.UNH_0068 = Helper.GetElementValue(valores, 3, 0);
            this.UNH_S010_0070 = Helper.GetElementValue(valores, 4, 0);
            this.UNH_S010_0073 = Helper.GetElementValue(valores, 4, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNH"
                                    , string.Format("UNH{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{0}{10}{1}{11}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNH_0062, Properties)
                                        , Helper.ReleaseValue(UNH_S009_0065, Properties)
                                        , Helper.ReleaseValue(UNH_S009_0052, Properties)
                                        , Helper.ReleaseValue(UNH_S009_0054, Properties)
                                        , Helper.ReleaseValue(UNH_S009_0051, Properties)
                                        , Helper.ReleaseValue(UNH_S009_0057, Properties)
                                        , Helper.ReleaseValue(UNH_0068, Properties)
                                        , Helper.ReleaseValue(UNH_S010_0070, Properties)
                                        , Helper.ReleaseValue(UNH_S010_0073, Properties)
                                    ), Properties);
        }

        #endregion
    }
}