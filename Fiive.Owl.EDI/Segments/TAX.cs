using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento TAX</summary>
    public class TAX : EDISegmentBase
    {
        #region 5283

        /// <summary>Calificador de Funci�n de Impuestos o Tasas</summary>
        public string TAX_5283 { get; set; }

        #endregion // Fin-5283

        #region C241

        #region 5153

        /// <summary>Tipo de Arancel, Impuesto o Cuota, Codificado</summary>
        public string TAX_C241_5153 { get; set; }

        #endregion // Fin-5153

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TAX_C241_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TAX_C241_3055 { get; set; }

        #endregion // Fin-3055

        #region 5152

        /// <summary>Tipo de Arancel, Impuesto o Cuota</summary>
        public string TAX_C241_5152 { get; set; }

        #endregion // Fin-5152

        #endregion // Fin-C241

        #region C533

        #region 5289

        /// <summary>Identificaci�n de Cuenta de Impuestos</summary>
        public string TAX_C533_5289 { get; set; }

        #endregion // Fin-5289

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TAX_C533_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TAX_C533_3055 { get; set; }

        #endregion // Fin-3055

        #endregion // Fin-C533

        #region 5286

        /// <summary>Base de Aplicaci�n de Tasa, Arancel o Impuesto</summary>
        public string TAX_5286 { get; set; }

        #endregion // Fin-5286

        #region C243

        #region 5279

        /// <summary>Identificaci�n de la Tarifa de Impuestos o Tasas</summary>
        public string TAX_C243_5279 { get; set; }

        #endregion // Fin-5279

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TAX_C243_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TAX_C243_3055 { get; set; }

        #endregion // Fin-3055

        #region 5278

        /// <summary>Tarifa de Impuestos o Tasas</summary>
        public string TAX_C243_5278 { get; set; }

        #endregion // Fin-5278

        #region 5273

        /// <summary>Base, Tarifa o Cuota Arancelaria, Codificado</summary>
        public string TAX_C243_5273 { get; set; }

        #endregion // Fin-5273

        #region 1131_2

        /// <summary>Calificador de Lista de C�digos</summary>
        public string TAX_C243_1131_2 { get; set; }

        #endregion // Fin-1131_2

        #region 3055_2

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string TAX_C243_3055_2 { get; set; }

        #endregion // Fin-3055_2

        #endregion // Fin-C243

        #region 5305

        /// <summary>Categoria del Arancel, Impuesto o Cuota, Codificado</summary>
        public string TAX_5305 { get; set; }

        #endregion // Fin-5305

        #region 3446

        /// <summary>N�mero de Identificaci�n Arancelaria de una Parte</summary>
        public string TAX_3446 { get; set; }

        #endregion // Fin-3446

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.TAX_5283 = Helper.GetElementValue(valores, 1, 0);
            this.TAX_C241_5153 = Helper.GetElementValue(valores, 2, 0);
            this.TAX_C241_1131 = Helper.GetElementValue(valores, 2, 1);
            this.TAX_C241_3055 = Helper.GetElementValue(valores, 2, 2);
            this.TAX_C241_5152 = Helper.GetElementValue(valores, 2, 3);
            this.TAX_C533_5289 = Helper.GetElementValue(valores, 3, 0);
            this.TAX_C533_1131 = Helper.GetElementValue(valores, 3, 1);
            this.TAX_C533_3055 = Helper.GetElementValue(valores, 3, 2);
            this.TAX_5286 = Helper.GetElementValue(valores, 4, 0);
            this.TAX_C243_5279 = Helper.GetElementValue(valores, 5, 0);
            this.TAX_C243_1131 = Helper.GetElementValue(valores, 5, 1);
            this.TAX_C243_3055 = Helper.GetElementValue(valores, 5, 2);
            this.TAX_C243_5278 = Helper.GetElementValue(valores, 5, 3);
            this.TAX_C243_5273 = Helper.GetElementValue(valores, 5, 4);
            this.TAX_C243_1131_2 = Helper.GetElementValue(valores, 5, 5);
            this.TAX_C243_3055_2 = Helper.GetElementValue(valores, 5, 6);
            this.TAX_5305 = Helper.GetElementValue(valores, 6, 0);
            this.TAX_3446 = Helper.GetElementValue(valores, 7, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TAX"
                                    , string.Format("TAX{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{0}{11}{0}{12}{1}{13}{1}{14}{1}{15}{1}{16}{1}{17}{1}{18}{0}{19}{0}{20}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(TAX_5283, Properties)
                                        , Helper.ReleaseValue(TAX_C241_5153, Properties)
                                        , Helper.ReleaseValue(TAX_C241_1131, Properties)
                                        , Helper.ReleaseValue(TAX_C241_3055, Properties)
                                        , Helper.ReleaseValue(TAX_C241_5152, Properties)
                                        , Helper.ReleaseValue(TAX_C533_5289, Properties)
                                        , Helper.ReleaseValue(TAX_C533_1131, Properties)
                                        , Helper.ReleaseValue(TAX_C533_3055, Properties)
                                        , Helper.ReleaseValue(TAX_5286, Properties)
                                        , Helper.ReleaseValue(TAX_C243_5279, Properties)
                                        , Helper.ReleaseValue(TAX_C243_1131, Properties)
                                        , Helper.ReleaseValue(TAX_C243_3055, Properties)
                                        , Helper.ReleaseValue(TAX_C243_5278, Properties)
                                        , Helper.ReleaseValue(TAX_C243_5273, Properties)
                                        , Helper.ReleaseValue(TAX_C243_1131_2, Properties)
                                        , Helper.ReleaseValue(TAX_C243_3055_2, Properties)
                                        , Helper.ReleaseValue(TAX_5305, Properties)
                                        , Helper.ReleaseValue(TAX_3446, Properties)
                                    ), Properties);
        }

        #endregion
    }
}