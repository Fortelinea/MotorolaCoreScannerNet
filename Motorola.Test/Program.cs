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
                var c = scanner.Status.Charging;
                var d = scanner.Status.InCradle;
                var e = scanner.Status.IsHandsfree;
                var f = scanner.OCR.CheckDigitMod = 2;
                var g = scanner.OCR.CheckDigitMultiplier = "1212";
                var h = scanner.OCR.CheckDigitValidation = 3;
                var i = scanner.OCR.Despeckle = 99;
                var j = scanner.OCR.EnableExternalFinder = true;
                var k = scanner.OCR.EnableFinder = true;
                var l = scanner.OCR.EnableIllumination = true;
                var m = scanner.OCR.EnableMicre13B = true;
                var n = scanner.OCR.EnableOcrA = true;
                var o = scanner.OCR.EnableOcrB = true;
                var p = scanner.OCR.EnableUSCurrency = true;
                var q = scanner.OCR.Lines = 3;
                var r = scanner.OCR.LowPassFilter = 10;
                var s = scanner.OCR.MaxCharacters = 10;
                var t = scanner.OCR.MinCharacters = 3;
                var u = scanner.OCR.OcrAVariant = 1;
                var v = scanner.OCR.OcrBVariant = 5;
                var w = scanner.OCR.Orientation = BarcodeOrientation.UpsideDown;
                var x = scanner.OCR.QuietZone = 43;
                var y = scanner.OCR.SecurityLevel = 50;
                var z = scanner.OCR.Template = "1234ABC";
                var aa = scanner.OCR.Thicken = 10;
                var ab = scanner.OCR.ValidCharacters = "ABCDEFGHIJKLMNPQRSTUVWXYZ1234567890";
                var ac = scanner.OCR.WhiteLevel = 50;
                var ad = scanner.Discovery.BluetoothAddress;
                var ae = scanner.Discovery.CombinedFirmwareVersion;
                var af = scanner.Discovery.ConfigurationFilename;
                var ag = scanner.Discovery.DateOfFirstProgramming = DateTime.Today;
                var ah = scanner.Discovery.DateOfManufacture;
                var ai = scanner.Discovery.DeviceClass;
                var aj = scanner.Discovery.ImagekitVersion;
                var ak = scanner.Discovery.LastServiceDate;
                var al = scanner.Discovery.ModelNumber;
                var am = scanner.Discovery.RsmVersion;
                var an = scanner.Discovery.ScankitVersion;
                var ao = scanner.Discovery.ScannerFirmwareVersion;
                var ap = scanner.Discovery.SerialNumber;
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;

            Console.ReadLine();
        }
    }
}