using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UCI</summary>
    public class UCI : EDISegmentBase
    {
        #region 0020

        /// <summary>Referencia de Control del Intercambio</summary>
        public string UCI_0020 { get; set; }

        #endregion // Fin-0020

        #region S002

        #region 0004

        /// <summary>Identificador del Emisor</summary>
        public string UCI_S002_0004 { get; set; }

        #endregion // Fin-0004

        #region 0007

        /// <summary>Calificador del C�digo de Identificacion del Interlocutor</summary>
        public string UCI_S002_0007 { get; set; }

        #endregion // Fin-0007

        #region 0008

        /// <summary>Direccion para Direccionamiento Inverso</summary>
        public string UCI_S002_0008 { get; set; }

        #endregion // Fin-0008

        #endregion // Fin-S002

        #region S003

        #region 0010

        /// <summary>Identificacion del Receptor</summary>
        public string UCI_S003_0010 { get; set; }

        #endregion // Fin-0010

        #region 0007

        /// <summary>Calificador del C�digo de Identificacion del Interlocutor</summary>
        public string UCI_S003_0007 { get; set; }

        #endregion // Fin-0007

        #region 0014

        /// <summary>Direcci�n de Encaminamiento</summary>
        public string UCI_S003_0014 { get; set; }

        #endregion // Fin-0014

        #endregion // Fin-S003

        #region 0083

        /// <summary>Acci�n, Codificada</summary>
        public string UCI_0083 { get; set; }

        #endregion // Fin-0083

        #region 0085

        /// <summary>Error de Sintaxis, Codificado</summary>
        public string UCI_0085 { get; set; }

        #endregion // Fin-0085

        #region 0135

        /// <summary>Etiqueta (tag) de Segmento, Codificada</summary>
        public string UCI_0135 { get; set; }

        #endregion // Fin-0013

        #region S011

        #region 0098

        /// <summary>Posici�n del Elemento de Dato Err�neo dentro del Segmento</summary>
        public string UCI_S011_0098 { get; set; }

        #endregion // Fin-0098

        #region 0104

        /// <summary>Posici�n del Elemento de Dato Componente Err�neo</summary>
        public string UCI_S011_0104 { get; set; }

        #endregion // Fin-0104

        #endregion // Fin-S011

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UCI_0020 = Helper.GetElementValue(valores, 1, 0);
            this.UCI_S002_0004 = Helper.GetElementValue(valores, 2, 0);
            this.UCI_S002_0007 = Helper.GetElementValue(valores, 2, 1);
            this.UCI_S002_0008 = Helper.GetElementValue(valores, 2, 2);
            this.UCI_S003_0010 = Helper.GetElementValue(valores, 3, 0);
            this.UCI_S003_0007 = Helper.GetElementValue(valores, 3, 1);
            this.UCI_S003_0014 = Helper.GetElementValue(valores, 3, 2);
            this.UCI_0083 = Helper.GetElementValue(valores, 4, 0);
            this.UCI_0085 = Helper.GetElementValue(valores, 5, 0);
            this.UCI_0135 = Helper.GetElementValue(valores, 6, 0);
            this.UCI_S011_0098 = Helper.GetElementValue(valores, 7, 0);
            this.UCI_S011_0104 = Helper.GetElementValue(valores, 7, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UCI"
                                    , string.Format("UCI{0}{3}{0}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{0}{10}{0}{11}{0}{12}{0}{13}{1}{14}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UCI_0020, Properties)
                                        , Helper.ReleaseValue(UCI_S002_0004, Properties)
                                        , Helper.ReleaseValue(UCI_S002_0007, Properties)
                                        , Helper.ReleaseValue(UCI_S002_0008, Properties)
                                        , Helper.ReleaseValue(UCI_S003_0010, Properties)
                                        , Helper.ReleaseValue(UCI_S003_0007, Properties)
                                        , Helper.ReleaseValue(UCI_S003_0014, Properties)
                                        , Helper.ReleaseValue(UCI_0083, Properties)
                                        , Helper.ReleaseValue(UCI_0085, Properties)
                                        , Helper.ReleaseValue(UCI_0135, Properties)
                                        , Helper.ReleaseValue(UCI_S011_0098, Properties)
                                        , Helper.ReleaseValue(UCI_S011_0104, Properties)
                                    ), Properties);
        }

        #endregion
    }
}