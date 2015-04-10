using CoreScanner;
using Motorola.Snapi.Commands;
using Motorola.Snapi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Motorola.Snapi
{
    public class BarcodeScannerManager : IDisposable
    {
        public const string DriverVersion = "1.0";

        public static readonly BarcodeScannerManager Instance = new BarcodeScannerManager();
        private static readonly object _accessLock = new object();
        private readonly Keyboard _keyboard;
        private ICoreScanner _scannerDriver;

        private BarcodeScannerManager()
        {
            if (_scannerDriver == null)
                _scannerDriver = new CCoreScanner();

            _keyboard = new Keyboard(_scannerDriver);
        }

        public event EventHandler<BarcodeScanEventArgs> DataReceived;

        public Keyboard Keyboard
        {
            get { return _keyboard; }
        }

        //public static byte[] ParseHex(string hex)
        //{
        //    int offset = hex.StartsWith("0x") ? 2 : 0;
        //    if ((hex.Length % 2) != 0)
        //    {
        //        throw new ArgumentException("Invalid length: " + hex.Length);
        //    }
        //    byte[] ret = new byte[(hex.Length - offset) / 2];

        //    for (int i = 0; i < ret.Length; i++)
        //    {
        //        ret[i] = (byte)((ParseNybble(hex[offset]) << 4) |
        //                        ParseNybble(hex[offset + 1]));
        //        offset += 2;
        //    }
        //    return ret;
        //}

        public void Attach()
        {
            //_scannerDriver.BarcodeEvent += OnBarcodeEvent;

            // Just register for a single event - barcode events
            string inXml = "<inArgs><cmdArgs><arg-int>1</arg-int><arg-int>1</arg-int></cmdArgs></inArgs>";
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.RegisterForEvents, ref inXml, out outXml, out status);
        }

        public void Close()
        {
            int status;
            //_scannerDriver.BarcodeEvent -= OnBarcodeEvent;
            _scannerDriver.Close(0, out status);
        }

        public List<IMotorolaSnapiScanner> GetDevices()
        {
            List<IMotorolaSnapiScanner> retval = new List<IMotorolaSnapiScanner>();

            if (Open())
            {

                // Lets list down all the scanners connected to the host
                short numberOfScanners; // Number of scanners expect to be used
                int[] connectedScannerIDList = new int[32]; // Random number - more than expected

                // List of scanner IDs to be returned
                string outXml; //Scanner details output
                int status; // Extended API return code
                _scannerDriver.GetScanners(out numberOfScanners, connectedScannerIDList, out outXml, out status);

                XDocument xdoc = XDocument.Parse(outXml);
                List<XElement> scanners = xdoc.Descendants("scanner").ToList();

                scanners.ForEach(s => retval.Add(new BarcodeScanner(_scannerDriver, s)));
            }

            return retval;
        }

        public bool Open()
        {
            //Call Open API
            int status; // Extended API return code
            _scannerDriver.Open(0 /* const: always 0 */, new short[] { (short)ScannerType.All }/* array of scanner types */, 1 /* size of prev parameter */, out status);

            return (((Status)status == Status.Success) || ((Status)status == Status.AlreadyOpened));
        }

        private void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            if (DataReceived != null)
            {
                XDocument xdoc = XDocument.Parse(pscanData);
                DataReceived(this, new BarcodeScanEventArgs(ParseScannerId(xdoc), ParseData(xdoc)));
            }
        }

        /// <summary>
        /// Parses out the hex array from the XElement and converts each to a char and appends to string
        /// </summary>
        /// <param name="xdoc"></param>
        /// <returns></returns>
        private string ParseData(XDocument xdoc)
        {
            try
            {
                // rawdata contains the headers that are stripped from datalabel
                XElement datalabelData = xdoc.Descendants("datalabel").First();
                string[] array = datalabelData.Value.Trim().Split(' ');
                StringBuilder retval = new StringBuilder(array.Length);
                for (int i = 0; i < array.Length; i++)
                { retval.Append((char)Convert.ToInt32(array[i], 16)); }
                return retval.ToString();
            }
            catch
            { return String.Empty; }
        }

        private UInt32 ParseScannerId(XDocument xdoc)
        {
            try
            { return UInt32.Parse(xdoc.Descendants("scannerID").Single().Value); }
            catch
            { return 0; }
        }

        #region IDisposable

        // Flag: Has Dispose already been called?
        private bool disposed = false;

        ~BarcodeScannerManager()
        { Dispose(false); }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                { }
                // Free any unmanaged objects here.
                //
                Close();
                _scannerDriver = null;
                disposed = true;
            }
        }

        #endregion IDisposable
    }
}