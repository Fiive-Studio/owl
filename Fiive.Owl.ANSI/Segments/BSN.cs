using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class BSN : ANSISegmentBase
	{

		public string BSN01_353 { get; set; }
		public string BSN02_396 { get; set; }
		public string BSN03_373 { get; set; }
		public string BSN04_337 { get; set; }
		public string BSN05_1005 { get; set; }
		public string BSN06_640 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BSN01_353 = Helper.GetElementValue(valores, 1);
            this.BSN02_396 = Helper.GetElementValue(valores, 2);
            this.BSN03_373 = Helper.GetElementValue(valores, 3);
            this.BSN04_337 = Helper.GetElementValue(valores, 4);
            this.BSN05_1005 = Helper.GetElementValue(valores, 5);
            this.BSN06_640 = Helper.GetElementValue(valores, 6);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BSN"
                                    , string.Format("BSN{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BSN01_353, Properties)
                                        , Helper.ReleaseValue(BSN02_396, Properties)
                                        , Helper.ReleaseValue(BSN03_373, Properties)
                                        , Helper.ReleaseValue(BSN04_337, Properties)
                                        , Helper.ReleaseValue(BSN05_1005, Properties)
                                        , Helper.ReleaseValue(BSN06_640, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
