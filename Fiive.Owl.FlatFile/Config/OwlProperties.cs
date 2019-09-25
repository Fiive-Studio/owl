using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiive.Owl.FlatFile.Config
{
    public class OwlProperties : ICloneable
    {
        public string SegmentTerminator { get; set; }
        public bool SaveOriginalContent { get; set; }
        public string OrignalContent { get; set; }

        #region Constructor

        public OwlProperties() { SegmentTerminator = Environment.NewLine; }

        #endregion

        public object Clone() { return this.MemberwiseClone(); }
    }
}
