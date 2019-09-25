using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Structure;
using Fiive.Owl.FlatFile.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fiive.Owl.FlatFile.Structure
{
    public class Section
    {
        [XmlIgnore]
        public OwlProperties Properties { get; set; }
        [XmlIgnore]
        public OwlSection Configuration { get; set; }

        #region Properties

        [XmlElement(Type = typeof(Section), ElementName = "section")]
        public List<Section> Sections { get; set; }

        [XmlElement(Type = typeof(Element), ElementName = "element")]
        public List<Element> Elements { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        #endregion

        #region Publics

        public virtual void LoadContent(string content)
        {
            if (Properties.SaveOriginalContent) { this.Properties.OrignalContent = content; }
            LoadFieldsContent(content);
        }

        public void LoadFieldsContent(string content)
        {
            Elements = new List<Element>();
            if (Configuration.Separator != null)
            {
                string[] fields = content.Split(new string[] { Configuration.Separator }, StringSplitOptions.None);
                int pos = 0;
                foreach (OwlElement element in Configuration.Elements)
                {
                    if (pos == fields.Length) { break; }

                    string value = fields[pos];
                    ValidateElement(element, value, true);
                    Elements.Add(new Element { Name = element.Name, Value = value });
                    pos++;
                }
            }
            else
            {
                foreach (OwlElement element in Configuration.Elements)
                {
                    string value = content.GetSafeSubstring(element.StartPosition, element.Length);
                    ValidateElement(element, value);
                    Elements.Add(new Element { Name = element.Name, Value = value });
                }
            }
        }

        /// <summary>
        /// Generate the content
        /// </summary>
        /// <param name="printChilds">Indicate if print the childs' segments content</param>
        public virtual string ToString(bool printChilds, bool isParent = false)
        {
            StringBuilder sbContent = new StringBuilder();
            if (!isParent)
            {
                if (Elements != null && Elements.Count > 0)
                {
                    string[] values = new string[Elements.Count];
                    int pos = 0;
                    foreach (Element element in Elements) { values[pos] = element.ToString(); pos++; }

                    sbContent.AppendLine(string.Join(Configuration.Separator, values));
                }
            }

            if (printChilds && Sections != null)
            {
                foreach (Section segment in Sections) { sbContent.Append(segment.ToString(printChilds)); }
            }

            return sbContent.ToString();
        }

        #endregion

        #region Privates

        void ValidateElement(OwlElement element, string value, bool validateLength = false)
        {
            // Required
            if (element.Required && string.IsNullOrWhiteSpace(value)) { throw new OwlRequiredException($"The element: '{element.Name}' - section: '{Configuration.Name}' is required"); }

            // DataType
            if (element.DataType == DataType.Int && !value.IsInt()) { throw new OwlDataTypeException($"The element: '{element.Name}' - section: '{Configuration.Name}' have data-type: 'int' and the sent value is: '{value}'"); }
            else if (element.DataType == DataType.Decimal && !value.IsDecimal()) { throw new OwlDataTypeException($"The element: '{element.Name}' - section: '{Configuration.Name}' have data-type: 'decimal' and the sent value is: '{value}'"); }

            // Length
            if (validateLength && element.Length > 0 && value.Length > element.Length) { throw new OwlLengthException($"The element: '{element.Name}' - section: '{Configuration.Name}' have length: '{value.Length}' and the allowed length is: '{element.Length}' - sent value is: '{value}'"); }
        }

        #endregion

        #region Segments

        Section GetSegment(string segmentName)
        {
            if (Sections == null) { return null; }

            return (from s in Sections
                    where s.Name == segmentName
                    select s).FirstOrDefault();
        }

        public Section[] GetSegments(string segmentName)
        {
            if (Sections == null) { return new Section[] { }; }

            return (from s in Sections
                    where s.Name == segmentName
                    select s).ToArray();
        }

        #endregion

        #region Index

        /// <summary>
        /// Get the segment
        /// </summary>
        /// <param name="segmentName">Segment Name</param>
        /// <returns>If exist return segment instance, if it doesn't exist return null</returns>
        public Section this[string segmentName] { get { return GetSegment(segmentName); } }

        #endregion
    }
}
