using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Adapters;

namespace Fiive.Owl.ANSI.Segments
{

	public class W19 : ANSISegmentBase
	{
		public string W1901_181 { get; set; }
		public string W1902_477 { get; set; }
		public string W1903_355 { get; set; }
		public string W1904_438 { get; set; }
		public string W1905_235 { get; set; }
		public string W1906_234 { get; set; }
		public string W1907_235 { get; set; }
		public string W1908_234 { get; set; }
		public string W1909_451 { get; set; }
		public string W1910_81 { get; set; }
		public string W1911_187 { get; set; }
		public string W1912_188 { get; set; }
		public string W1913_81 { get; set; }
		public string W1914_187 { get; set; }
		public string W1915_188 { get; set; }
		public string W1916_81 { get; set; }
		public string W1917_187 { get; set; }
		public string W1918_188 { get; set; }

		#region ANSISegmentBase

		public override void LoadContent(string content)
		{
			base.LoadContent(content);
			List<string> valores = Helper.ProcessSegment(content, Properties);

            this.W1901_181 = Helper.GetElementValue(valores, 1);
            this.W1902_477 = Helper.GetElementValue(valores, 2);
            this.W1903_355 = Helper.GetElementValue(valores, 3);
            this.W1904_438 = Helper.GetElementValue(valores, 4);
            this.W1905_235 = Helper.GetElementValue(valores, 5);
            this.W1906_234 = Helper.GetElementValue(valores, 6);
            this.W1907_235 = Helper.GetElementValue(valores, 7);
            this.W1908_234 = Helper.GetElementValue(valores, 8);
            this.W1909_451 = Helper.GetElementValue(valores, 9);
            this.W1910_81 = Helper.GetElementValue(valores, 10);
            this.W1911_187 = Helper.GetElementValue(valores, 11);
            this.W1912_188 = Helper.GetElementValue(valores, 12);
            this.W1913_81 = Helper.GetElementValue(valores, 13);
            this.W1914_187 = Helper.GetElementValue(valores, 14);
            this.W1915_188 = Helper.GetElementValue(valores, 15);
            this.W1916_81 = Helper.GetElementValue(valores, 16);
            this.W1917_187 = Helper.GetElementValue(valores, 17);
            this.W1918_188 = Helper.GetElementValue(valores, 18);
        }

		#endregion

        #region Override

        public override string ToString()
        {
            return Helper.TrimSegment("W19"
                                    , string.Format("W19{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}{16}{0}{17}{0}{18}{19}"
                                        , Properties.ElementSeparator
                                        , Helper.ReleaseValue(W1901_181, Properties)
                                        , Helper.ReleaseValue(W1902_477, Properties)
                                        , Helper.ReleaseValue(W1903_355, Properties)
                                        , Helper.ReleaseValue(W1904_438, Properties)
                                        , Helper.ReleaseValue(W1905_235, Properties)
                                        , Helper.ReleaseValue(W1906_234, Properties)
                                        , Helper.ReleaseValue(W1907_235, Properties)
                                        , Helper.ReleaseValue(W1908_234, Properties)
                                        , Helper.ReleaseValue(W1909_451, Properties)
                                        , Helper.ReleaseValue(W1910_81, Properties)
                                        , Helper.ReleaseValue(W1911_187, Properties)
                                        , Helper.ReleaseValue(W1912_188, Properties)
                                        , Helper.ReleaseValue(W1913_81, Properties)
                                        , Helper.ReleaseValue(W1914_187, Properties)
                                        , Helper.ReleaseValue(W1915_188, Properties)
                                        , Helper.ReleaseValue(W1916_81, Properties)
                                        , Helper.ReleaseValue(W1917_187, Properties)
                                        , Helper.ReleaseValue(W1918_188, Properties)
                                        , Properties.SegmentSeparator
                                    ), Properties);
        }

        #endregion
	}
}
