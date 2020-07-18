using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento GIN</summary>
    public class GIN : EDISegmentBase
    {
        #region 7405

        /// <summary>Calificador del N�mero de Identidad</summary>
        public string GIN_7405 { get; set; }

        #endregion // Fin-7405

        #region C208

        #region 7402

        /// <summary>N�mero de Identidad 1</summary>
        public string GIN_C208_7402 { get; set; }

        #endregion // Fin-7402

        #region 7402_2

        /// <summary>N�mero de Identidad 2</summary>
        public string GIN_C208_7402_2 { get; set; }

        #endregion // Fin-7402_2

        #endregion // Fin-C208

        #region C208

        #region 7402_3

        /// <summary>N�mero de Identidad 3</summary>
        public string GIN_C208_7402_3 { get; set; }

        #endregion // Fin-7402_3

        #region 7402_4

        /// <summary>N�mero de Identidad 4</summary>
        public string GIN_C208_7402_4 { get; set; }

        #endregion // Fin-7402_4

        #endregion // Fin-C208

        #region C208

        #region 7402_5

        /// <summary>N�mero de Identidad 5</summary>
        public string GIN_C208_7402_5 { get; set; }

        #endregion // Fin-7402_5

        #region 7402_6

        /// <summary>N�mero de Identidad 6</summary>
        public string GIN_C208_7402_6 { get; set; }

        #endregion // Fin-7402_6

        #endregion // Fin-C208

        #region C208

        #region 7402_7

        /// <summary>N�mero de Identidad 7</summary>
        public string GIN_C208_7402_7 { get; set; }

        #endregion // Fin-7402_7

        #region 7402_8

        /// <summary>N�mero de Identidad 8</summary>
        public string GIN_C208_7402_8 { get; set; }

        #endregion // Fin-7402_8

        #endregion // Fin-C208

        #region C208

        #region 7402_9

        /// <summary>N�mero de Identidad 9</summary>
        public string GIN_C208_7402_9 { get; set; }

        #endregion // Fin-7402_9

        #region 7402_10

        /// <summary>N�mero de Identidad 10</summary>
        public string GIN_C208_7402_10 { get; set; }

        #endregion // Fin-7402_10

        #endregion // Fin-C208

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.GIN_7405 = Helper.GetElementValue(valores, 1, 0);
            this.GIN_C208_7402 = Helper.GetElementValue(valores, 2, 0);
            this.GIN_C208_7402_2 = Helper.GetElementValue(valores, 2, 1);
            this.GIN_C208_7402_3 = Helper.GetElementValue(valores, 3, 0);
            this.GIN_C208_7402_4 = Helper.GetElementValue(valores, 3, 1);
            this.GIN_C208_7402_5 = Helper.GetElementValue(valores, 4, 0);
            this.GIN_C208_7402_6 = Helper.GetElementValue(valores, 4, 1);
            this.GIN_C208_7402_7 = Helper.GetElementValue(valores, 5, 0);
            this.GIN_C208_7402_8 = Helper.GetElementValue(valores, 5, 1);
            this.GIN_C208_7402_9 = Helper.GetElementValue(valores, 6, 0);
            this.GIN_C208_7402_10 = Helper.GetElementValue(valores, 6, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("GIN"
                                    , string.Format("GIN{0}{3}{0}{4}{1}{5}{0}{6}{1}{7}{0}{8}{1}{9}{0}{10}{1}{11}{0}{12}{1}{13}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(GIN_7405, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_2, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_3, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_4, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_5, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_6, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_7, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_8, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_9, Properties)
                                        , Helper.ReleaseValue(GIN_C208_7402_10, Properties)
                                    ), Properties);
        }

        #endregion
    }
}