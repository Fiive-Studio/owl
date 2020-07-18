using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class G76 : ANSISegmentBase
	{

        public string G7601_330 { get; set; }
        public string G7602_355 { get; set; }
        public string G7603_81 { get; set; }
        public string G7604_355 { get; set; }
        public string G7605_183 { get; set; }
        public string G7606_355 { get; set; }
        public string G7607_398 { get; set; }
        public string G7608_610 { get; set; }
        public string G7609_417 { get; set; }
        public string G7610_107 { get; set; }


        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G7601_330 = Helper.GetElementValue(valores, 1);
            this.G7602_355 = Helper.GetElementValue(valores, 2);
            this.G7603_81 = Helper.GetElementValue(valores, 3);
            this.G7604_355 = Helper.GetElementValue(valores, 4);
            this.G7605_183 = Helper.GetElementValue(valores, 5);
            this.G7606_355 = Helper.GetElementValue(valores, 6);
            this.G7607_398 = Helper.GetElementValue(valores, 7);
            this.G7608_610 = Helper.GetElementValue(valores, 8);
            this.G7609_417 = Helper.GetElementValue(valores, 9);
            this.G7610_107 = Helper.GetElementValue(valores, 10);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G76"
                                    , string.Format("G76{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{11}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G7601_330, Properties)
                                        , Helper.ReleaseValue(G7602_355, Properties)
                                        , Helper.ReleaseValue(G7603_81, Properties)
                                        , Helper.ReleaseValue(G7604_355, Properties)
                                        , Helper.ReleaseValue(G7605_183, Properties)
                                        , Helper.ReleaseValue(G7606_355, Properties)
                                        , Helper.ReleaseValue(G7607_398, Properties)
                                        , Helper.ReleaseValue(G7608_610, Properties)
                                        , Helper.ReleaseValue(G7609_417, Properties)
                                        , Helper.ReleaseValue(G7610_107, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}