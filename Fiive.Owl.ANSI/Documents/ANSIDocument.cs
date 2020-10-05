using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Adapters;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.ANSI.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Fiive.Owl.ANSI.Config;

namespace Fiive.Owl.ANSI.Documents
{
    /// <summary>
    /// Represent an ANSI Document
    /// </summary>
    public class ANSIDocument : ANSISegmentBase
    {
        #region Vars

        int _currentPos;
        OwlANSISection _lastValidSegment;

        #endregion

        #region Publics

        public void LoadContent(OwlANSIConfig config, string content)
        {
            #region Validate params

            if (config == null) { throw new ArgumentNullException("config", "El parametro 'config' no puede ser nulo"); }
            if (config.Sections.Count == 0) { throw new OwlAdapterException("El Owl Input Config no tiene Secciones configuradas"); }
            if (content.IsNullOrWhiteSpace()) { throw new OwlContentException("El documento ANSI no contiene información"); }

            #endregion

            InitializeProperties();

            #region Previous Validation

            // This validation is for process correctly the segment terminator
            try
            {
                content = Regex.Replace(content,
                   string.Format(@"\{0}\{1}", Properties.ReleaseChar, Properties.SegmentSeparator), (match) => { return "```"; });
            }
            catch (ArgumentException)
            {
                content = Regex.Replace(content,
                   string.Format(@"\{0}{1}", Properties.ReleaseChar, Properties.SegmentSeparator), (match) => { return "```"; });
            }

            #endregion

            var sb = new StringBuilder(content);
            this.Segments.AddRange(Load(config.Sections, sb));

            if (sb.Length != 0)
            {
                string message = string.Format("Se encontró un contenido no válido en la posición '{0}'.", _currentPos);
                if (_lastValidSegment != null) { message += string.Format(" El último segmento válido fue '{0}'", _lastValidSegment.Name); }

                throw new OwlContentException(message);
            }
        }

        public override string ToString() { return ToString(true, true); }

        #endregion

        #region Privates

        List<ANSISegmentBase> Load(List<OwlANSISection> sections, StringBuilder content)
        {
            List<ANSISegmentBase> listSegments = new List<ANSISegmentBase>();
            foreach (OwlANSISection section in sections)
            {
                if (content.Length == 0) { break; }
                string segmentContent = string.Empty;

                do
                {
                    segmentContent = GetSegmentContent(content, section);

                    if (!string.IsNullOrEmpty(segmentContent))
                    {
                        // Create segment
                        ANSISegmentBase iSegment = GetSegmentInstance(segmentContent, section.Name);
                        listSegments.Add(iSegment);

                        content.Remove(0, segmentContent.Length);

                        // Log validators
                        _currentPos += segmentContent.Length;
                        _lastValidSegment = section;

                        if (section.Sections != null && section.Sections.Count != 0)
                        {
                            var internalSegments = Load(section.Sections, content);
                            if (internalSegments.Count != 0)
                            {
                                iSegment.Segments = new List<ANSISegmentBase>();
                                iSegment.Segments.AddRange(internalSegments);
                            }
                        }
                    }
                } while (!string.IsNullOrEmpty(segmentContent)); // The while is for the segments that have repetitions
            }

            return listSegments;
        }

        ANSISegmentBase GetSegmentInstance(string content, string segmentName)
        {
            if (segmentName == "CON") { segmentName = "CON_"; }
            Type type = Type.GetType(string.Format(OwlAdapterSettings.Settings.MapperANSILibrary, segmentName));
            if (type == null) { throw new OwlContentException(string.Format("El segmento '{0}' no es válido para un documento ANSI", segmentName)); }

            ANSISegmentBase iSegment = (ANSISegmentBase)Activator.CreateInstance(type);
            iSegment.Properties = (ANSISegmentProperties)Properties.Clone();
            iSegment.LoadContent(content);

            return iSegment;
        }

        string GetSegmentContent(StringBuilder content, OwlANSISection section)
        {
            if (!content.StartsWith(section.Name)) { return string.Empty; } // If the content doesn't start with the section name break the process

            int intEndSegment = content.IndexOf(Properties.SegmentSeparator);
            if (intEndSegment == -1) { return string.Empty; } // if the index is 0 the segment terminator wasn't found

            string segment = content.Substring(0, intEndSegment);
            int intElementSeparator = segment.IndexOf(Properties.ElementSeparator);
            if (intElementSeparator == -1) { intElementSeparator = intEndSegment; } // Some segments doesn't have elements

            if (segment.GetSafeSubstring(0, intElementSeparator) == section.Name)
            {
                return string.Concat(segment, Properties.SegmentSeparator);
            }

            return string.Empty;
        }

        void InitializeProperties()
        {
            Segments = new List<ANSISegmentBase>();
            if (Properties == null) { Properties = new ANSISegmentProperties(); }
            _currentPos = 1;
            _lastValidSegment = null;
        }

        #endregion
    }
}
