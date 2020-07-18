using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento FTX</summary>
    public class FTX : EDISegmentBase
    {
        #region 4451

        /// <summary>Calificador del Tema del Texto</summary>
        public string FTX_4451 { get; set; }

        #endregion // Fin-4451

        #region 4453

        /// <summary>Funci�n del Texto, Codificado</summary>
        public string FTX_4453 { get; set; }

        #endregion // Fin-4453

        #region C107

        #region 4441

        /// <summary>Texto Libre, Codificado</summary>
        public string FTX_C107_4441 { get; set; }

        #endregion // Fin-4441

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string FTX_C107_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string FTX_C107_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C107

        #region C108

        #region 4440

        /// <summary>Texto Libre 1</summary>
        public string FTX_C108_4440 { get; set; }

        #endregion // Fin-4440

        #region 4440_2

        /// <summary>Texto Libre 2</summary>
        public string FTX_C108_4440_2 { get; set; }

        #endregion // Fin-4440_2

        #region 4440_3

        /// <summary>Texto Libre 3</summary>
        public string FTX_C108_4440_3 { get; set; }

        #endregion // Fin-4440_3

        #region 4440_4

        /// <summary>Texto Libre 4</summary>
        public string FTX_C108_4440_4 { get; set; }

        #endregion // Fin-4440_4

        #region 4440_5

        /// <summary>Texto Libre 5</summary>
        public string FTX_C108_4440_5 { get; set; }

        #endregion // Fin-4440_5

        #endregion // Fin-C108

        #region 3453

        /// <summary>Idioma, Codificado</summary>
        public string FTX_3453 { get; set; }

        #endregion // Fin-3453

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.FTX_4451 = Helper.GetElementValue(valores, 1, 0);
            this.FTX_4453 = Helper.GetElementValue(valores, 2, 0);
            this.FTX_C107_4441 = Helper.GetElementValue(valores, 3, 0);
            this.FTX_C107_1131 = Helper.GetElementValue(valores, 3, 1);
            this.FTX_C107_3055 = Helper.GetElementValue(valores, 3, 2);
            this.FTX_C108_4440 = Helper.GetElementValue(valores, 4, 0);
            this.FTX_C108_4440_2 = Helper.GetElementValue(valores, 4, 1);
            this.FTX_C108_4440_3 = Helper.GetElementValue(valores, 4, 2);
            this.FTX_C108_4440_4 = Helper.GetElementValue(valores, 4, 3);
            this.FTX_C108_4440_5 = Helper.GetElementValue(valores, 4, 4);
            this.FTX_3453 = Helper.GetElementValue(valores, 5, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("FTX"
                                    , string.Format("FTX{0}{3}{0}{4}{0}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{1}{12}{0}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(FTX_4451, Properties)
                                        , Helper.ReleaseValue(FTX_4453, Properties)
                                        , Helper.ReleaseValue(FTX_C107_4441, Properties)
                                        , Helper.ReleaseValue(FTX_C107_1131, Properties)
                                        , Helper.ReleaseValue(FTX_C107_3055, Properties)
                                        , Helper.ReleaseValue(FTX_C108_4440, Properties)
                                        , Helper.ReleaseValue(FTX_C108_4440_2, Properties)
                                        , Helper.ReleaseValue(FTX_C108_4440_3, Properties)
                                        , Helper.ReleaseValue(FTX_C108_4440_4, Properties)
                                        , Helper.ReleaseValue(FTX_C108_4440_5, Properties)
                                        , Helper.ReleaseValue(FTX_3453, Properties)
                                    ), Properties);
        }

        #endregion
    }
}