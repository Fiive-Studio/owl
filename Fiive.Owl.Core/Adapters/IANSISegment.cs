using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Adapters
{
    /// <summary>
    /// Interface for the ANSI segments
    /// </summary>
    public interface IANSISegment
    {
        /// <summary>
        /// ANSI Properties
        /// </summary>
        ANSISegmentProperties Properties { get; set; }
    }

    /// <summary>
    /// Represent the ANSI segment's properties
    /// </summary>
    public class ANSISegmentProperties : ICloneable
    {
        #region Properties

        readonly char _defaultSegmentTerminator = '~', _defaultElementSeparator = '*', _defaultReleaseChar = '?';

        public char ElementSeparator { get; set; }
        public char SegmentTerminator { get; set; }
        public char ReleaseChar { get; set; }
        public bool SaveOriginalContent { get; set; }
        public string OrignalContent { get; set; }

        #endregion

        #region Constructor

        public ANSISegmentProperties()
        {
            ElementSeparator = _defaultElementSeparator;
            SegmentTerminator = _defaultSegmentTerminator;
            ReleaseChar = _defaultReleaseChar;
        }

        #endregion

        #region Publics

        public object Clone() { return this.MemberwiseClone(); }

        #endregion
    }
}
