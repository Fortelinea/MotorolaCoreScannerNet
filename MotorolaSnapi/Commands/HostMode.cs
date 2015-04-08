using CoreScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorola.Snapi.Commands
{
    public class HostMode
    {
        private CCoreScannerClass _scannerDriver;
        private int _scannerId;

        internal HostMode(int scannerId, CCoreScannerClass scannerDriver)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }
    }
}