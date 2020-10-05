using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento STS</summary>
    public class STS : EDISegmentBase
    {
        #region C601

        #region 9015

        /// <summary>Identificador de Categor�a del Estado</summary>
        public string STS_C601_9015 { get; set; }

        #endregion // Fin-9015

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string STS_C601_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string STS_C601_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C601

        #region C555

        #region 4405

        /// <summary>Descripci�n del Estado, Identificador</summary>
        public string STS_C555_4405 { get; set; }

        #endregion // Fin-4405

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string STS_C555_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string STS_C555_3055 { get; set; }

        #endregion // Fin-3055

        #region 4404

        /// <summary>Descripci�n del Estado</summary>
        public string STS_C555_4404 { get; set; }

        #endregion // Fin-4404

        #endregion // Fin-C555

        #region C556

        #region 9013

        /// <summary>Raz�n del Estado, Identificador 1</summary>
        public string STS_C556_9013 { get; set; }

        #endregion // Fin-9013

        #region 1131

        /// <summary>Calificador de Lista de C�digos 1</summary>
        public string STS_C556_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 1</summary>
        public string STS_C556_3055 { get; set; }

        #endregion // Fin-3055

        #region 9012

        /// <summary>Raz�n del Estado 1</summary>
        public string STS_C556_9012 { get; set; }

        #endregion // Fin-9012

        #endregion // Fin-C556

        #region C556

        #region 9013_2

        /// <summary>Raz�n del Estado, Identificador 2</summary>
        public string STS_C556_9013_2 { get; set; }

        #endregion // Fin-9013_2

        #region 1131_2

        /// <summary>Calificador de Lista de C�digos 2</summary>
        public string STS_C556_1131_2 { get; set; }

        #endregion // Fin-1131_2

        #region 3055_2

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 2</summary>
        public string STS_C556_3055_2 { get; set; }

        #endregion // Fin-3055_2

        #region 9012_2

        /// <summary>Raz�n del Estado 2</summary>
        public string STS_C556_9012_2 { get; set; }

        #endregion // Fin-9012_2

        #endregion // Fin-C556

        #region C556

        #region 9013_3

        /// <summary>Raz�n del Estado, Identificador 3</summary>
        public string STS_C556_9013_3 { get; set; }

        #endregion // Fin-9013_3

        #region 1131_3

        /// <summary>Calificador de Lista de C�digos 3</summary>
        public string STS_C556_1131_3 { get; set; }

        #endregion // Fin-1131_3

        #region 3055_3

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 3</summary>
        public string STS_C556_3055_3 { get; set; }

        #endregion // Fin-3055_3

        #region 9012_3

        /// <summary>Raz�n del Estado 3</summary>
        public string STS_C556_9012_3 { get; set; }

        #endregion // Fin-9012_3

        #endregion // Fin-C556

        #region C556

        #region 9013_4

        /// <summary>Raz�n del Estado, Identificador 4</summary>
        public string STS_C556_9013_4 { get; set; }

        #endregion // Fin-9013_4

        #region 1131_4

        /// <summary>Calificador de Lista de C�digos 4</summary>
        public string STS_C556_1131_4 { get; set; }

        #endregion // Fin-1131_4

        #region 3055_4

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 4</summary>
        public string STS_C556_3055_4 { get; set; }

        #endregion // Fin-3055_4

        #region 9012_4

        /// <summary>Raz�n del Estado 4</summary>
        public string STS_C556_9012_4 { get; set; }

        #endregion // Fin-9012_4

        #endregion // Fin-C556

        #region C556

        #region 9013_5

        /// <summary>Raz�n del Estado, Identificador 5</summary>
        public string STS_C556_9013_5 { get; set; }

        #endregion // Fin-9013_5

        #region 1131_5

        /// <summary>Calificador de Lista de C�digos 5</summary>
        public string STS_C556_1131_5 { get; set; }

        #endregion // Fin-1131_5

        #region 3055_5

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado 5</summary>
        public string STS_C556_3055_5 { get; set; }

        #endregion // Fin-3055_5

        #region 9012_5

        /// <summary>Raz�n del Estado 5</summary>
        public string STS_C556_9012_5 { get; set; }

        #endregion // Fin-9012_5

        #endregion // Fin-C556

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.STS_C601_9015 = Helper.GetElementValue(valores, 1, 0);
            this.STS_C601_1131 = Helper.GetElementValue(valores, 1, 1);
            this.STS_C601_3055 = Helper.GetElementValue(valores, 1, 2);
            this.STS_C555_4405 = Helper.GetElementValue(valores, 2, 0);
            this.STS_C555_1131 = Helper.GetElementValue(valores, 2, 1);
            this.STS_C555_3055 = Helper.GetElementValue(valores, 2, 2);
            this.STS_C555_4404 = Helper.GetElementValue(valores, 2, 3);
            this.STS_C556_9013 = Helper.GetElementValue(valores, 3, 0);
            this.STS_C556_1131 = Helper.GetElementValue(valores, 3, 1);
            this.STS_C556_3055 = Helper.GetElementValue(valores, 3, 2);
            this.STS_C556_9012 = Helper.GetElementValue(valores, 3, 3);
            this.STS_C556_9013_2 = Helper.GetElementValue(valores, 4, 0);
            this.STS_C556_1131_2 = Helper.GetElementValue(valores, 4, 1);
            this.STS_C556_3055_2 = Helper.GetElementValue(valores, 4, 2);
            this.STS_C556_9012_2 = Helper.GetElementValue(valores, 4, 3);
            this.STS_C556_9013_3 = Helper.GetElementValue(valores, 5, 0);
            this.STS_C556_1131_3 = Helper.GetElementValue(valores, 5, 1);
            this.STS_C556_3055_3 = Helper.GetElementValue(valores, 5, 2);
            this.STS_C556_9012_3 = Helper.GetElementValue(valores, 5, 3);
            this.STS_C556_9013_4 = Helper.GetElementValue(valores, 6, 0);
            this.STS_C556_1131_4 = Helper.GetElementValue(valores, 6, 1);
            this.STS_C556_3055_4 = Helper.GetElementValue(valores, 6, 2);
            this.STS_C556_9012_4 = Helper.GetElementValue(valores, 6, 3);
            this.STS_C556_9013_5 = Helper.GetElementValue(valores, 7, 0);
            this.STS_C556_1131_5 = Helper.GetElementValue(valores, 7, 1);
            this.STS_C556_3055_5 = Helper.GetElementValue(valores, 7, 2);
            this.STS_C556_9012_5 = Helper.GetElementValue(valores, 7, 3);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("STS"
                                    , string.Format("STS{0}{3}{1}{4}{1}{5}{0}{6}{1}{7}{1}{8}{1}{9}{0}{10}{1}{11}{1}{12}{1}{13}{0}{14}{1}{15}{1}{16}{1}{17}{0}{18}{1}{19}{1}{20}{1}{21}{0}{22}{1}{23}{1}{24}{1}{25}{0}{26}{1}{27}{1}{28}{1}{29}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(STS_C601_9015, Properties)
                                        , Helper.ReleaseValue(STS_C601_1131, Properties)
                                        , Helper.ReleaseValue(STS_C601_3055, Properties)
                                        , Helper.ReleaseValue(STS_C555_4405, Properties)
                                        , Helper.ReleaseValue(STS_C555_1131, Properties)
                                        , Helper.ReleaseValue(STS_C555_3055, Properties)
                                        , Helper.ReleaseValue(STS_C555_4404, Properties)
                                        , Helper.ReleaseValue(STS_C556_9013, Properties)
                                        , Helper.ReleaseValue(STS_C556_1131, Properties)
                                        , Helper.ReleaseValue(STS_C556_3055, Properties)
                                        , Helper.ReleaseValue(STS_C556_9012, Properties)
                                        , Helper.ReleaseValue(STS_C556_9013_2, Properties)
                                        , Helper.ReleaseValue(STS_C556_1131_2, Properties)
                                        , Helper.ReleaseValue(STS_C556_3055_2, Properties)
                                        , Helper.ReleaseValue(STS_C556_9012_2, Properties)
                                        , Helper.ReleaseValue(STS_C556_9013_3, Properties)
                                        , Helper.ReleaseValue(STS_C556_1131_3, Properties)
                                        , Helper.ReleaseValue(STS_C556_3055_3, Properties)
                                        , Helper.ReleaseValue(STS_C556_9012_3, Properties)
                                        , Helper.ReleaseValue(STS_C556_9013_4, Properties)
                                        , Helper.ReleaseValue(STS_C556_1131_4, Properties)
                                        , Helper.ReleaseValue(STS_C556_3055_4, Properties)
                                        , Helper.ReleaseValue(STS_C556_9012_4, Properties)
                                        , Helper.ReleaseValue(STS_C556_9013_5, Properties)
                                        , Helper.ReleaseValue(STS_C556_1131_5, Properties)
                                        , Helper.ReleaseValue(STS_C556_3055_5, Properties)
                                        , Helper.ReleaseValue(STS_C556_9012_5, Properties)
                                    ), Properties);
        }

        #endregion
    }
}