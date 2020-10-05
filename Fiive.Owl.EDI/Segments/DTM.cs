using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;
using System.Xml.Serialization;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento DTM</summary>
    public class DTM : EDISegmentBase
    {
        #region C507

        #region 2005

        /// <summary>Calificador de Fecha/Hora/Per�odo</summary>
        public string DTM_C507_2005 { get; set; }

        #endregion // Fin-2005

        #region 2380

        /// <summary>Fecha/Hora/Per�odo</summary>
        public string DTM_C507_2380 { get; set; }

        #endregion // Fin-2380

        #region 2379

        /// <summary>Calificador de Formato de Fecha/Hora/Per�odo</summary>
        public string DTM_C507_2379 { get; set; }

        #endregion // Fin-2379

        #endregion // Fin-C507

        #region EDISegmentBase

        public override void LoadContent(string content)
		{
            base.LoadContent(content);
            List<List<string>> valores = Helper.ProcessSegment(content, Properties);

            this.DTM_C507_2005 = Helper.GetElementValue(valores, 1, 0);
            this.DTM_C507_2380 = Helper.GetElementValue(valores, 1, 1);
            this.DTM_C507_2379 = Helper.GetElementValue(valores, 1, 2);
		}

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("DTM"
                                    , string.Format("DTM{0}{3}{1}{4}{1}{5}{2}"
                                        , Properties.ElementGroupSeparator
                                        , Properties.ElementSeparator
                                        , Properties.SegmentSeparator
                                        , Helper.ReleaseValue(DTM_C507_2005, Properties)
                                        , Helper.ReleaseValue(DTM_C507_2380, Properties)
                                        , Helper.ReleaseValue(DTM_C507_2379, Properties)
                                    ), Properties);
        }

        #endregion
    }
}