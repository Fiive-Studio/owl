using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>Segmento UNA</summary>
    public class UNA : EDISegmentBase
    {
        #region EDISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<List<string>> valores = Helper.ProcessSegment(content, Properties);
		}

        #endregion

        #region Override

        public override string ToString()
        {
            return string.Format("UNA{0}{1}{2}{3} {4}"
                                    , Properties.ElementSeparator
                                    , Properties.ElementGroupSeparator
                                    , Properties.DecimalSeparator
                                    , Properties.ReleaseChar
                                    , Properties.SegmentSeparator
                                );
        }

        #endregion
    }
}
