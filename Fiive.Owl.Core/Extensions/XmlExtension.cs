using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Fiive.Owl.Core.Extensions
{
    /// <summary>
    /// Provide Xml extensions methods
    /// </summary>
    public static class XmlExtension
    {
        #region Serialize

        /// <summary>
        /// Serialize an object
        /// </summary>
        /// <typeparam name="T">Object type to serialize</typeparam>
        /// <param name="objectToSerialize">Object to serialize</param>
        /// <returns>Serialized object</returns>
        public static XmlDocument Serialize<T>(T objectToSerialize) where T : class
        {
            #region Validate Arguments

            if (objectToSerialize == null) { throw new ArgumentNullException("objectToSerialize", string.Format("Se debe enviar una instancia de tipo '{0}'", typeof(T))); }

            #endregion // End-Validate Arguments

            MemoryStream stream = new MemoryStream();
            XmlSerializer ser = new XmlSerializer(typeof(T));

            ser.Serialize(stream, objectToSerialize);
            stream.Seek(0, SeekOrigin.Begin);

            XmlDocument document = new XmlDocument();
            document.Load(stream);

            return document;
        }

        /// <summary>
        /// Serialize an object array
        /// </summary>
        /// <typeparam name="T">Object type to serialize</typeparam>
        /// <param name="objectsToSerialize">Objects to serialize</param>
        /// <returns>Serialized objects</returns>
        public static IEnumerable<XmlDocument> Serialize<T>(T[] objectsToSerialize) where T : class
        {
            #region Validate Arguments

            if (objectsToSerialize == null) { throw new ArgumentNullException("objectsToSerialize", string.Format("Se debe enviar una lista de instancias de tipo '{0}'", typeof(T))); }

            #endregion // End-Validate Arguments

            foreach (T _object in objectsToSerialize)
            {
                yield return Serialize<T>(_object);
            }
        }

        #endregion // End-Serialize

        #region Deserialize

        /// <summary>
        /// Deserialize an object
        /// </summary>
        /// <typeparam name="T">Object type to deserialize</typeparam>
        /// <param name="document">Object to deserialize</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize<T>(XmlDocument document) where T : class
        {
            #region Validate Arguments

            if (document == null) { throw new ArgumentNullException("document", "Se debe enviar una instancia de System.Xml.XmlDocument"); }

            #endregion // End-Validate Arguments

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(document.OuterXml))
                {
                    return (T)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deserialize an object array
        /// </summary>
        /// <typeparam name="T">Objects type to serialize</typeparam>
        /// <param name="documents">Objects to deserialize</param>
        /// <returns>Deserialized objects</returns>
        public static IEnumerable<T> Deserialize<T>(XmlDocument[] documents) where T : class
        {
            #region Validate Arguments

            if (documents == null) { throw new ArgumentNullException("documents", "Se debe enviar una lista de instancias de System.Xml.XmlDocument"); }

            #endregion // End-Validate Arguments

            foreach (XmlDocument document in documents)
            {
                yield return (T)Deserialize<T>(document);
            }
        }

        #endregion // End-Deserialize
    }
}
