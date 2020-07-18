using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	
	public class BAK : ANSISegmentBase
	{
		public string BAK01_353 { get; set; }
		public string BAK02_587 { get; set; }
		public string BAK03_324 { get; set; }
		public string BAK04_373 { get; set; }
		public string BAK05_328 { get; set; }
		public string BAK06_326 { get; set; }
		public string BAK07_367 { get; set; }
		public string BAK08_127 { get; set; }
		public string BAK09_373 { get; set; }
		public string BAK10_640 { get; set; }
		
		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.BAK01_353 = Helper.GetElementValue(valores, 1);
            this.BAK02_587 = Helper.GetElementValue(valores, 2);
            this.BAK03_324 = Helper.GetElementValue(valores, 3);
            this.BAK04_373 = Helper.GetElementValue(valores, 4);
            this.BAK05_328 = Helper.GetElementValue(valores, 5);
			this.BAK06_326 = Helper.GetElementValue(valores, 6);
			this.BAK07_367 = Helper.GetElementValue(valores, 7);
			this.BAK08_127 = Helper.GetElementValue(valores, 8);
			this.BAK09_373 = Helper.GetElementValue(valores, 9);
			this.BAK10_640 = Helper.GetElementValue(valores, 10);
			
        }

		#endregion
		
		#region Override

        public override string ToString()
        {
            return Helper.TrimSegment("BAK"
                                    , string.Format("BAK{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{11}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(BAK01_353, Properties)
										, Helper.ReleaseValue(BAK02_587, Properties)
										, Helper.ReleaseValue(BAK03_324, Properties)
										, Helper.ReleaseValue(BAK04_373, Properties)
										, Helper.ReleaseValue(BAK05_328, Properties)
										, Helper.ReleaseValue(BAK06_326, Properties)
										, Helper.ReleaseValue(BAK07_367, Properties)
										, Helper.ReleaseValue(BAK08_127, Properties)
										, Helper.ReleaseValue(BAK09_373, Properties)
										, Helper.ReleaseValue(BAK10_640, Properties)                                        
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
		
	
	}
}