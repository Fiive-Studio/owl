using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{
	public class SDQ : ANSISegmentBase
	{
        public string SDQ001 { get; set; }
        public string SDQ002 { get; set; }
        public string SDQ003 { get; set; }
        public string SDQ004 { get; set; }
        public string SDQ005 { get; set; }
        public string SDQ006 { get; set; }
        public string SDQ007 { get; set; }
        public string SDQ008 { get; set; }
        public string SDQ009 { get; set; }
        public string SDQ010 { get; set; }
        public string SDQ011 { get; set; }
        public string SDQ012 { get; set; }
        public string SDQ013 { get; set; }
        public string SDQ014 { get; set; }
        public string SDQ015 { get; set; }
        public string SDQ016 { get; set; }
        public string SDQ017 { get; set; }
        public string SDQ018 { get; set; }
        public string SDQ019 { get; set; }
        public string SDQ020 { get; set; }
        public string SDQ021 { get; set; }
        public string SDQ022 { get; set; }

        #region ANSISegmentBase

        public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.SDQ001 = Helper.GetElementValue(valores, 1);
            this.SDQ002 = Helper.GetElementValue(valores, 2);
            this.SDQ003 = Helper.GetElementValue(valores, 3);
            this.SDQ004 = Helper.GetElementValue(valores, 4);
            this.SDQ005 = Helper.GetElementValue(valores, 5);
            this.SDQ006 = Helper.GetElementValue(valores, 6);
            this.SDQ007 = Helper.GetElementValue(valores, 7);
            this.SDQ008 = Helper.GetElementValue(valores, 8);
            this.SDQ009 = Helper.GetElementValue(valores, 9);
            this.SDQ010 = Helper.GetElementValue(valores, 10);
            this.SDQ011 = Helper.GetElementValue(valores, 11);
            this.SDQ012 = Helper.GetElementValue(valores, 12);
            this.SDQ013 = Helper.GetElementValue(valores, 13);
            this.SDQ014 = Helper.GetElementValue(valores, 14);
            this.SDQ015 = Helper.GetElementValue(valores, 15);
            this.SDQ016 = Helper.GetElementValue(valores, 16);
            this.SDQ017 = Helper.GetElementValue(valores, 17);
            this.SDQ018 = Helper.GetElementValue(valores, 18);
            this.SDQ019 = Helper.GetElementValue(valores, 19);
            this.SDQ020 = Helper.GetElementValue(valores, 20);
            this.SDQ021 = Helper.GetElementValue(valores, 21);
            this.SDQ022 = Helper.GetElementValue(valores, 22);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("SDQ"
                                    , string.Format("SDQ{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{0}{21}{0}{22}{23}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(SDQ001, Properties)
                                        , Helper.ReleaseValue(SDQ002, Properties)
                                        , Helper.ReleaseValue(SDQ003, Properties)
                                        , Helper.ReleaseValue(SDQ004, Properties)
                                        , Helper.ReleaseValue(SDQ005, Properties)
                                        , Helper.ReleaseValue(SDQ006, Properties)
                                        , Helper.ReleaseValue(SDQ007, Properties)
                                        , Helper.ReleaseValue(SDQ008, Properties)
                                        , Helper.ReleaseValue(SDQ009, Properties)
                                        , Helper.ReleaseValue(SDQ010, Properties)
                                        , Helper.ReleaseValue(SDQ011, Properties)
                                        , Helper.ReleaseValue(SDQ012, Properties)
                                        , Helper.ReleaseValue(SDQ013, Properties)
                                        , Helper.ReleaseValue(SDQ014, Properties)
                                        , Helper.ReleaseValue(SDQ015, Properties)
                                        , Helper.ReleaseValue(SDQ016, Properties)
                                        , Helper.ReleaseValue(SDQ017, Properties)
                                        , Helper.ReleaseValue(SDQ018, Properties)
                                        , Helper.ReleaseValue(SDQ019, Properties)
                                        , Helper.ReleaseValue(SDQ020, Properties)
                                        , Helper.ReleaseValue(SDQ021, Properties)
                                        , Helper.ReleaseValue(SDQ022, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
