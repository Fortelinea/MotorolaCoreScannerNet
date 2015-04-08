using CoreScanner;
using Motorola.Snapi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorola.Snapi.Commands
{
    public abstract class MotorolaCommandSet
    {
        protected readonly string _getCommandXml;
        protected readonly string _setCommandXml;
        protected CCoreScannerClass _scannerDriver;
        protected int _scannerId;

        protected MotorolaCommandSet(int scannerId, CCoreScannerClass scannerDriver)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
            _getCommandXml = String.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list>{1}</attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}");
            _setCommandXml = String.Format(@"<inArgs><cmdArgs><scannerID>{0}</scannerID><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", scannerId, @"{0}", @"{1}", @"{2}");
        }

        protected void SetCommand(int attributeId, object value)
        {
            var xml = String.Format(_setCommandXml, attributeId, value);
            string outXml;
            int status;

            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterPersistence, ref xml, out outXml, out status);
        }
    }
}