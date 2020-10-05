using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento HAN</summary>
    public class HAN : EDISegmentBase
    {
        #region C524

        #region 4079

        /// <summary>Instrucciones de Manipulaci�n, Codificado</summary>
        public string HAN_C524_4079 { get; set; }

        #endregion // Fin-4079

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string HAN_C524_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string HAN_C524_3055 { get; set; }

        #endregion // Fin-3055

        #region 4078

        /// <summary>Instrucciones de Manipulaci�n</summary>
        public string HAN_C524_4078 { get; set; }

        #endregion // Fin-4078

        #endregion // Fin-C524

        #region C218

        #region 7419

        /// <summary>C�digo de Clase de Material Peligroso, Identificaci�n</summary>
        public string HAN_C218_7419 { get; set; }

        #endregion // Fin-7419

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string HAN_C218_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string HAN_C218_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C218

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.HAN_C524_4079 = Helper.GetElementValue(valores, 1, 0);
            this.HAN_C524_1131 = Helper.GetElementValue(valores, 1, 1);
            this.HAN_C524_3055 = Helper.GetElementValue(valores, 1, 2);
            this.HAN_C524_4078 = Helper.GetElementValue(valores, 1, 3);
            this.HAN_C218_7419 = Helper.GetElementValue(valores, 2, 0);
            this.HAN_C218_1131 = Helper.GetElementValue(valores, 2, 1);
            this.HAN_C218_3055 = Helper.GetElementValue(valores, 2, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("HAN"
                                    , string.Format("HAN{0}{3}{1}{4}{1}{5}{1}{6}{0}{7}{1}{8}{1}{9}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(HAN_C524_4079, Properties)
                                        , Helper.ReleaseValue(HAN_C524_1131, Properties)
                                        , Helper.ReleaseValue(HAN_C524_3055, Properties)
                                        , Helper.ReleaseValue(HAN_C524_4078, Properties)
                                        , Helper.ReleaseValue(HAN_C218_7419, Properties)
                                        , Helper.ReleaseValue(HAN_C218_1131, Properties)
                                        , Helper.ReleaseValue(HAN_C218_3055, Properties)
                                    ), Properties);
        }

        #endregion
    }
}