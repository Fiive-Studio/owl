using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class G39 : ANSISegmentBase
	{
		public string G3901_438 { get; set; }
		public string G3902_235 { get; set; }
		public string G3903_234 { get; set; }
		public string G3904_152 { get; set; }
		public string G3905_395 { get; set; }
		public string G3906_187 { get; set; }
		public string G3907_188 { get; set; }
		public string G3908_65 { get; set; }
		public string G3909_355 { get; set; }
		public string G3910_189 { get; set; }
		public string G3911_355 { get; set; }
		public string G3912_82 { get; set; }
		public string G3913_355 { get; set; }
		public string G3914_183 { get; set; }
		public string G3915_355 { get; set; }
		public string G3916_416 { get; set; }
		public string G3917_356 { get; set; }
		public string G3918_357 { get; set; }
		public string G3919_355 { get; set; }
		public string G3920_397 { get; set; }
		public string G3921_398 { get; set; }
		public string G3922_876 { get; set; }
		public string G3923_235 { get; set; }
		public string G3924_234 { get; set; }
		public string G3925_187 { get; set; }
		public string G3926_395 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.G3901_438 = Helper.GetElementValue(valores, 1);
            this.G3902_235 = Helper.GetElementValue(valores, 2);
            this.G3903_234 = Helper.GetElementValue(valores, 3);
            this.G3904_152 = Helper.GetElementValue(valores, 4);
            this.G3905_395 = Helper.GetElementValue(valores, 5);
            this.G3906_187 = Helper.GetElementValue(valores, 6);
            this.G3907_188 = Helper.GetElementValue(valores, 7);
            this.G3908_65 = Helper.GetElementValue(valores, 8);
            this.G3909_355 = Helper.GetElementValue(valores, 9);
            this.G3910_189 = Helper.GetElementValue(valores, 10);
            this.G3911_355 = Helper.GetElementValue(valores, 11);
            this.G3912_82 = Helper.GetElementValue(valores, 12);
            this.G3913_355 = Helper.GetElementValue(valores, 13);
            this.G3914_183 = Helper.GetElementValue(valores, 14);
            this.G3915_355 = Helper.GetElementValue(valores, 15);
            this.G3916_416 = Helper.GetElementValue(valores, 16);
            this.G3917_356 = Helper.GetElementValue(valores, 17);
            this.G3918_357 = Helper.GetElementValue(valores, 18);
            this.G3919_355 = Helper.GetElementValue(valores, 19);
            this.G3920_397 = Helper.GetElementValue(valores, 20);
            this.G3921_398 = Helper.GetElementValue(valores, 21);
            this.G3922_876 = Helper.GetElementValue(valores, 22);
            this.G3923_235 = Helper.GetElementValue(valores, 23);
            this.G3924_234 = Helper.GetElementValue(valores, 24);
            this.G3925_187 = Helper.GetElementValue(valores, 25);
            this.G3926_395 = Helper.GetElementValue(valores, 26);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("G39"
                                    , string.Format("G39{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{0}{19}{0}{20}{0}{21}{0}{22}{0}{23}{0}{24}{0}{25}{0}{26}{27}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(G3901_438, Properties)
                                        , Helper.ReleaseValue(G3902_235, Properties)
                                        , Helper.ReleaseValue(G3903_234, Properties)
                                        , Helper.ReleaseValue(G3904_152, Properties)
                                        , Helper.ReleaseValue(G3905_395, Properties)
                                        , Helper.ReleaseValue(G3906_187, Properties)
                                        , Helper.ReleaseValue(G3907_188, Properties)
                                        , Helper.ReleaseValue(G3908_65, Properties)
                                        , Helper.ReleaseValue(G3909_355, Properties)
                                        , Helper.ReleaseValue(G3910_189, Properties)
                                        , Helper.ReleaseValue(G3911_355, Properties)
                                        , Helper.ReleaseValue(G3912_82, Properties)
                                        , Helper.ReleaseValue(G3913_355, Properties)
                                        , Helper.ReleaseValue(G3914_183, Properties)
                                        , Helper.ReleaseValue(G3915_355, Properties)
                                        , Helper.ReleaseValue(G3916_416, Properties)
                                        , Helper.ReleaseValue(G3917_356, Properties)
                                        , Helper.ReleaseValue(G3918_357, Properties)
                                        , Helper.ReleaseValue(G3919_355, Properties)
                                        , Helper.ReleaseValue(G3920_397, Properties)
                                        , Helper.ReleaseValue(G3921_398, Properties)
                                        , Helper.ReleaseValue(G3922_876, Properties)
                                        , Helper.ReleaseValue(G3923_235, Properties)
                                        , Helper.ReleaseValue(G3924_234, Properties)
                                        , Helper.ReleaseValue(G3925_187, Properties)
                                        , Helper.ReleaseValue(G3926_395, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
