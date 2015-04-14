using Motorola.Snapi;
using System;
using Motorola.Snapi.Constants;

namespace Motorola.Test
{
    internal class Program
    {
        private static bool _scannerAttached;
        private static string _lastScanned;

        private static void Instance_DataReceived(object sender, BarcodeScanEventArgs e)
        {
            _lastScanned = e.Data;
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

            BarcodeScannerManager.Instance.RegisterForEvents(EventType.Barcode, EventType.Pnp);

            var b = BarcodeScannerManager.Instance.RegisteredEvents;

            BarcodeScannerManager.Instance.Keyboard.EnableEmulation = false;

            BarcodeScannerManager.Instance.ScannerAttached += Instance_ScannerAttached;

            var a = BarcodeScannerManager.Instance.DriverVersion;

            foreach (var scanner in BarcodeScannerManager.Instance.GetDevices())
            {
                if (scanner.UsbHostMode != HostMode.USB_SNAPI_Imaging)
                {
                    scanner.SetHostMode(HostMode.USB_SNAPI_Imaging);
                    while (_scannerAttached == false)
                    {
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                scanner.Initialize();

            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;

            Console.ReadLine();
        }
    }
}