using Motorola.Snapi;
using System;
using System.ComponentModel;
using System.Reflection;
using Motorola.Snapi.Constants;
using Motorola.Snapi.Constants.Enums;
using Motorola.Snapi.EventArguments;

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
                if (scanner.Info.UsbHostMode != HostMode.USB_SNAPI_Imaging)
                {
                    scanner.SetHostMode(HostMode.USB_SNAPI_Imaging);
                    while (_scannerAttached == false)
                    {
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                scanner.CaptureMode = CaptureMode.Barcode;
                scanner.Defaults.Restore();
                GetAttributes(scanner);
                //PerformCommands(scanner);
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;
            BarcodeScannerManager.Instance.ImageReceived += Instance_ImageReceived;

            Console.WriteLine("Ready to scan.. (Enter to quit)");
            Console.ReadLine();
        }

        private static void PerformCommands(IMotorolaSnapiScanner scanner)
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
            //TestCode128(scanner);
            //TestCode39(scanner);
            //TestCode11(scanner);
            //TestCode93(scanner);
            //TestI2Of5(scanner);
        }

        private static void TestI2Of5(IMotorolaSnapiScanner scanner)
        {
            var i2of5 = scanner.Attributes.Interleaved2Of5;
            var a = i2of5.I2Of5CheckDigitVerificationEnabled;
            var b = i2of5.I2Of5IsConvertedToEan13;
            var c = i2of5.Interleaved2Of5Enabled;
            var d = i2of5.LengthForI2Of5Length1;
            var e = i2of5.LengthForI2Of5Length2;
            var f = i2of5.TransmitI2Of5CheckDigit;
        }
        private static void TestCode11(IMotorolaSnapiScanner scanner)
        {
            var code11 = scanner.Attributes.Code11;
            var a = code11.Code11CheckDigitVerificationEnabled;
            var b = code11.Code11Enabled;
            var c = code11.LengthForCode11Length1;
            var d = code11.LengthForCode11Length2;
            var e = code11.TransmitCode11CheckDigit;
        }

        private static void TestCode93(IMotorolaSnapiScanner scanner)
        {
            var code93 = scanner.Attributes.Code93;
            var a = code93.Code93Enabled;
            var b = code93.LengthForCode93Length1;
            var c = code93.LengthForCode93Length2;
        }

        private static void TestCode39(IMotorolaSnapiScanner scanner)
        {
            var code39 = scanner.Attributes.Code39;
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

        private static void TestCode128(IMotorolaSnapiScanner scanner)
        {
            var code128 = scanner.Attributes.Code128;
            var a = code128.Code128Enabled = true;
            var b = code128.Code128Length1 = 0;
            var c = code128.Code128Length2 = 0;
            var d = code128.Code128RedundancyEnabled = false;
            var e = code128.Ean128EmulationEnabled = false;
            var f = code128.Isbt128Enabled = true;
            var g = code128.UccEan128Enabled = true;
        }

        private static void TestUpcEan(IMotorolaSnapiScanner scanner)
        {
            var cc = scanner.Attributes.UPC_EAN.BooklandEanEnabled = false;
            var cd = scanner.Attributes.UPC_EAN.ConvertUpcE1toA = false;
            var ce = scanner.Attributes.UPC_EAN.ConvertUpcEtoA = false;
            var cf = scanner.Attributes.UPC_EAN.Ean13Jan13Enabled = false;
            var cg = scanner.Attributes.UPC_EAN.Ean8Jan8Enabled = false;
            var ch = scanner.Attributes.UPC_EAN.Ean8Jan8Extend = false;
            var ci = scanner.Attributes.UPC_EAN.Supp2Enabled = false;
            var cj = scanner.Attributes.UPC_EAN.Supp5Enabled = false;
            var ck = scanner.Attributes.UPC_EAN.TransmitCodeId = TransmitCodeId.None;
            var cl = scanner.Attributes.UPC_EAN.TransmitUpcACheckDigit = false;
            var cm = scanner.Attributes.UPC_EAN.TransmitUpcE1CheckDigit = false;
            var cn = scanner.Attributes.UPC_EAN.TransmitUpcECheckDigit = false;
            var co = scanner.Attributes.UPC_EAN.UccCouponExtendedCodeEnabled = false;
            var cp = scanner.Attributes.UPC_EAN.UpcAEnabled = false;
            var cq = scanner.Attributes.UPC_EAN.UpcAPreamble = UpcPreamble.NoPreamble;
            var cr = scanner.Attributes.UPC_EAN.UpcE1Enabled = false;
            var cs = scanner.Attributes.UPC_EAN.UpcE1Preamble = UpcPreamble.NoPreamble;
            var ct = scanner.Attributes.UPC_EAN.UpcEEnabled = false;
            var cu = scanner.Attributes.UPC_EAN.UpcEPreamble = UpcPreamble.NoPreamble;
            var cv = scanner.Attributes.UPC_EAN.UpcEanJanSupplementalMode = SupplementalMode.IgnoreSupplemental;
            var cw = scanner.Attributes.UPC_EAN.UpcEanJanSupplementalRedundancy = 2;
        }

        private static void TestSynapse(IMotorolaSnapiScanner scanner) { var cb = scanner.Attributes.Synapse.Value; }

        private static void TestADF(IMotorolaSnapiScanner scanner)
        {
            var bl = scanner.Attributes.ADF.KeyDelay;
            var bm = scanner.Attributes.ADF.ADFRules;
            var bn = scanner.Attributes.ADF.KeyCategory1;
            var bo = scanner.Attributes.ADF.KeyCategory2;
            var bp = scanner.Attributes.ADF.KeyCategory3;
            var bq = scanner.Attributes.ADF.KeyCategory4;
            var br = scanner.Attributes.ADF.KeyCategory5;
            var bs = scanner.Attributes.ADF.KeyCategory6;
            var bt = scanner.Attributes.ADF.KeyValue1;
            var bu = scanner.Attributes.ADF.KeyValue2;
            var bv = scanner.Attributes.ADF.KeyValue3;
            var bw = scanner.Attributes.ADF.KeyValue4;
            var bx = scanner.Attributes.ADF.KeyValue5;
            var by = scanner.Attributes.ADF.KeyValue6;
            var bz = scanner.Attributes.ADF.PauseDuration;
            var ca = scanner.Attributes.ADF.SimpleDataFormat;
        }

        private static void TestLicense(IMotorolaSnapiScanner scanner)
        {
            var bj = scanner.Attributes.License.LicenseParseMode;
            var bk = scanner.Attributes.License.LicenseParseBuffer;
        }

        private static void TestBeeper(IMotorolaSnapiScanner scanner)
        {
            var bh = scanner.Attributes.Beeper.BeeperFrequency;
            var bi = scanner.Attributes.Beeper.BeeperVolume;
        }

        private static void TestEvents(IMotorolaSnapiScanner scanner)
        {
            var be = scanner.Attributes.Events.BootupEventEnabled;
            var bf = scanner.Attributes.Events.DecodeEventEnabled;
            var bg = scanner.Attributes.Events.ParamEventEnabled;
        }

        private static void TestImaging(IMotorolaSnapiScanner scanner)
        {
            var aq = scanner.Attributes.Imaging.AimBrightness;
            var ar = scanner.Attributes.Imaging.ContinuousSnapshotEnabled;
            var @as = scanner.Attributes.Imaging.ContrastEnhancement;
            var at = scanner.Attributes.Imaging.CropBottom;
            var au = scanner.Attributes.Imaging.CropLeft;
            var av = scanner.Attributes.Imaging.CropRight;
            var aw = scanner.Attributes.Imaging.CropTop;
            var ax = scanner.Attributes.Imaging.Exposure;
            var ay = scanner.Attributes.Imaging.IlluminationBrightness;
            var az = scanner.Attributes.Imaging.ImageEdgeSharpen;
            var ba = scanner.Attributes.Imaging.ImageResolution;
            var bb = scanner.Attributes.Imaging.ImageRotation;
            var bc = scanner.Attributes.Imaging.JPEGFileSize;
            var bd = scanner.Attributes.Imaging.SnapshotByMotionEnabled;
        }

        private static void TestDiscovery(IMotorolaSnapiScanner scanner)
        {
            var ad = scanner.Attributes.Discovery.BluetoothAddress;
            var ae = scanner.Attributes.Discovery.CombinedFirmwareVersion;
            var af = scanner.Attributes.Discovery.ConfigurationFilename;
            var ag = scanner.Attributes.Discovery.DateOfFirstProgramming;
            var ah = scanner.Attributes.Discovery.DateOfManufacture;
            var ai = scanner.Attributes.Discovery.DeviceClass;
            var aj = scanner.Attributes.Discovery.ImagekitVersion;
            var ak = scanner.Attributes.Discovery.LastServiceDate;
            var al = scanner.Attributes.Discovery.ModelNumber;
            var am = scanner.Attributes.Discovery.RsmVersion;
            var an = scanner.Attributes.Discovery.ScankitVersion;
            var ao = scanner.Attributes.Discovery.ScannerFirmwareVersion;
            var ap = scanner.Attributes.Discovery.SerialNumber;
        }

        private static void TestOcr(IMotorolaSnapiScanner scanner)
        {
            var f = scanner.Attributes.OCR.CheckDigitMod;
            var g = scanner.Attributes.OCR.CheckDigitMultiplier;
            var h = scanner.Attributes.OCR.CheckDigitValidation;
            var i = scanner.Attributes.OCR.Despeckle;
            var j = scanner.Attributes.OCR.EnableExternalFinder;
            var k = scanner.Attributes.OCR.EnableFinder;
            var l = scanner.Attributes.OCR.EnableIllumination;
            var m = scanner.Attributes.OCR.EnableMicre13B;
            var n = scanner.Attributes.OCR.EnableOcrA;
            var o = scanner.Attributes.OCR.EnableOcrB;
            var p = scanner.Attributes.OCR.EnableUSCurrency;
            var q = scanner.Attributes.OCR.Lines;
            var r = scanner.Attributes.OCR.LowPassFilter;
            var s = scanner.Attributes.OCR.MaxCharacters;
            var t = scanner.Attributes.OCR.MinCharacters;
            var u = scanner.Attributes.OCR.OcrAVariant;
            var v = scanner.Attributes.OCR.OcrBVariant;
            var w = scanner.Attributes.OCR.Orientation;
            var x = scanner.Attributes.OCR.QuietZone;
            var y = scanner.Attributes.OCR.SecurityLevel;
            var z = scanner.Attributes.OCR.Template;
            var aa = scanner.Attributes.OCR.Thicken;
            var ab = scanner.Attributes.OCR.ValidCharacters;
            var ac = scanner.Attributes.OCR.WhiteLevel;
        }

        private static void TestStatus(IMotorolaSnapiScanner scanner)
        {
            var c = scanner.Attributes.Status.Charging;
            var d = scanner.Attributes.Status.InCradle;
            var e = scanner.Attributes.Status.IsHandsfree;
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