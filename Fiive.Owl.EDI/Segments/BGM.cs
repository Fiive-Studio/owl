using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento BGM</summary>
    public class BGM : EDISegmentBase
    {
        #region C002

        #region 1001

        /// <summary>Nombre del Documento o Mensaje, Codificado</summary>
        public string BGM_C002_1001 { get; set; }

        #endregion // Fin-1001

        #region 1131

        /// <summary>Calificador de Lista de Códigos</summary>
        public string BGM_C002_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de Códigos, Codificado</summary>
        public string BGM_C002_3055 { get; set; }

        #endregion // Fin-3055

        #region 1000

        /// <summary>Nombre del Documento o Mensaje</summary>
        public string BGM_C002_1000 { get; set; }

        #endregion // Fin-1000

        #endregion // Fin-C002

        #region 1004

        /// <summary>Número del Documento o Mensaje</summary>
        public string BGM_1004 { get; set; }

        #endregion // Fin-1004

        #region 1225

        /// <summary>Función del Mensaje, Codificado</summary>
        public string BGM_1225 { get; set; }

        #endregion // Fin-1225

        #region 4343

        /// <summary>Tipo de Respuesta, Codificado</summary>
        public string BGM_4343 { get; set; }

        #endregion // Fin-4343

        #region EDISegmentBase

        public override void LoadContent(string content)
        {
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.BGM_C002_1001 = Helper.GetElementValue(valores, 1, 0);
            this.BGM_C002_1131 = Helper.GetElementValue(valores, 1, 1);
            this.BGM_C002_3055 = Helper.GetElementValue(valores, 1, 2);
            this.BGM_C002_1000 = Helper.GetElementValue(valores, 1, 3);
            this.BGM_1004 = Helper.GetElementValue(valores, 2, 0);
            this.BGM_1225 = Helper.GetElementValue(valores, 3, 0);
            this.BGM_4343 = Helper.GetElementValue(valores, 4, 0);
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BGM"
                                    , string.Format("BGM{0}{3}{1}{4}{1}{5}{1}{6}{0}{7}{0}{8}{0}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(BGM_C002_1001, Properties)
                                        , Helper.ReleaseValue(BGM_C002_1131, Properties)
                                        , Helper.ReleaseValue(BGM_C002_3055, Properties)
                                        , Helper.ReleaseValue(BGM_C002_1000, Properties)
                                        , Helper.ReleaseValue(BGM_1004, Properties)
                                        , Helper.ReleaseValue(BGM_1225, Properties)
                                        , Helper.ReleaseValue(BGM_4343, Properties)
                                     ), Properties);
        }

        #endregion
    }
}
