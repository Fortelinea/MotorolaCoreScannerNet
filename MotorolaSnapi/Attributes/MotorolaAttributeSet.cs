using CoreScanner;
using Motorola.Snapi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorola.Snapi.Attributes
{
    public abstract class MotorolaAttributeSet
    {
        protected readonly string _getAttributesXml;
        protected readonly string _setAttributeXml;
        protected CCoreScannerClass _scannerDriver;
        protected int _scannerId;

        protected MotorolaAttributeSet(int scannerId, CCoreScannerClass scannerDriver)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
            _getAttributesXml = String.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list>{1}</attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}");
            _setAttributeXml = String.Format(@"<inArgs><cmdArgs><scannerID>{0}</scannerID><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}", @"{1}", @"{2}");
        }

        protected void GetAttribute(ushort id)
        {
            var xml = String.Format(_getAttributesXml, id);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);
        }

        protected void GetAttributes(List<ushort> ids)
        {
            var xml = String.Format(_getAttributesXml, String.Join(",", ids.Select(n => n.ToString()).ToArray()));
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.AttrGet, ref xml, out outXml, out status);
        }

        protected void SetAttribute(int attributeId, DataType dataType, object value)
        {
            var xml = String.Format(_setAttributeXml, attributeId, dataType, value);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterPersistence, ref xml, out outXml, out status);
        }
    }
}