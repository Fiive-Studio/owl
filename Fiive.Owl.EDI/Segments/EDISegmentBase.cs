using Fiive.Owl.Core.Adapters;
using Fiive.Owl.EDI.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fiive.Owl.EDI.Segments
{
    /// <summary>
    /// Represent a Segment Base
    /// </summary>
    public class EDISegmentBase : IEDISegment
    {
        #region IEDISegment

        [XmlIgnore]
        public EDISegmentProperties Properties { get; set; }

        #endregion

        #region Properties

        [XmlElement(typeof(AJT))]
        [XmlElement(typeof(ALC))]
        [XmlElement(typeof(ALI))]
        [XmlElement(typeof(APR))]
        [XmlElement(typeof(BGM))]
        [XmlElement(typeof(CCI))]
        [XmlElement(typeof(CDI))]
        [XmlElement(typeof(CNT))]
        [XmlElement(typeof(COM))]
        [XmlElement(typeof(CPS))]
        [XmlElement(typeof(CTA))]
        [XmlElement(typeof(CUX))]
        [XmlElement(typeof(DGS))]
        [XmlElement(typeof(DLI))]
        [XmlElement(typeof(DLM))]
        [XmlElement(typeof(DOC))]
        [XmlElement(typeof(DTM))]
        [XmlElement(typeof(EQD))]
        [XmlElement(typeof(EQN))]
        [XmlElement(typeof(ERC))]
        [XmlElement(typeof(FII))]
        [XmlElement(typeof(FTX))]
        [XmlElement(typeof(GID))]
        [XmlElement(typeof(GIN))]
        [XmlElement(typeof(GIR))]
        [XmlElement(typeof(HAN))]
        [XmlElement(typeof(IMD))]
        [XmlElement(typeof(INV))]
        [XmlElement(typeof(LIN))]
        [XmlElement(typeof(LOC))]
        [XmlElement(typeof(MEA))]
        [XmlElement(typeof(MKS))]
        [XmlElement(typeof(MOA))]
        [XmlElement(typeof(NAD))]
        [XmlElement(typeof(PAC))]
        [XmlElement(typeof(PAI))]
        [XmlElement(typeof(PAT))]
        [XmlElement(typeof(PCD))]
        [XmlElement(typeof(PCI))]
        [XmlElement(typeof(PGI))]
        [XmlElement(typeof(PIA))]
        [XmlElement(typeof(PRI))]
        [XmlElement(typeof(PYT))]
        [XmlElement(typeof(QTY))]
        [XmlElement(typeof(QVR))]
        [XmlElement(typeof(RCS))]
        [XmlElement(typeof(RFF))]
        [XmlElement(typeof(RNG))]
        [XmlElement(typeof(RTE))]
        [XmlElement(typeof(SCC))]
        [XmlElement(typeof(SEL))]
        [XmlElement(typeof(STG))]
        [XmlElement(typeof(STS))]
        [XmlElement(typeof(TAX))]
        [XmlElement(typeof(TDT))]
        [XmlElement(typeof(TMP))]
        [XmlElement(typeof(TOD))]
        [XmlElement(typeof(UCD))]
        [XmlElement(typeof(UCI))]
        [XmlElement(typeof(UCM))]
        [XmlElement(typeof(UCS))]
        [XmlElement(typeof(UNA))]
        [XmlElement(typeof(UNB))]
        [XmlElement(typeof(UNE))]
        [XmlElement(typeof(UNG))]
        [XmlElement(typeof(UNH))]
        [XmlElement(typeof(UNS))]
        [XmlElement(typeof(UNT))]
        [XmlElement(typeof(UNZ))]
        [XmlElement(typeof(USA))]
        [XmlElement(typeof(USC))]
        [XmlElement(typeof(USH))]
        [XmlElement(typeof(USR))]
        [XmlElement(typeof(UST))]
        public List<EDISegmentBase> Segments { get; set; }

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
                foreach (EDISegmentBase segment in Segments) { sbContent.Append(segment.ToString(printChilds)); }
            }

            return sbContent.ToString();
        }

        #endregion

        #region Segments

        EDISegmentBase GetSegment(string segmentName)
        {
            if (Segments == null) { return null; }

            return (from s in Segments
                    where s.GetType().ToString().EndsWith(segmentName)
                    select s).FirstOrDefault();
        }

        public EDISegmentBase[] GetSegments(string segmentName)
        {
            if (Segments == null) { return new EDISegmentBase[] { }; }

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
        public EDISegmentBase this[string segmentName] { get { return GetSegment(segmentName); } }

        #endregion
    }
}
