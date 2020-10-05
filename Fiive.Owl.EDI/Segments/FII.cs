using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento FII</summary>
    public class FII : EDISegmentBase
    {
        #region 3035

        /// <summary>Calificador de Parte</summary>
        public string FII_3035 { get; set; }

        #endregion // Fin-3035

        #region C078

        #region 3194

        /// <summary>N�mero del Titular de la Cuenta</summary>
        public string FII_C078_3194 { get; set; }

        #endregion // Fin-3194

        #region 3192

        /// <summary>Nombre del Titular de la Cuenta 1</summary>
        public string FII_C078_3192 { get; set; }

        #endregion // Fin-3192

        #region 3192_2

        /// <summary>Nombre del Titular de la Cuenta 2</summary>
        public string FII_C078_3192_2 { get; set; }

        #endregion // Fin-3192_2

        #region 6345

        /// <summary>Moneda, Codificado</summary>
        public string FII_C078_6345 { get; set; }

        #endregion // Fin-6345

        #endregion // Fin-C078

        #region C088

        #region 3433

        /// <summary>Nombre de la Instituci�n, Codificado</summary>
        public string FII_C088_3433 { get; set; }

        #endregion // Fin-3433

        #region 1131

        /// <summary>Calificador de Lista de C�digos</summary>
        public string FII_C088_1131 { get; set; }

        #endregion // Fin-1131

        #region 3055

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string FII_C088_3055 { get; set; }

        #endregion // Fin-3055

        #region 3434

        /// <summary>N�mero de la Sucursal de la Instituci�n</summary>
        public string FII_C088_3434 { get; set; }

        #endregion // Fin-3434

        #region 1131_2

        /// <summary>Calificador de Lista de C�digos</summary>
        public string FII_C088_1131_2 { get; set; }

        #endregion // Fin-1131_2

        #region 3055_2

        /// <summary>Agencia Responsable de la Lista de C�digos, Codificado</summary>
        public string FII_C088_3055_2 { get; set; }

        #endregion // Fin-3055_2

        #region 3432

        /// <summary>Nombre de la Instituci�n</summary>
        public string FII_C088_3432 { get; set; }

        #endregion // Fin-3432

        #region 3436

        /// <summary>Direcci�n de la Sucursal de la Instituci�n</summary>
        public string FII_C088_3436 { get; set; }

        #endregion // Fin-3436

        #endregion // Fin-C088

        #region 3207

        /// <summary>Pa�s, Codificado</summary>
        public string FII_3207 { get; set; }

        #endregion // Fin-3207

        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.FII_3035 = Helper.GetElementValue(valores, 1, 0);
            this.FII_C078_3194 = Helper.GetElementValue(valores, 2, 0);
            this.FII_C078_3192 = Helper.GetElementValue(valores, 2, 1);
            this.FII_C078_3192_2 = Helper.GetElementValue(valores, 2, 2);
            this.FII_C078_6345 = Helper.GetElementValue(valores, 2, 3);
            this.FII_C088_3433 = Helper.GetElementValue(valores, 3, 0);
            this.FII_C088_1131 = Helper.GetElementValue(valores, 3, 1);
            this.FII_C088_3055 = Helper.GetElementValue(valores, 3, 2);
            this.FII_C088_3434 = Helper.GetElementValue(valores, 3, 3);
            this.FII_C088_1131_2 = Helper.GetElementValue(valores, 3, 4);
            this.FII_C088_3055_2 = Helper.GetElementValue(valores, 3, 5);
            this.FII_C088_3432 = Helper.GetElementValue(valores, 3, 6);
            this.FII_C088_3436 = Helper.GetElementValue(valores, 3, 7);
            this.FII_3207 = Helper.GetElementValue(valores, 4, 0);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("FII"
                                    , string.Format("FII{0}{3}{0}{4}{1}{5}{1}{6}{1}{7}{0}{8}{1}{9}{1}{10}{1}{11}{1}{12}{1}{13}{1}{14}{1}{15}{0}{16}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(FII_3035, Properties)
                                        , Helper.ReleaseValue(FII_C078_3194, Properties)
                                        , Helper.ReleaseValue(FII_C078_3192, Properties)
                                        , Helper.ReleaseValue(FII_C078_3192_2, Properties)
                                        , Helper.ReleaseValue(FII_C078_6345, Properties)
                                        , Helper.ReleaseValue(FII_C088_3433, Properties)
                                        , Helper.ReleaseValue(FII_C088_1131, Properties)
                                        , Helper.ReleaseValue(FII_C088_3055, Properties)
                                        , Helper.ReleaseValue(FII_C088_3434, Properties)
                                        , Helper.ReleaseValue(FII_C088_1131_2, Properties)
                                        , Helper.ReleaseValue(FII_C088_3055_2, Properties)
                                        , Helper.ReleaseValue(FII_C088_3432, Properties)
                                        , Helper.ReleaseValue(FII_C088_3436, Properties)
                                        , Helper.ReleaseValue(FII_3207, Properties)
                                    ), Properties);
        }

        #endregion
    }
}