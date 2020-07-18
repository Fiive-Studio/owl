using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G69 : ANSISegmentBase
	{
		public string G6901_369 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G6901_369 = Helper.GetElementValue(valores, 1);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G69"
                                    , string.Format("G69{0}{1}{2}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G6901_369, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
