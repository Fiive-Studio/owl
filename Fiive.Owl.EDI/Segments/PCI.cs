using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento PCI</summary>
    public class PCI : EDISegmentBase
    {
        #region 4233

        /// <summary>Instrucciones de Marcaje, Codificado</summary>
        public string PCI_4233 { get; set; }

        #endregion // Fin-4233

        #region C210

        #region 7102

        /// <summary>Marcas de Embarque 1</summary>
        public string PCI_C210_7102 { get; set; }

        #endregion // Fin-7102

        #region 7102_2

        /// <summary>Marcas de Embarque 2</summary>
        public string PCI_C210_7102_2 { get; set; }

        #endregion // Fin-7102_2

        #region 7102_3

        /// <summary>Marcas de Embarque 3</summary>
        public string PCI_C210_7102_3 { get; set; }

        #endregion // Fin-7102_3

        #region 7102_4

        /// <summary>Marcas de Embarque 4</summary>
        public string PCI_C210_7102_4 { get; set; }

        #endregion // Fin-7102_4

        #region 7102_5

        /// <summary>Marcas de Embarque 5</summary>
        public string PCI_C210_7102_5 { get; set; }

        #endregion // Fin-7102_5

        #region 7102_6

        /// <summary>Marcas de Embarque 6</summary>
        public string PCI_C210_7102_6 { get; set; }

        #endregion // Fin-7102_6

        #region 7102_7

        /// <summary>Marcas de Embarque 7</summary>
        public string PCI_C210_7102_7 { get; set; }

        #endregion // Fin-7102_7

        #region 7102_8

        /// <summary>Marcas de Embarque 8</summary>
        public string PCI_C210_7102_8 { get; set; }

        #endregion // Fin-7102_8

        #region 7102_9

        /// <summary>Marcas de Embarque 9</summary>
        public string PCI_C210_7102_9 { get; set; }

        #endregion // Fin-7102_9

        #region 7102_10

        /// <summary>Marcas de Embarque 10</summary>
        public string PCI_C210_7102_10 { get; set; }

        #endregion // Fin-7102_10

        #endregion // Fin-C210

        #region 8275

        /// <summary>Categoria del Embalaje/Contenedor, Ccodificado</summary>
        public string PCI_8275 { get; set; }

        #endregion // Fin-8275

        #region C827

        #region 7511

        /// <summary>Tipo de Marcado, Codificado</summary>
        public string PCI_C827_7511 { get; set; }

        #endregion // Fin-7511

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string PCI_C827_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string PCI_C827_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C827

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.PCI_4233 = Helper.GetElementValue(valores, 1, 0);
            this.PCI_C210_7102 = Helper.GetElementValue(valores, 2, 0);
            this.PCI_C210_7102_2 = Helper.GetElementValue(valores, 2, 1);
            this.PCI_C210_7102_3 = Helper.GetElementValue(valores, 2, 2);
            this.PCI_C210_7102_4 = Helper.GetElementValue(valores, 2, 3);
            this.PCI_C210_7102_5 = Helper.GetElementValue(valores, 2, 4);
            this.PCI_C210_7102_6 = Helper.GetElementValue(valores, 2, 5);
            this.PCI_C210_7102_7 = Helper.GetElementValue(valores, 2, 6);
            this.PCI_C210_7102_8 = Helper.GetElementValue(valores, 2, 7);
            this.PCI_C210_7102_9 = Helper.GetElementValue(valores, 2, 8);
            this.PCI_C210_7102_10 = Helper.GetElementValue(valores, 2, 9);
            this.PCI_8275 = Helper.GetElementValue(valores, 3, 0);
            this.PCI_C827_7511 = Helper.GetElementValue(valores, 4, 0);
            this.PCI_C827_1131 = Helper.GetElementValue(valores, 4, 1);
            this.PCI_C827_3055 = Helper.GetElementValue(valores, 4, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("PCI"
                                    , string.Format("PCI{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{1}{10}{1}{11}{1}{12}{1}{13}{0}{14}{0}{15}{1}{16}{1}{17}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(PCI_4233, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_2, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_3, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_4, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_5, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_6, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_7, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_8, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_9, Properties)
                                        , Helper.ReleaseValue(PCI_C210_7102_10, Properties)
                                        , Helper.ReleaseValue(PCI_8275, Properties)
                                        , Helper.ReleaseValue(PCI_C827_7511, Properties)
                                        , Helper.ReleaseValue(PCI_C827_1131, Properties)
                                        , Helper.ReleaseValue(PCI_C827_3055, Properties)
                                    ), Properties);
        }

        #endregion
    }
}