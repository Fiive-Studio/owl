using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNB</summary>
    public class UNB : EDISegmentBase
    {
        #region S001

        #region 0001

        /// <summary>Identificador de la Sintaxis</summary>
        public string UNB_S001_0001 { get; set; }

        #endregion // Fin-0001

        #region 0002

        /// <summary>N�mero de Versi�n de la Sintaxis</summary>
        public string UNB_S001_0002 { get; set; }

        #endregion // Fin-0002

        #endregion // Fin-S001

        #region S002

        #region 0004

        /// <summary>Identificador del Emisor</summary>
        public string UNB_S002_0004 { get; set; }

        #endregion // Fin-0004

        #region 0007

        /// <summary>Tipo de C�digo de Identificaci�n del Interlocutor</summary>
        public string UNB_S002_0007 { get; set; }

        #endregion // Fin-0007

        #endregion // Fin-S002

        #region S003

        #region 0010

        /// <summary>Identificaci�n del Receptor</summary>
        public string UNB_S003_0010 { get; set; }

        #endregion // Fin-0010

        #region 0007

        /// <summary>Tipo de C�digo de Identificaci�n del Interlocutor</summary>
        public string UNB_S003_0007 { get; set; }

        #endregion // Fin-0007

        #endregion // Fin-S003

        #region S004

        #region 0017

        /// <summary>Fecha de Generaci�n</summary>
        public string UNB_S004_0017 { get; set; }

        #endregion // Fin-0017

        #region 0019

        /// <summary>Hora y Minutos de Generaci�n</summary>
        public string UNB_S004_0019 { get; set; }

        #endregion // Fin-0019

        #endregion // Fin-S004

        #region 0020

        /// <summary>Referencia de Control del Intercambio</summary>
        public string UNB_0020 { get; set; }

        #endregion // Fin-0020

        #region S005

        #region 0022

        /// <summary>Password del emisor</summary>
        public string UNB_S005_0022 { get; set; }

        #endregion // Fin-0022

		#region 0025

		/// <summary>Calificador de referencia/password del receptor</summary>
		public string UNB_S005_0025 { get; set; }

		#endregion // Fin-0022

        #endregion // Fin-S005

        #region 0026

        /// <summary>Referencia de la Aplicaci�n</summary>
        public string UNB_0026 { get; set; }

        #endregion // Fin-0026

		#region 0029

		/// <summary>C�digo de prioridad de procesamiento</summary>
		public string UNB_0029 { get; set; }

		#endregion // Fin-0029

        #region 0031

        /// <summary>Solicitud de Reconocimiento</summary>
        public string UNB_0031 { get; set; }

        #endregion

		#region 0032

		/// <summary>Identificaci�n de acuerdo de comunicaciones</summary>
		public string UNB_0032 { get; set; }

		#endregion

        #region 0035

        /// <summary>Indicador de Prueba</summary>
        public string UNB_0035 { get; set; }

        #endregion

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.UNB_S001_0001 = Helper.GetElementValue(valores, 1, 0);
            this.UNB_S001_0002 = Helper.GetElementValue(valores, 1, 1);
            this.UNB_S002_0004 = Helper.GetElementValue(valores, 2, 0);
            this.UNB_S002_0007 = Helper.GetElementValue(valores, 2, 1);
            this.UNB_S003_0010 = Helper.GetElementValue(valores, 3, 0);
            this.UNB_S003_0007 = Helper.GetElementValue(valores, 3, 1);
            this.UNB_S004_0017 = Helper.GetElementValue(valores, 4, 0);
            this.UNB_S004_0019 = Helper.GetElementValue(valores, 4, 1);
            this.UNB_0020 = Helper.GetElementValue(valores, 5, 0);
            this.UNB_S005_0022 = Helper.GetElementValue(valores, 6, 0);
            this.UNB_S005_0025 = Helper.GetElementValue(valores, 6, 1);
            this.UNB_0026 = Helper.GetElementValue(valores, 7, 0);
            this.UNB_0029 = Helper.GetElementValue(valores, 8, 0);
            this.UNB_0031 = Helper.GetElementValue(valores, 9, 0);
            this.UNB_0032 = Helper.GetElementValue(valores, 10, 0);
            this.UNB_0035 = Helper.GetElementValue(valores, 11, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("UNB"
                                    , string.Format("UNB{0}{3}{1}{4}{0}{5}{1}{6}{0}{7}{1}{8}{0}{9}{1}{10}{0}{11}{0}{12}{1}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(UNB_S001_0001, Properties)
                                        , Helper.ReleaseValue(UNB_S001_0002, Properties)
                                        , Helper.ReleaseValue(UNB_S002_0004, Properties)
                                        , Helper.ReleaseValue(UNB_S002_0007, Properties)
                                        , Helper.ReleaseValue(UNB_S003_0010, Properties)
                                        , Helper.ReleaseValue(UNB_S003_0007, Properties)
                                        , Helper.ReleaseValue(UNB_S004_0017, Properties)
                                        , Helper.ReleaseValue(UNB_S004_0019, Properties)
                                        , Helper.ReleaseValue(UNB_0020, Properties)
                                        , Helper.ReleaseValue(UNB_S005_0022, Properties)
                                        , Helper.ReleaseValue(UNB_S005_0025, Properties)
                                        , Helper.ReleaseValue(UNB_0026, Properties)
                                        , Helper.ReleaseValue(UNB_0029, Properties)
                                        , Helper.ReleaseValue(UNB_0031, Properties)
                                        , Helper.ReleaseValue(UNB_0032, Properties)
                                        , Helper.ReleaseValue(UNB_0035, Properties)
                                    ), Properties);
        }

        #endregion
    }
}