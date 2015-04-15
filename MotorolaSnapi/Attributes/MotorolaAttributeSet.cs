using CoreScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Base class for all attribute sets. Contains methods for setting and getting attributes.
    /// </summary>
    public abstract class MotorolaAttributeSet
    {
        protected readonly string _getAttributesXml;
        protected readonly string _setAttributeXml;
        protected CCoreScanner _scannerDriver;
        protected int _scannerId;

        /// <summary>
        /// Initializes this base class. Must be inherited
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver"></param>
        protected MotorolaAttributeSet(int scannerId, CCoreScanner scannerDriver)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
            _getAttributesXml = String.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list>{1}</attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}");
            _setAttributeXml = String.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}", @"{1}", @"{2}");
        }

        /// <summary>
        /// Get an attribute from the scanner given it's ID.
        /// </summary>
        /// <param name="id">Attribute ID</param>
        /// <returns>ScannerAttribute object holding identification info and the value of the attribute.</returns>
        protected ScannerAttribute GetAttribute(ushort id)
        {
            var xml = String.Format(_getAttributesXml, id);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);
            if (status != 0)
            {
                throw new ScannerException(string.Format("Failed to get attribute {0}. Error code {1}", id, status)) { ErrorCode = (StatusCode)status };
            }
            if (outXml == null)
                return null;
            XDocument doc = XDocument.Parse(outXml);
            var xmlAttribute = doc.Descendants("attribute").Single();
            var name = xmlAttribute.Descendants("name").Single().Value;
            var dataType = (DataType)xmlAttribute.Descendants("datatype").Single().Value[0];
            var permission = xmlAttribute.Descendants("permission").Single().Value[0];
            var stringValue = xmlAttribute.Descendants("value").Single().Value;
            var value = ValueConverters.StringToActualType(dataType, stringValue);

            var retval = new ScannerAttribute { Id = id, Name = name, DataType = dataType, Permission = permission, Value = value };
            return retval;
        }

        /// <summary>
        /// Get a Dictionary of attributes from the scanner given a List of attribute IDs.
        /// </summary>
        /// <param name="ids">Attribute ID list</param>
        /// <returns>Dictionary of ScannerAttribute objects holding identification info and the value of their corrisponding attribute. Keyed by id.</returns>
        protected IDictionary<ushort, ScannerAttribute> GetAttributes(List<ushort> ids)
        {
            var xml = String.Format(_getAttributesXml, String.Join(",", ids.Select(n => n.ToString()).ToArray()));
            string outXml = null;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);
            if (status != 0)
            {
                throw new ScannerException(string.Format("Failed to get attributes. Error code {0}", status)){ ErrorCode = (StatusCode)status };
            }

            var retval = new Dictionary<ushort, ScannerAttribute>();
            XDocument doc;
            try
            {
                doc = XDocument.Parse(outXml);
            }
            catch (XmlException e)
            {
                System.Threading.Thread.Sleep(1000);
                return GetAttributes(ids);
            }
            var attributes = doc.Descendants("attribute");
            foreach (var xmlAttribute in attributes)
            {
                var id = ushort.Parse(xmlAttribute.Descendants("id").Single().Value);
                var name = xmlAttribute.Descendants("name").Single().Value;
                var dataType = (DataType)xmlAttribute.Descendants("datatype").Single().Value[0];
                var permission = xmlAttribute.Descendants("permission").Single().Value[0];
                var stringValue = xmlAttribute.Descendants("value").Single().Value;
                var value = ValueConverters.StringToActualType(dataType, stringValue);
                retval.Add(id, new ScannerAttribute { Id = id, Name = name, DataType = dataType, Permission = permission, Value = value });
            }
            return retval;
        }

        /// <summary>
        /// Sets an attribute on the scanner given a ScannerAttribute object.
        /// </summary>
        /// <param name="attribute">ScannerAttribute object containing identification info and the value of the attribute to set.</param>
        protected void SetAttribute(ScannerAttribute attribute)
        {
            var xml = String.Format(_setAttributeXml, attribute.Id, (char)attribute.DataType, attribute.Value);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterPersistence, ref xml, out outXml, out status);
            if (status != 0)
            {
                throw new ScannerException(string.Format("Failed to set attribute {0}. Error code {1}", attribute.Id, status)){ErrorCode = (StatusCode)status};
            }
        }
    }
}