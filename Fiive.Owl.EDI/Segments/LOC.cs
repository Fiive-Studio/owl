using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento LOC</summary>
    public class LOC : EDISegmentBase
    {
        #region 3227

        /// <summary>Calificador del Lugar o Ubicaci�n</summary>
        public string LOC_3227 { get; set; }

        #endregion // Fin-3227

        #region C517

        #region 3225

        /// <summary>Identificaci�n de Lugar o Ubicaci�n</summary>
        public string LOC_C517_3225 { get; set; }

        #endregion // Fin-3225

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string LOC_C517_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string LOC_C517_3055 { get; set; }

        #endregion // Fin-3055

        #region 3224

        /// <summary>Lugar o Ubicaci�n</summary>
        public string LOC_C517_3224 { get; set; }

        #endregion // Fin-3224

        #endregion // Fin-C517

        #region C519

        #region 3223

        /// <summary>Primer Lugar Referido, Codificado</summary>
        public string LOC_C519_3223 { get; set; }

        #endregion // Fin-3223

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string LOC_C519_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string LOC_C519_3055 { get; set; }

        #endregion // Fin-3055

        #region 3222

        /// <summary>Primer Lugar Referido</summary>
        public string LOC_C519_3222 { get; set; }

        #endregion // Fin-3222

        #endregion // Fin-C519

        #region C553

        #region 3233

        /// <summary>Segundo Lugar Referido, Codificado</summary>
        public string LOC_C553_3233 { get; set; }

        #endregion // Fin-3233

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string LOC_C553_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string LOC_C553_3055 { get; set; }

        #endregion // Fin-3055

        #region 3232

        /// <summary>Segundo Lugar Referido</summary>
        public string LOC_C553_3232 { get; set; }

        #endregion // Fin-3232

        #endregion // Fin-C553

        #region 5479

        /// <summary>Relaci�n, Codificado</summary>
        public string LOC_5479 { get; set; }

        #endregion // Fin-5479

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.LOC_3227 = Helper.GetElementValue(valores, 1, 0);
            this.LOC_C517_3225 = Helper.GetElementValue(valores, 2, 0);
            this.LOC_C517_1131 = Helper.GetElementValue(valores, 2, 1);
            this.LOC_C517_3055 = Helper.GetElementValue(valores, 2, 2);
            this.LOC_C517_3224 = Helper.GetElementValue(valores, 2, 3);
            this.LOC_C519_3223 = Helper.GetElementValue(valores, 3, 0);
            this.LOC_C519_1131 = Helper.GetElementValue(valores, 3, 1);
            this.LOC_C519_3055 = Helper.GetElementValue(valores, 3, 2);
            this.LOC_C519_3222 = Helper.GetElementValue(valores, 3, 3);
            this.LOC_C553_3233 = Helper.GetElementValue(valores, 4, 0);
            this.LOC_C553_1131 = Helper.GetElementValue(valores, 4, 1);
            this.LOC_C553_3055 = Helper.GetElementValue(valores, 4, 2);
            this.LOC_C553_3232 = Helper.GetElementValue(valores, 4, 3);
            this.LOC_5479 = Helper.GetElementValue(valores, 5, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("LOC"
                                    , string.Format("LOC{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{0}{12}{1}{13}{1}{14}{1}{15}{0}{16}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(LOC_3227, Properties)
                                        , Helper.ReleaseValue(LOC_C517_3225, Properties)
                                        , Helper.ReleaseValue(LOC_C517_1131, Properties)
                                        , Helper.ReleaseValue(LOC_C517_3055, Properties)
                                        , Helper.ReleaseValue(LOC_C517_3224, Properties)
                                        , Helper.ReleaseValue(LOC_C519_3223, Properties)
                                        , Helper.ReleaseValue(LOC_C519_1131, Properties)
                                        , Helper.ReleaseValue(LOC_C519_3055, Properties)
                                        , Helper.ReleaseValue(LOC_C519_3222, Properties)
                                        , Helper.ReleaseValue(LOC_C553_3233, Properties)
                                        , Helper.ReleaseValue(LOC_C553_1131, Properties)
                                        , Helper.ReleaseValue(LOC_C553_3055, Properties)
                                        , Helper.ReleaseValue(LOC_C553_3232, Properties)
                                        , Helper.ReleaseValue(LOC_5479, Properties)
                                    ), Properties);
        }

        #endregion
    }
}