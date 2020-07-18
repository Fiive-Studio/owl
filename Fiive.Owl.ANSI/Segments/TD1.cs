using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class TD1 : ANSISegmentBase
	{
		public string TD101 { get; set; }
		public string TD102 { get; set; }
		public string TD103 { get; set; }
		public string TD104 { get; set; }
		public string TD105 { get; set; }
		public string TD106_187 { get; set; }
		public string TD107_81 { get; set; }
		public string TD108_355 { get; set; }
		public string TD109_183 { get; set; }
		public string TD110_355 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.TD101 = Helper.GetElementValue(valores, 1);
            this.TD102 = Helper.GetElementValue(valores, 2);
            this.TD103 = Helper.GetElementValue(valores, 3);
            this.TD104 = Helper.GetElementValue(valores, 4);
            this.TD105 = Helper.GetElementValue(valores, 5);
            this.TD106_187 = Helper.GetElementValue(valores, 6);
            this.TD107_81 = Helper.GetElementValue(valores, 7);
            this.TD108_355 = Helper.GetElementValue(valores, 8);
            this.TD109_183 = Helper.GetElementValue(valores, 9);
            this.TD110_355 = Helper.GetElementValue(valores, 10);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("TD1"
                                    , string.Format("TD1{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{11}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(TD101, Properties)
                                        , Helper.ReleaseValue(TD102, Properties)
                                        , Helper.ReleaseValue(TD103, Properties)
                                        , Helper.ReleaseValue(TD104, Properties)
                                        , Helper.ReleaseValue(TD105, Properties)
                                        , Helper.ReleaseValue(TD106_187, Properties)
                                        , Helper.ReleaseValue(TD107_81, Properties)
                                        , Helper.ReleaseValue(TD108_355, Properties)
                                        , Helper.ReleaseValue(TD109_183, Properties)
                                        , Helper.ReleaseValue(TD110_355, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}