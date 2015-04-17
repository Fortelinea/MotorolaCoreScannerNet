using Motorola.Snapi;
using System;
using System.ComponentModel;
using System.Reflection;
using Motorola.Snapi.Constants;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Test
{
    internal static class Program
    {
        private static bool _scannerAttached;
        private static string _lastScanned;
        private const string ImageSaveLocation = @"C:\Users\Jason\Desktop\Image.jpg";

        private static void Instance_DataReceived(object sender, BarcodeScanEventArgs e)
        {
            _lastScanned = e.Data;
            var raw = System.Text.Encoding.Default.GetString(e.RawData);
            Console.WriteLine("Barcode type: " + e.BarcodeType.GetDescription());
            Console.WriteLine("Data: " + e.Data);
        }

        private static void Instance_ScannerAttached(object sender, PnpEventArgs e) 
        {
            _scannerAttached = true;
        }

        private static void Instance_ImageReceived(object sender, ImageEventArgs e)
        {
            e.Image.Save(ImageSaveLocation, e.Format);      
            Console.WriteLine("Image saved to \"{0}\"", ImageSaveLocation);
        }

        private static void Main(string[] args)
        {
            _scannerAttached = false;

            BarcodeScannerManager.Instance.Open();

            BarcodeScannerManager.Instance.RegisterForEvents(EventType.Barcode, EventType.Pnp, EventType.Image);

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
                scanner.CaptureMode = CaptureMode.Barcode;
                scanner.SetAllDefault();
                GetAttributes(scanner);
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;
            BarcodeScannerManager.Instance.ImageReceived += Instance_ImageReceived;

            Console.WriteLine("Ready to scan.. (Enter to quit)");
            Console.ReadLine();
        }

        private static void GetAttributes(IMotorolaSnapiScanner scanner)
        {
            //TestStatus(scanner);
            //TestOcr(scanner);
            //TestDiscovery(scanner);
            //TestImaging(scanner);
            //TestEvents(scanner);
            //TestBeeper(scanner);
            //TestLicense(scanner);
            //TestADF(scanner);
            //TestSynapse(scanner);
            //TestUpcEan(scanner);
        }

        private static void TestUpcEan(IMotorolaSnapiScanner scanner)
        {
            var cc = scanner.UPC_EAN.BooklandEanEnabled = false;
            var cd = scanner.UPC_EAN.ConvertUpcE1toA = false;
            var ce = scanner.UPC_EAN.ConvertUpcEtoA = false;
            var cf = scanner.UPC_EAN.Ean13Jan13Enabled = false;
            var cg = scanner.UPC_EAN.Ean8Jan8Enabled = false;
            var ch = scanner.UPC_EAN.Ean8Jan8Extend = false;
            var ci = scanner.UPC_EAN.Supp2Enabled = false;
            var cj = scanner.UPC_EAN.Supp5Enabled = false;
            var ck = scanner.UPC_EAN.TransmitCodeId = TransmitCodeId.None;
            var cl = scanner.UPC_EAN.TransmitUpcACheckDigit = false;
            var cm = scanner.UPC_EAN.TransmitUpcE1CheckDigit = false;
            var cn = scanner.UPC_EAN.TransmitUpcECheckDigit = false;
            var co = scanner.UPC_EAN.UccCouponExtendedCodeEnabled = false;
            var cp = scanner.UPC_EAN.UpcAEnabled = false;
            var cq = scanner.UPC_EAN.UpcAPreamble = UpcPreamble.NoPreamble;
            var cr = scanner.UPC_EAN.UpcE1Enabled = false;
            var cs = scanner.UPC_EAN.UpcE1Preamble = UpcPreamble.NoPreamble;
            var ct = scanner.UPC_EAN.UpcEEnabled = false;
            var cu = scanner.UPC_EAN.UpcEPreamble = UpcPreamble.NoPreamble;
            var cv = scanner.UPC_EAN.UpcEanJanSupplementalMode = SupplementalMode.IgnoreSupplemental;
            var cw = scanner.UPC_EAN.UpcEanJanSupplementalRedundancy = 2;
        }

        private static void TestSynapse(IMotorolaSnapiScanner scanner) { var cb = scanner.Synapse.Value; }

        private static void TestADF(IMotorolaSnapiScanner scanner)
        {
            var bl = scanner.ADF.KeyDelay;
            var bm = scanner.ADF.ADFRules;
            var bn = scanner.ADF.KeyCategory1;
            var bo = scanner.ADF.KeyCategory2;
            var bp = scanner.ADF.KeyCategory3;
            var bq = scanner.ADF.KeyCategory4;
            var br = scanner.ADF.KeyCategory5;
            var bs = scanner.ADF.KeyCategory6;
            var bt = scanner.ADF.KeyValue1;
            var bu = scanner.ADF.KeyValue2;
            var bv = scanner.ADF.KeyValue3;
            var bw = scanner.ADF.KeyValue4;
            var bx = scanner.ADF.KeyValue5;
            var by = scanner.ADF.KeyValue6;
            var bz = scanner.ADF.PauseDuration;
            var ca = scanner.ADF.SimpleDataFormat;
        }

        private static void TestLicense(IMotorolaSnapiScanner scanner)
        {
            var bj = scanner.License.LicenseParseMode;
            var bk = scanner.License.LicenseParseBuffer;
        }

        private static void TestBeeper(IMotorolaSnapiScanner scanner)
        {
            var bh = scanner.Beeper.BeeperFrequency;
            var bi = scanner.Beeper.BeeperVolume;
        }

        private static void TestEvents(IMotorolaSnapiScanner scanner)
        {
            var be = scanner.Events.BootupEventEnabled;
            var bf = scanner.Events.DecodeEventEnabled;
            var bg = scanner.Events.ParamEventEnabled;
        }

        private static void TestImaging(IMotorolaSnapiScanner scanner)
        {
            var aq = scanner.Imaging.AimBrightness;
            var ar = scanner.Imaging.ContinuousSnapshotEnabled;
            var @as = scanner.Imaging.ContrastEnhancement;
            var at = scanner.Imaging.CropBottom;
            var au = scanner.Imaging.CropLeft;
            var av = scanner.Imaging.CropRight;
            var aw = scanner.Imaging.CropTop;
            var ax = scanner.Imaging.Exposure;
            var ay = scanner.Imaging.IlluminationBrightness;
            var az = scanner.Imaging.ImageEdgeSharpen;
            var ba = scanner.Imaging.ImageResolution;
            var bb = scanner.Imaging.ImageRotation;
            var bc = scanner.Imaging.JPEGFileSize;
            var bd = scanner.Imaging.SnapshotByMotionEnabled;
        }

        private static void TestDiscovery(IMotorolaSnapiScanner scanner)
        {
            var ad = scanner.Discovery.BluetoothAddress;
            var ae = scanner.Discovery.CombinedFirmwareVersion;
            var af = scanner.Discovery.ConfigurationFilename;
            var ag = scanner.Discovery.DateOfFirstProgramming;
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

        private static void TestOcr(IMotorolaSnapiScanner scanner)
        {
            var f = scanner.OCR.CheckDigitMod;
            var g = scanner.OCR.CheckDigitMultiplier;
            var h = scanner.OCR.CheckDigitValidation;
            var i = scanner.OCR.Despeckle;
            var j = scanner.OCR.EnableExternalFinder;
            var k = scanner.OCR.EnableFinder;
            var l = scanner.OCR.EnableIllumination;
            var m = scanner.OCR.EnableMicre13B;
            var n = scanner.OCR.EnableOcrA;
            var o = scanner.OCR.EnableOcrB;
            var p = scanner.OCR.EnableUSCurrency;
            var q = scanner.OCR.Lines;
            var r = scanner.OCR.LowPassFilter;
            var s = scanner.OCR.MaxCharacters;
            var t = scanner.OCR.MinCharacters;
            var u = scanner.OCR.OcrAVariant;
            var v = scanner.OCR.OcrBVariant;
            var w = scanner.OCR.Orientation;
            var x = scanner.OCR.QuietZone;
            var y = scanner.OCR.SecurityLevel;
            var z = scanner.OCR.Template;
            var aa = scanner.OCR.Thicken;
            var ab = scanner.OCR.ValidCharacters;
            var ac = scanner.OCR.WhiteLevel;
        }

        private static void TestStatus(IMotorolaSnapiScanner scanner)
        {
            var c = scanner.Status.Charging;
            var d = scanner.Status.InCradle;
            var e = scanner.Status.IsHandsfree;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}