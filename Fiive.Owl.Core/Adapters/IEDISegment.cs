using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.Core.Adapters
{
    /// <summary>
    /// Interface for the EDI segments
    /// </summary>
    public interface IEDISegment
    {
        EDISegmentProperties Properties { get; set; }
    }

    /// <summary>
    /// Represent the EDI segment's properties
    /// </summary>
    public class EDISegmentProperties : ICloneable
    {
        #region Properties

        char _defaultSegmentTerminator = '\'', _defaultElementSeparator = '+', _defaultSubElementSeparator = ':',
            _defaultReleaseChar = '?', _defaultDecimalSeparator = '.';

        public char ElementSeparator { get; set; }
        public char SubElementSeparator { get; set; }
        public char SegmentTerminator { get; set; }
        public char ReleaseChar { get; set; }
        public char DecimalSeparator { get; set; }
        public bool SaveOriginalContent { get; set; }
        public string OrignalContent { get; set; }

        #endregion

        #region Constructor

        public EDISegmentProperties()
        {
            ElementSeparator = _defaultElementSeparator;
            SubElementSeparator = _defaultSubElementSeparator;
            SegmentTerminator = _defaultSegmentTerminator;
            ReleaseChar = _defaultReleaseChar;
            DecimalSeparator = _defaultDecimalSeparator;
        }

        #endregion

        #region Publics

        public object Clone() { return this.MemberwiseClone(); } 

        #endregion
    }
}
