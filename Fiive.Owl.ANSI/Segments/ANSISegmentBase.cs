using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.ANSI.Segments
{
    /// <summary>
    /// Represent a Segment Base
    /// </summary>
    public class ANSISegmentBase : IANSISegment
    {
        #region IEDISegment

        [XmlIgnore]
        public ANSISegmentProperties Properties { get; set; }

        #endregion

        #region Properties

        [XmlElement(typeof(ACK))]
        [XmlElement(typeof(AK1))]
        [XmlElement(typeof(AK2))]
        [XmlElement(typeof(AK5))]
        [XmlElement(typeof(AK9))]
        [XmlElement(typeof(AMT))]
        [XmlElement(typeof(AT8))]
        [XmlElement(typeof(B10))]
        [XmlElement(typeof(B13))]
        [XmlElement(typeof(B2A))]
        [XmlElement(typeof(BAA))]
        [XmlElement(typeof(BAK))]
        [XmlElement(typeof(BCH))]
        [XmlElement(typeof(BEG))]
        [XmlElement(typeof(BGN))]
        [XmlElement(typeof(BIA))]
        [XmlElement(typeof(BIG))]
        [XmlElement(typeof(BPA))]
        [XmlElement(typeof(BPT))]
        [XmlElement(typeof(BSN))]
        [XmlElement(typeof(BSS))]
        [XmlElement(typeof(CON_))]
        [XmlElement(typeof(CSH))]
        [XmlElement(typeof(CTB))]
        [XmlElement(typeof(CTP))]
        [XmlElement(typeof(CTT))]
        [XmlElement(typeof(CUR))]
        [XmlElement(typeof(DTM))]
        [XmlElement(typeof(FOB))]
        [XmlElement(typeof(G39))]
        [XmlElement(typeof(G50))]
        [XmlElement(typeof(G53))]
        [XmlElement(typeof(G54))]
        [XmlElement(typeof(G55))]
        [XmlElement(typeof(G61))]
        [XmlElement(typeof(G62))]
        [XmlElement(typeof(G68))]
        [XmlElement(typeof(G69))]
        [XmlElement(typeof(G76))]
        [XmlElement(typeof(GE))]
        [XmlElement(typeof(GS))]
        [XmlElement(typeof(HL))]
        [XmlElement(typeof(IEA))]
        [XmlElement(typeof(ISA))]
        [XmlElement(typeof(ISS))]
        [XmlElement(typeof(IT1))]
        [XmlElement(typeof(ITD))]
        [XmlElement(typeof(K1))]
        [XmlElement(typeof(L11))]
        [XmlElement(typeof(LIN))]
        [XmlElement(typeof(LX))]
        [XmlElement(typeof(MAN))]
        [XmlElement(typeof(MEA))]
        [XmlElement(typeof(MSG))]
        [XmlElement(typeof(MTX))]
        [XmlElement(typeof(N1))]
        [XmlElement(typeof(N2))]
        [XmlElement(typeof(N3))]
        [XmlElement(typeof(N4))]
        [XmlElement(typeof(N9))]
        [XmlElement(typeof(NTE))]
        [XmlElement(typeof(OTI))]
        [XmlElement(typeof(PAD))]
        [XmlElement(typeof(PER))]
        [XmlElement(typeof(PID))]
        [XmlElement(typeof(PKG))]
        [XmlElement(typeof(PO1))]
        [XmlElement(typeof(PO4))]
        [XmlElement(typeof(PRF))]
        [XmlElement(typeof(PTD))]
        [XmlElement(typeof(QTY))]
        [XmlElement(typeof(REF))]
        [XmlElement(typeof(SAC))]
        [XmlElement(typeof(SDQ))]
        [XmlElement(typeof(SE))]
        [XmlElement(typeof(SLN))]
        [XmlElement(typeof(SN1))]
        [XmlElement(typeof(ST))]
        [XmlElement(typeof(TD1))]
        [XmlElement(typeof(TD3))]
        [XmlElement(typeof(TD5))]
        [XmlElement(typeof(TDS))]
        [XmlElement(typeof(TXI))]
        [XmlElement(typeof(UIT))]
        [XmlElement(typeof(W07))]
        [XmlElement(typeof(W13))]
        [XmlElement(typeof(W14))]
        [XmlElement(typeof(W15))]
        [XmlElement(typeof(W17))]
        [XmlElement(typeof(W19))]
        [XmlElement(typeof(XQ))]
        [XmlElement(typeof(ZA))]
        public List<ANSISegmentBase> Segments { get; set; }

        #endregion

        #region Publics

        public virtual void LoadContent(string content) { if (Properties.SaveOriginalContent) { this.Properties.OrignalContent = content; } }

        /// <summary>
        /// Generate the content
        /// </summary>
        /// <param name="printChilds">Indicate if print the childs' segments content</param>
        public virtual string ToString(bool printChilds, bool isParent = false)
        {
            StringBuilder sbContent = new StringBuilder();
            if (!isParent) { sbContent.Append(ToString()); }
            if (printChilds && Segments != null)
            {
                foreach (ANSISegmentBase segment in Segments) { sbContent.Append(segment.ToString(printChilds)); }
            }

            return sbContent.ToString();
        }

        #endregion

        #region Segments

        ANSISegmentBase GetSegment(string segmentName)
        {
            if (Segments == null) { return null; }

            return (from s in Segments
                    where s.GetType().ToString().EndsWith(segmentName)
                    select s).FirstOrDefault();
        }

        public ANSISegmentBase[] GetSegments(string segmentName)
        {
            if (Segments == null) { return new ANSISegmentBase[] { }; }

            return (from s in Segments
                    where s.GetType().ToString().EndsWith(segmentName)
                    select s).ToArray();
        }

        #endregion

        #region Index

        /// <summary>
        /// Get the segment
        /// </summary>
        /// <param name="segmentName">Segment Name</param>
        /// <returns>If exist return segment instance, if it doesn't exist return null</returns>
        public ANSISegmentBase this[string segmentName] { get { return GetSegment(segmentName); } }

        #endregion
    }
}
