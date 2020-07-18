using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class IEA : ANSISegmentBase
	{
		public string IEA01_I16 { get; set; }
		public string IEA02_I12 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.IEA01_I16 = Helper.GetElementValue(valores, 1);
            this.IEA02_I12 = Helper.GetElementValue(valores, 2);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("IEA"
                                    , string.Format("IEA{0}{1}{0}{2}{3}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(IEA01_I16, Properties)
                                        , Helper.ReleaseValue(IEA02_I12, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
