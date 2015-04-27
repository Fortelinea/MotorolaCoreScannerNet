using Motorola.Snapi;
using Motorola.Snapi.Constants;
using Motorola.Snapi.Constants.Enums;
using Motorola.Snapi.EventArguments;
using System;
using System.ComponentModel;
using System.Reflection;

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

            BarcodeScannerManager.Instance.RegisterForEvents(EventType.Barcode, EventType.Pnp, EventType.Image, EventType.Other, EventType.Rmd);

            var b = BarcodeScannerManager.Instance.RegisteredEvents;

            BarcodeScannerManager.Instance.Keyboard.EnableEmulation = false;

            BarcodeScannerManager.Instance.ScannerAttached += Instance_ScannerAttached;

            var a = BarcodeScannerManager.Instance.DriverVersion;

            foreach (var scanner in BarcodeScannerManager.Instance.GetDevices())
            {
                scanner.SetHostMode(HostMode.USB_SNAPI_Imaging);
                if (scanner.Info.UsbHostMode != HostMode.USB_SNAPI_Imaging)
                {
                    scanner.SetHostMode(HostMode.USB_SNAPI_Imaging);
                    while (_scannerAttached == false)
                    {
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                //scanner.Defaults.Restore();
                //scanner.CaptureMode = CaptureMode.Barcode;
                GetAttributes(scanner);
                //PerformCommands(scanner);
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;
            BarcodeScannerManager.Instance.ImageReceived += Instance_ImageReceived;

            Console.WriteLine("Ready to scan.. (Enter to quit)");
            Console.ReadLine();
        }

        private static void PerformCommands(IMotorolaBarcodeScanner scanner)
        {
            scanner.Actions.ToggleLed(LedMode.GreenOn);
            scanner.Actions.ToggleLed(LedMode.GreenOff);
            scanner.Actions.ToggleLed(LedMode.YellowOn);
            scanner.Actions.ToggleLed(LedMode.YellowOff);
            scanner.Actions.ToggleLed(LedMode.RedOn);
            scanner.Actions.ToggleLed(LedMode.RedOff);
            scanner.Actions.SoundBeeper(BeepPattern.FiveHighShort);
            scanner.Reboot();
        }

        private static void GetAttributes(IMotorolaBarcodeScanner scanner)
        {
            //TestStatus(scanner);
            TestOcr(scanner);
            //TestDiscovery(scanner);
            //TestImaging(scanner);
            //TestEvents(scanner);
            //TestBeeper(scanner);
            //TestLicense(scanner);
            //TestADF(scanner);
            //TestSynapse(scanner);
            //TestUpcEan(scanner);
            //TestCode128(scanner);
            //TestCode39(scanner);
            //TestCode11(scanner);
            //TestCode93(scanner);
            TestI2Of5(scanner);
            //TestD2Of5(scanner);
            //TestSecurity(scanner);
        }

        private static void TestSecurity(IMotorolaBarcodeScanner scanner)
        {
            var security = scanner.SymbologySecurity;
            var a = security.BidirectionalRedundancyEnabled;
            var b = security.SecurityLevel;
            var c = security.RedundancyLevel;
        }

        private static void TestD2Of5(IMotorolaBarcodeScanner scanner)
        {
            var d2of5 = scanner.Discrete2Of5;
            var a = d2of5.Discrete2Of5Enabled;
            var b = d2of5.LengthForD2Of5Length1;
            var c = d2of5.LengthForD2Of5Length2;
        }

        private static void TestI2Of5(IMotorolaBarcodeScanner scanner)
        {
            var i2of5 = scanner.Interleaved2Of5;
            var a = i2of5.I2Of5CheckDigitVerification;// = I2Of5CheckDigit.Off;
            var b = i2of5.I2Of5IsConvertedToEan13;// = false;
            var c = i2of5.Interleaved2Of5Enabled;// = true;
            var d = i2of5.LengthForI2Of5Length1;// = 6;
            var e = i2of5.LengthForI2Of5Length2;// = 0;
            var f = i2of5.TransmitI2Of5CheckDigit;
        }

        private static void TestCode11(IMotorolaBarcodeScanner scanner)
        {
            var code11 = scanner.Code11;
            var a = code11.Code11CheckDigitVerification;
            var b = code11.Code11Enabled;
            var c = code11.LengthForCode11Length1;
            var d = code11.LengthForCode11Length2;
            var e = code11.TransmitCode11CheckDigit;
        }

        private static void TestCode93(IMotorolaBarcodeScanner scanner)
        {
            var code93 = scanner.Code93;
            var a = code93.Code93Enabled;
            var b = code93.LengthForCode93Length1;
            var c = code93.LengthForCode93Length2;
        }

        private static void TestCode39(IMotorolaBarcodeScanner scanner)
        {
            var code39 = scanner.Code39;
            var a = code39.BufferCode39Enabled;
            var b = code39.Code32PrefixAdded;
            var c = code39.Code39CheckDigitVerificationEnabled;
            var d = code39.Code39Enabled;
            var e = code39.Code39FullAsciiConversionEnabled;
            var f = code39.Code39IsConvertedToCode32;
            var g = code39.LengthForCode39Length1;
            var h = code39.LengthForCode39Length2;
            var i = code39.TransmitCode39CheckDigit;
            var j = code39.TriopticCode39Enabled;
        }

        private static void TestCode128(IMotorolaBarcodeScanner scanner)
        {
            var code128 = scanner.Code128;
            var a = code128.Code128Enabled = true;
            var b = code128.Code128Length1 = 0;
            var c = code128.Code128Length2 = 0;
            var d = code128.Code128RedundancyEnabled = false;
            var e = code128.Ean128EmulationEnabled = false;
            var f = code128.Isbt128Enabled = true;
            var g = code128.UccEan128Enabled = true;
        }

        private static void TestUpcEan(IMotorolaBarcodeScanner scanner)
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

        private static void TestSynapse(IMotorolaBarcodeScanner scanner)
        {
            var cb = scanner.Synapse.Value;
        }

        private static void TestADF(IMotorolaBarcodeScanner scanner)
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

        private static void TestLicense(IMotorolaBarcodeScanner scanner)
        {
            var bj = scanner.License.LicenseParseMode;
            var bk = scanner.License.LicenseParseBuffer;
        }

        private static void TestBeeper(IMotorolaBarcodeScanner scanner)
        {
            var bh = scanner.Beeper.BeeperFrequency;
            var bi = scanner.Beeper.BeeperVolume = BeeperVolume.Low;
        }

        private static void TestEvents(IMotorolaBarcodeScanner scanner)
        {
            var be = scanner.Events.BootupEventEnabled;
            var bf = scanner.Events.DecodeEventEnabled;
            var bg = scanner.Events.ParamEventEnabled;
        }

        private static void TestImaging(IMotorolaBarcodeScanner scanner)
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

        private static void TestDiscovery(IMotorolaBarcodeScanner scanner)
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

        private static void TestOcr(IMotorolaBarcodeScanner scanner)
        {
            var f = scanner.OCR.CheckDigitMod;
            var g = scanner.OCR.CheckDigitMultiplier;
            var h = scanner.OCR.CheckDigitValidation;
            var i = scanner.OCR.Despeckle;// = 50;
            var j = scanner.OCR.EnableExternalFinder;
            var k = scanner.OCR.EnableFinder;
            var l = scanner.OCR.EnableIllumination;// = false;
            var m = scanner.OCR.EnableMicre13B;
            var n = scanner.OCR.EnableOcrA;// = false;
            var o = scanner.OCR.EnableOcrB = true;
            var p = scanner.OCR.EnableUSCurrency;
            var q = scanner.OCR.Lines = 1;
            var r = scanner.OCR.LowPassFilter;// = 0;
            var s = scanner.OCR.MaxCharacters = 7;
            var t = scanner.OCR.MinCharacters = 7;
            var u = scanner.OCR.OcrAVariant;
            var v = scanner.OCR.OcrBVariant;
            var w = scanner.OCR.Orientation;// = BarcodeOrientation.Clockwise270;
            var x = scanner.OCR.QuietZone;// = 99;
            var y = scanner.OCR.SecurityLevel;// = 50;
            var z = scanner.OCR.Template;// = "3333+ +333D";
            var aa = scanner.OCR.Thicken;// = 8;
            var ab = scanner.OCR.ValidCharacters;// = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var ac = scanner.OCR.WhiteLevel;// = 50;
        }

        private static void TestStatus(IMotorolaBarcodeScanner scanner)
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