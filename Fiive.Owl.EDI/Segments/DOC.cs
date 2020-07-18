using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento DOC</summary>
    public class DOC : EDISegmentBase
    {
        #region C002

        #region 1001

        /// <summary>Nombre del Documento o Mensaje, Codificado</summary>
        public string DOC_C002_1001 { get; set; }

        #endregion // Fin-1001

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string DOC_C002_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string DOC_C002_3055 { get; set; }

        #endregion // Fin-3055

        #region 1000

        /// <summary>Nombre del Documento o Mensaje</summary>
        public string DOC_C002_1000 { get; set; }

        #endregion // Fin-1000

        #endregion // Fin-C002

        #region C503

        #region 1004

        /// <summary>N�mero del Documento o Mensaje</summary>
        public string DOC_C503_1004 { get; set; }

        #endregion // Fin-1004

        #region 1373

        /// <summary>Categoria del Documento o Mensaje, Codificado</summary>
        public string DOC_C503_1373 { get; set; }

        #endregion // Fin-1373

        #region 1366

        /// <summary>Procedencia del Documento o Mensaje</summary>
        public string DOC_C503_1366 { get; set; }

        #endregion // Fin-1366

        #region 3453

        /// <summary>Idioma, Codificado</summary>
        public string DOC_C503_3453 { get; set; }

        #endregion // Fin-3453

        #endregion // Fin-C503

        #region 3153

        /// <summary>Identificador del Canal de Comunicaci�n, Codificado</summary>
        public string DOC_3153 { get; set; }

        #endregion // Fin-3153

        #region 1220

        /// <summary>N�mero de Copias Requeridas del Documento</summary>
        public string DOC_1220 { get; set; }

        #endregion // Fin-1220

        #region 1218

        /// <summary>N�mero de Originales Requeridos del Documento</summary>
        public string DOC_1218 { get; set; }

        #endregion // Fin-1218

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.DOC_C002_1001 = Helper.GetElementValue(valores, 1, 0);
            this.DOC_C002_1131 = Helper.GetElementValue(valores, 1, 1);
            this.DOC_C002_3055 = Helper.GetElementValue(valores, 1, 2);
            this.DOC_C002_1000 = Helper.GetElementValue(valores, 1, 3);
            this.DOC_C503_1004 = Helper.GetElementValue(valores, 2, 0);
            this.DOC_C503_1373 = Helper.GetElementValue(valores, 2, 1);
            this.DOC_C503_1366 = Helper.GetElementValue(valores, 2, 2);
            this.DOC_C503_3453 = Helper.GetElementValue(valores, 2, 3);
            this.DOC_3153 = Helper.GetElementValue(valores, 3, 0);
            this.DOC_1220 = Helper.GetElementValue(valores, 4, 0);
            this.DOC_1218 = Helper.GetElementValue(valores, 5, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DOC"
                                    , string.Format("DOC{0}{3}{1}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{1}{10}{0}{11}{0}{12}{0}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(DOC_C002_1001, Properties)
                                        , Helper.ReleaseValue(DOC_C002_1131, Properties)
                                        , Helper.ReleaseValue(DOC_C002_3055, Properties)
                                        , Helper.ReleaseValue(DOC_C002_1000, Properties)
                                        , Helper.ReleaseValue(DOC_C503_1004, Properties)
                                        , Helper.ReleaseValue(DOC_C503_1373, Properties)
                                        , Helper.ReleaseValue(DOC_C503_1366, Properties)
                                        , Helper.ReleaseValue(DOC_C503_3453, Properties)
                                        , Helper.ReleaseValue(DOC_3153, Properties)
                                        , Helper.ReleaseValue(DOC_1220, Properties)
                                        , Helper.ReleaseValue(DOC_1218, Properties)
                                    ), Properties);
        }

        #endregion
    }
}