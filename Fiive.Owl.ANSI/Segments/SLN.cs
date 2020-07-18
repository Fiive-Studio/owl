using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class SLN : ANSISegmentBase
	{
		public string SLN01_350 { get; set; }
		public string SLN02_382 { get; set; }
		public string SLN03_662 { get; set; }
		public string SLN04_380 { get; set; }
		public string SLN05_C001 { get; set; }
		public string SLN06_212 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.SLN01_350 = Helper.GetElementValue(valores, 1);
            this.SLN02_382 = Helper.GetElementValue(valores, 2);
            this.SLN03_662 = Helper.GetElementValue(valores, 3);
            this.SLN04_380 = Helper.GetElementValue(valores, 4);
            this.SLN05_C001 = Helper.GetElementValue(valores, 5);
            this.SLN06_212 = Helper.GetElementValue(valores, 6);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SLN"
                                    , string.Format("SLN{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(SLN01_350, Properties)
                                        , Helper.ReleaseValue(SLN02_382, Properties)
                                        , Helper.ReleaseValue(SLN03_662, Properties)
                                        , Helper.ReleaseValue(SLN04_380, Properties)
                                        , Helper.ReleaseValue(SLN05_C001, Properties)
                                        , Helper.ReleaseValue(SLN06_212, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
