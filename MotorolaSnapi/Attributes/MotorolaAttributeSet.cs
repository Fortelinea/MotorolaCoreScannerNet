using CoreScanner;
using Motorola.Snapi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Motorola.Snapi.Attributes
{
    public abstract class MotorolaAttributeSet
    {
        protected readonly string _getAttributesXml;
        protected readonly string _setAttributeXml;
        protected ICoreScanner _scannerDriver;
        protected int _scannerId;

        protected MotorolaAttributeSet(int scannerId, ICoreScanner scannerDriver)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
            _getAttributesXml = String.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list>{1}</attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}");
            _setAttributeXml = String.Format(@"<inArgs><cmdArgs><scannerID>{0}</scannerID><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}", @"{1}", @"{2}");
        }

        protected ScannerAttribute GetAttribute(ushort id)
        {
            var xml = String.Format(_getAttributesXml, id);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);

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

        protected IDictionary<OcrAttribute, ScannerAttribute> GetAttributes(List<ushort> ids)
        {
            var xml = String.Format(_getAttributesXml, String.Join(",", ids.Select(n => n.ToString()).ToArray()));
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);

            var retval = new Dictionary<OcrAttribute, ScannerAttribute>();
            XDocument doc = XDocument.Parse(outXml);
            var attributes = doc.Descendants("attribute");
            foreach (var xmlAttribute in attributes)
            {
                var id = ushort.Parse(xmlAttribute.Descendants("id").Single().Value);
                var name = xmlAttribute.Descendants("name").Single().Value;
                var dataType = (DataType)xmlAttribute.Descendants("datatype").Single().Value[0];
                var permission = xmlAttribute.Descendants("permission").Single().Value[0];
                var stringValue = xmlAttribute.Descendants("value").Single().Value;
                var value = ValueConverters.StringToActualType(dataType, stringValue);
                retval.Add((OcrAttribute)id, new ScannerAttribute { Id = id, Name = name, DataType = dataType, Permission = permission, Value = value });
            }
            return retval;
        }

        protected void SetAttribute(ScannerAttribute attribute)
        {
            var xml = String.Format(_setAttributeXml, attribute.Id, attribute.DataType, attribute.Value);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterPersistence, ref xml, out outXml, out status);
        }
    }
}