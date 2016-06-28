/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    ///     Base class for all attribute sets. Contains methods for setting and getting attributes.
    /// </summary>
    public abstract class MotorolaAttributeSet
    {
        protected readonly string _getAttributesXml;

        protected readonly CCoreScanner _scannerDriver;

        protected readonly int _scannerId;

        protected readonly string _setAttributeXml;

        /// <summary>
        ///     Initializes this base class. Must be inherited
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver"></param>
        protected MotorolaAttributeSet(int scannerId, CCoreScanner scannerDriver)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
            _getAttributesXml = $@"<inArgs><scannerID>{scannerId}</scannerID><cmdArgs><arg-xml><attrib_list>{{0}}</attrib_list></arg-xml></cmdArgs></inArgs>";
            _setAttributeXml =
                $@"<inArgs><scannerID>{scannerId}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{{0}}</id><datatype>{{1}}</datatype><value>{{2}}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>";
        }

        /// <summary>
        ///     Get an attribute from the scanner given it's ID.
        /// </summary>
        /// <param name="id">Attribute ID</param>
        /// <returns>ScannerAttribute object holding identification info and the value of the attribute.</returns>
        protected ScannerAttribute GetAttribute(ushort id)
        {
            var xml = string.Format(_getAttributesXml, id);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);

            if (outXml == null)
                return null;
            var doc = XDocument.Parse(outXml);
            var xmlAttribute = doc.Descendants("attribute").Single();
            var name = xmlAttribute.Descendants("name").Single().Value;
            var dataType = (DataType)xmlAttribute.Descendants("datatype").Single().Value[0];
            var permission = xmlAttribute.Descendants("permission").Single().Value[0];
            var stringValue = xmlAttribute.Descendants("value").Single().Value;
            var value = ValueConverters.StringToActualType(dataType, stringValue);

            var retval = new ScannerAttribute
                         {
                             Id = id,
                             Name = name,
                             DataType = dataType,
                             Permission = permission,
                             Value = value
                         };
            return retval;
        }

        /// <summary>
        ///     Get a Dictionary of attributes from the scanner given a List of attribute IDs.
        /// </summary>
        /// <param name="ids">Attribute ID list</param>
        /// <returns>
        ///     Dictionary of ScannerAttribute objects holding identification info and the value of their corrisponding
        ///     attribute. Keyed by id.
        /// </returns>
        protected IDictionary<ushort, ScannerAttribute> GetAttributes(IEnumerable<ushort> ids)
        {
            var xml = string.Format(_getAttributesXml, string.Join(",", ids.Select(n => n.ToString()).ToArray()));
            string outXml = null;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);

            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);

            var retval = new Dictionary<ushort, ScannerAttribute>();
            var doc = XDocument.Parse(outXml);
            var attributes = doc.Descendants("attribute");
            foreach (var xmlAttribute in attributes)
            {
                var id = ushort.Parse(xmlAttribute.Descendants("id").Single().Value);
                var name = xmlAttribute.Descendants("name").Single().Value;
                var dataType = (DataType)xmlAttribute.Descendants("datatype").Single().Value[0];
                var permission = xmlAttribute.Descendants("permission").Single().Value[0];
                var stringValue = xmlAttribute.Descendants("value").Single().Value;
                var value = ValueConverters.StringToActualType(dataType, stringValue);
                retval.Add(id,
                           new ScannerAttribute
                           {
                               Id = id,
                               Name = name,
                               DataType = dataType,
                               Permission = permission,
                               Value = value
                           });
            }
            return retval;
        }

        /// <summary>
        ///     Sets an attribute on the scanner given a ScannerAttribute object.
        /// </summary>
        /// <param name="attribute">ScannerAttribute object containing identification info and the value of the attribute to set.</param>
        protected void SetAttribute(ScannerAttribute attribute)
        {
            var xml = string.Format(_setAttributeXml, attribute.Id, (char)attribute.DataType, attribute.Value);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrStore, ref xml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);

            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterPersistence, ref xml, out outXml, out status);
            s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }
    }
}