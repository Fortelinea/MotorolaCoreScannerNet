using Motorola.Snapi;
using System;
using Motorola.Snapi.Constants;

namespace Motorola.Test
{
    internal class Program
    {
        private static bool _scannerAttached;

        private static void Instance_DataReceived(object sender, BarcodeScanEventArgs e)
        {
            var d = e.Data;
        }

        private static void Instance_ScannerAttached(object sender, PnpEventArgs e) 
        {
            if (e.EventType == 0)
            {
                _scannerAttached = true;
            }
        }

        private static void Main(string[] args)
        {
            _scannerAttached = false;

            BarcodeScannerManager.Instance.Open();

            BarcodeScannerManager.Instance.Attach();

            BarcodeScannerManager.Instance.Keyboard.EnableEmulation = false;

            BarcodeScannerManager.Instance.ScannerAttached += Instance_ScannerAttached;

            foreach (var scanner in BarcodeScannerManager.Instance.GetDevices())
            {
                //((BarcodeScanner)scanner).EnableLeicaBarcodes();
                if (scanner.UsbHostMode != HostMode.USB_SNAPI_Imaging)
                {
                    scanner.SetHostMode(HostMode.USB_SNAPI_Imaging);
                    while (_scannerAttached == false)
                    {
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                scanner.Initialize();
                scanner.EnableDataMatrixBarcodes();
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;

            Console.ReadLine();
        }
    }
}