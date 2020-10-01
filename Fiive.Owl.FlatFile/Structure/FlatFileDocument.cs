using Fiive.Owl.FlatFile.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiive.Owl.Core.Extensions;
using System.Xml.Serialization;
using Fiive.Owl.Core.Exceptions;

namespace Fiive.Owl.FlatFile.Structure
{
    [XmlRoot("owl")]
    public class FlatFileDocument : Section
    {
        #region Vars

        int _currentPos;
        OwlSection _lastValidSegment;

        #endregion

        #region Publics

        public void LoadContent(OwlConfig config, string content)
        {
            #region Validate params

            if (config == null) { throw new ArgumentNullException("config", "config is null"); }
            if (config.Sections.Count == 0) { throw new OwlAdapterException("Owl config does not have sections configured"); }
            if (string.IsNullOrEmpty(content)) { throw new OwlContentException("The document is empty"); }

            #endregion

            InitializeProperties();
            if (!content.EndsWith(Properties.SegmentTerminator)) { content += Properties.SegmentTerminator; } // Fix the last terminator

            var sb = new StringBuilder(content);
            this.Sections.AddRange(Load(config.Sections, sb));

            if (sb.Length != 0)
            {
                string message = string.Format("Invalid content found in position '{0}'.", _currentPos);
                if (_lastValidSegment != null) { message += string.Format(" The last valid section was '{0}'", _lastValidSegment.Name); }

                throw new OwlContentException(message);
            }
        }

        public override string ToString() { return ToString(true, true); }

        #endregion

        #region Privates

        List<Section> Load(List<OwlSection> sections, StringBuilder content)
        {
            List<Section> listSegments = new List<Section>();
            foreach (OwlSection section in sections)
            {
                if (content.Length == 0) { break; }
                string segmentContent = string.Empty;

                do
                {
                    segmentContent = GetSegmentContent(content, section);

                    if (!string.IsNullOrEmpty(segmentContent))
                    {
                        // Create segment
                        Section iSegment = GetSegmentInstance(segmentContent, section);
                        listSegments.Add(iSegment);

                        content.Remove(0, segmentContent.Length + iSegment.Properties.SegmentTerminator.Length);

                        // Log validators
                        _currentPos += segmentContent.Length;
                        _lastValidSegment = section;

                        if (section.Sections != null && section.Sections.Count != 0)
                        {
                            var internalSegments = Load(section.Sections, content);
                            if (internalSegments.Count != 0)
                            {
                                iSegment.Sections = new List<Section>();
                                iSegment.Sections.AddRange(internalSegments);
                            }
                        }
                    }
                } while (!string.IsNullOrEmpty(segmentContent)); // The while is for the segments that have repetitions
            }

            return listSegments;
        }

        Section GetSegmentInstance(string content, OwlSection section)
        {
            Section iSegment = new Section();
            iSegment.Properties = (OwlProperties)Properties.Clone(); // TODO: Validate clone
            iSegment.Configuration = section;
            iSegment.Name = section.Name;
            iSegment.LoadContent(content);

            return iSegment;
        }

        string GetSegmentContent(StringBuilder content, OwlSection section)
        {
            // Two options
                // Content start with the section id
                // Id is empty and the process get always the line
            if (!content.StartsWith(string.Concat(section.Id, section.Separator)) && !string.IsNullOrEmpty(section.Id)) { return string.Empty; }

            int intEndSegment = content.IndexOf(Properties.SegmentTerminator);
            if (intEndSegment == -1) { return string.Empty; } // if the index is 0 the segment terminator wasn't found

            string segment = content.Substring(0, intEndSegment);
            return segment;
        }

        void InitializeProperties()
        {
            Sections = new List<Section>();
            if (Properties == null) { Properties = new OwlProperties(); }
            _currentPos = 1;
            _lastValidSegment = null;
        }

        #endregion
    }
}
