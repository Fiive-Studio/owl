using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento DLM</summary>
    public class DLM : EDISegmentBase
    {
        #region 4455

        /// <summary>C�digo Devoluci�n</summary>
        public string DLM_4455 { get; set; }

        #endregion // Fin-4455

        #region C522

        #region 4403

        /// <summary>Calificador de Instrucci�n</summary>
        public string DLM_C522_4403 { get; set; }

        #endregion // Fin-4403

        #region 4401

        /// <summary>C�digo Instruccion</summary>
        public string DLM_C522_4401 { get; set; }

        #endregion // Fin-4401

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string DLM_C522_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string DLM_C522_3055 { get; set; }

        #endregion // Fin-3055

        #region 4400

        /// <summary>Instrucci�n</summary>
        public string DLM_C522_4400 { get; set; }

        #endregion // Fin-4400

        #endregion // Fin-C522

        #region C214

        #region 7161

        /// <summary>C�digo Servicios Especiales</summary>
        public string DLM_C214_7161 { get; set; }

        #endregion // Fin-7161

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string DLM_C214_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string DLM_C214_3055 { get; set; }

        #endregion // Fin-3055

        #region 7160

        /// <summary>Servicio Especial 1</summary>
        public string DLM_C214_7160 { get; set; }

        #endregion // Fin-7160

        #region 7160_2

        /// <summary>Servicio Especial 2</summary>
        public string DLM_C214_7160_2 { get; set; }

        #endregion // Fin-7160_2

        #endregion // Fin-C214

        #region 4457

        /// <summary>C�digo Sustituci�n de Producto o Servicio</summary>
        public string DLM_4457 { get; set; }

        #endregion // Fin-4457

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.DLM_4455 = Helper.GetElementValue(valores, 1, 0);
            this.DLM_C522_4403 = Helper.GetElementValue(valores, 2, 0);
            this.DLM_C522_4401 = Helper.GetElementValue(valores, 2, 1);
            this.DLM_C522_1131 = Helper.GetElementValue(valores, 2, 2);
            this.DLM_C522_3055 = Helper.GetElementValue(valores, 2, 3);
            this.DLM_C522_4400 = Helper.GetElementValue(valores, 2, 4);
            this.DLM_C214_7161 = Helper.GetElementValue(valores, 3, 0);
            this.DLM_C214_1131 = Helper.GetElementValue(valores, 3, 1);
            this.DLM_C214_3055 = Helper.GetElementValue(valores, 3, 2);
            this.DLM_C214_7160 = Helper.GetElementValue(valores, 3, 3);
            this.DLM_C214_7160_2 = Helper.GetElementValue(valores, 3, 4);
            this.DLM_4457 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DLM"
                                    , string.Format("DLM{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{0}{9}{1}{10}{1}{11}{1}{12}{1}{13}{0}{14}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(DLM_4455, Properties)
                                        , Helper.ReleaseValue(DLM_C522_4403, Properties)
                                        , Helper.ReleaseValue(DLM_C522_4401, Properties)
                                        , Helper.ReleaseValue(DLM_C522_1131, Properties)
                                        , Helper.ReleaseValue(DLM_C522_3055, Properties)
                                        , Helper.ReleaseValue(DLM_C522_4400, Properties)
                                        , Helper.ReleaseValue(DLM_C214_7161, Properties)
                                        , Helper.ReleaseValue(DLM_C214_1131, Properties)
                                        , Helper.ReleaseValue(DLM_C214_3055, Properties)
                                        , Helper.ReleaseValue(DLM_C214_7160, Properties)
                                        , Helper.ReleaseValue(DLM_C214_7160_2, Properties)
                                        , Helper.ReleaseValue(DLM_4457, Properties)
                                    ), Properties);
        }

        #endregion
    }
}