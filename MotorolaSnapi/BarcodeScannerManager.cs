using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CoreScanner;
using Motorola.Snapi.Commands;
using Motorola.Snapi.Constants.Enums;
using Motorola.Snapi.EventArguments;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace Motorola.Snapi
{
    public class BarcodeScannerManager : IDisposable
    {
        public static readonly BarcodeScannerManager Instance = new BarcodeScannerManager();
        private readonly Keyboard _keyboard;
        private CCoreScanner _scannerDriver;

        private BarcodeScannerManager()
        {
            if (_scannerDriver == null)
                _scannerDriver = new CCoreScanner();

            _keyboard = new Keyboard(_scannerDriver);
        }

        #region Commands
        public Keyboard Keyboard
        {
            get { return _keyboard; }
        }

        public void Close()
        {
            int status;
            UnRegisterForEvents(EventType.Barcode, EventType.Pnp, EventType.Image, EventType.Other, EventType.Rmd, EventType.Video);
            _scannerDriver.Close(0, out status);
        }

        /// <summary>
        /// Find all connected devices
        /// </summary>
        /// <returns>A list of IMotorolaSnapiScanner</returns>
        public List<IMotorolaSnapiScanner> GetDevices()
        {
            List<IMotorolaSnapiScanner> retval = new List<IMotorolaSnapiScanner>();

            if (Open())
            {

                // Lets list down all the scanners connected to the host
                short numberOfScanners; // Number of scanners expect to be used
                var connectedScannerIDList = new int[32]; // Random number - more than expected

                // List of scanner IDs to be returned
                string outXml; //Scanner details output
                int status; // Extended API return code
                _scannerDriver.GetScanners(out numberOfScanners, connectedScannerIDList, out outXml, out status);
                XDocument xdoc = XDocument.Parse(outXml);
                List<XElement> scanners = xdoc.Descendants("scanner").ToList();

                foreach (var s in scanners)
                {
                    var scanner = new BarcodeScanner(_scannerDriver, s);
                    retval.Add(scanner);                   
                }
            }

            return retval;
        }

        /// <summary>
        /// Opens an application instance from the user application or user library.
        /// </summary>
        /// <returns>True if opened successfully</returns>
        public bool Open()
        {
            //Call Open API
            int status; // Extended API return code
            _scannerDriver.Open(0 /* const: always 0 */, new short[] { (short)ScannerType.All }/* array of scanner types */, 1 /* size of prev parameter */, out status);

            return (((StatusCode)status == StatusCode.Success) || ((StatusCode)status == StatusCode.AlreadyOpened));
        }

        /// <summary>
        /// Version number of the CoreScanner driver.
        /// </summary>
        public string DriverVersion
        {
            get
            {
                string inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.GetVersion, ref inXml, out outXml, out status);

                XDocument xdoc = XDocument.Parse(outXml);
                XElement keyEnumState = xdoc.Descendants("arg-string").First();
                return keyEnumState.Value;
            }
        }
        /// <summary>
        /// Registers the API for the given event types.
        /// </summary>
        /// <param name="events">Events to register for.</param>
        public void RegisterForEvents(params EventType[] events)
        {
            if (_registeredEvents == null)
            {
                _registeredEvents = new List<EventType>();
            }
            var template = @"<inArgs><cmdArgs><arg-int>{0}</arg-int><arg-int>{1}</arg-int></cmdArgs></inArgs>";

            var count = 0;
            var arg = "";
            foreach (var eventType in events)
            {
                if (_registeredEvents.Contains(eventType))
                    continue;
                _registeredEvents.Add(eventType);
                arg += (int)eventType;
                arg += ",";
                count++;

                switch (eventType)
                {
                    case EventType.Barcode:
                        {
                            _scannerDriver.BarcodeEvent += OnBarcodeEvent;
                            break;
                        }
                    case EventType.Image:
                        {
                            _scannerDriver.ImageEvent += OnImageEvent;
                            break;
                        }
                    case EventType.Other:
                        {
                            _scannerDriver.IOEvent += OnIOEvent;
                            _scannerDriver.CommandResponseEvent += OnCommandResponceEvent;
                            _scannerDriver.ScannerNotificationEvent += OnScannerNotificationEvent;
                            break;
                        }
                    case EventType.Pnp:
                        {
                            _scannerDriver.PNPEvent += OnPnpEvent;
                            break;
                        }
                    case EventType.Rmd:
                        {
                            _scannerDriver.ScanRMDEvent += OnScanRmdEvent;
                            break;
                        }
                    case EventType.Video:
                        {
                            _scannerDriver.VideoEvent += OnVideoEvent;
                            break;
                        }
                }
            }
            if (!arg.Equals(""))
            {
                arg = arg.Substring(0, arg.Length - 1);
                string inXml = string.Format(template, count, arg);
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.RegisterForEvents, ref inXml, out outXml, out status);
            }
        }

        /// <summary>
        /// Unregisters the API for the given event types.
        /// </summary>
        /// <param name="events">Events to unregister from.</param>
        public void UnRegisterForEvents(params EventType[] events)
        {
            if (_registeredEvents != null)
            {
                var template = @"<inArgs><cmdArgs><arg-int>{0}</arg-int><arg-int>{1}</arg-int></cmdArgs></inArgs>";

                var count = 0;
                var arg = "";
                foreach (var eventType in events)
                {
                    if (_registeredEvents.Contains(eventType))
                    {
                        _registeredEvents.Remove(eventType);
                        arg += (int)eventType;
                        arg += ",";
                        count++;

                        switch (eventType)
                        {
                            case EventType.Barcode:
                                {
                                    _scannerDriver.BarcodeEvent -= OnBarcodeEvent;
                                    break;
                                }
                            case EventType.Image:
                                {
                                    _scannerDriver.ImageEvent -= OnImageEvent;
                                    break;
                                }
                            case EventType.Other:
                                {
                                    _scannerDriver.IOEvent -= OnIOEvent;
                                    _scannerDriver.CommandResponseEvent -= OnCommandResponceEvent;
                                    _scannerDriver.ScannerNotificationEvent -= OnScannerNotificationEvent;
                                    break;
                                }
                            case EventType.Pnp:
                                {
                                    _scannerDriver.PNPEvent -= OnPnpEvent;
                                    break;
                                }
                            case EventType.Rmd:
                                {
                                    _scannerDriver.ScanRMDEvent -= OnScanRmdEvent;
                                    break;
                                }
                            case EventType.Video:
                                {
                                    _scannerDriver.VideoEvent -= OnVideoEvent;
                                    break;
                                }
                        }
                    }
                }
                if (!arg.Equals(""))
                {
                    arg = arg.Substring(0, arg.Length - 1);
                    string inXml = string.Format(template, count, arg);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.UnregisterForEvents, ref inXml, out outXml, out status);
                }
            }
        }

        #endregion

        #region Parsers
        /// <summary>
        /// Parses out the hex array from the XElement and converts each to a char and appends to string
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Data string</returns>
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

        /// <summary>
        /// Gets the scanner ID from xml
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Scanner ID</returns>
        private uint ParseScannerId(XDocument xdoc)
        {
            try
            {
                return uint.Parse(xdoc.Descendants("scannerID").Single().Value);
            }
            catch
            { return 0; }
        }

        /// <summary>
        /// Gets the status from xml
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Status code</returns>
        private int ParseStatus(XDocument xdoc)
        {
            try
            {
                return int.Parse(xdoc.Descendants("status").Single().Value);
            }
            catch
            { return 0; }
        }

        /// <summary>
        /// Gets the total number of records from xml
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Number of records in firmware file.</returns>
        private int ParseTotalRecords(XDocument xdoc)
        {
            try
            {
                return int.Parse(xdoc.Descendants("maxcount").Single().Value);
            }
            catch
            { return 0; }
        }

        /// <summary>
        /// Gets rawdata from barcode xml.
        /// </summary>
        /// <param name="xdoc">XDocument generated from barcode event.</param>
        /// <returns>byte[] containing the rawdata</returns>
        private byte[] ParseRawData(XDocument xdoc)
        {
            return ValueConverters.HexStringToByteArray(xdoc.Descendants("rawdata")
                                                  .Single()
                                                  .Value);
        }

        /// <summary>
        /// Gets the current software component number from xml
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>SOftware component number</returns>
        private int ParseComponent(XDocument xdoc)
        {
            return int.Parse(xdoc.Descendants("software_component").Single().Value);
        }
        /// <summary>
        /// Gets barcode type from barcode xml.
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Barcode type</returns>
        private BarcodeType ParseBarcodeType(XDocument xdoc)
        {
            try
            {
                return (BarcodeType)ushort.Parse(xdoc.Descendants("datatype").Single().Value);
            }
            catch
            { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xdoc">XDocument generated from barcode event.</param>
        /// <returns></returns>
        private int ParseProgress(XDocument xdoc)
        {
            return int.Parse(xdoc.Descendants("progress").Single().Value);
        }
        #endregion

        #region Events
        private List<EventType> _registeredEvents;

        public IEnumerable<EventType> RegisteredEvents
        {
            get { return _registeredEvents; }
        }
        /// <summary>
        /// Invoked when bar code data is received by a scanner.
        /// </summary>
        public event EventHandler<BarcodeScanEventArgs> DataReceived;
        /// <summary>
        /// Invoked when a scanner is attached by plugging in the usb or after a reboot.
        /// </summary>
        public event EventHandler<PnpEventArgs> ScannerAttached;
        /// <summary>
        /// Invoked when a scanner is detached.
        /// </summary>
        public event EventHandler<PnpEventArgs> ScannerDetached;
        /// <summary>
        /// Invoked when a scanner captures an image.
        /// </summary>
        public event EventHandler<ImageEventArgs> ImageReceived;
        /// <summary>
        /// Invoked when a scanner captures video.
        /// </summary>
        public event EventHandler<VideoEventArgs> VideoReceived;
        /// <summary>
        /// Invoked when a firmware update session has begun.
        /// </summary>
        public event EventHandler<FlashStartEventArgs> FlashSessionStarted;
        /// <summary>
        /// Invoked when a firmware download has begun.
        /// </summary>
        public event EventHandler<DownloadEventArgs> DownloadStarted;
        /// <summary>
        /// Invoked when a record finishes downloading to update on the progress.
        /// </summary>
        public event EventHandler<DownloadEventArgs> BlockFinished;
        /// <summary>
        /// Invoked when a component download ends
        /// </summary>
        public event EventHandler<DownloadEventArgs> DownloadEnded;
        /// <summary>
        /// Invoked when a firmware download session ends.
        /// </summary>
        public event EventHandler<FirmwareEventArgs> FlashSessionEnded;
        /// <summary>
        /// Invoked when a status message or error message is received relating to firmware update.
        /// </summary>
        public event EventHandler<FirmwareEventArgs> FirmwareStatusOrErrorReceived;
        /// <summary>
        /// Invoked when a scanner's operation mode is changed to decode barcode mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> DecodeModeEnabled;
        /// <summary>
        /// Invoked when a scanner's operation mode is changed to snapshot mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> SnapshotModeEnabled;
        /// <summary>
        /// Invoked when a scanner's operation mode is changed to video mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> VideoModeEnabled;
        /// <summary>
        /// Invoked when a responce to a command is received.
        /// TODO Figure out what to do with this. Should probably be handled inside the wrapper or not used.
        /// </summary>
        internal event EventHandler<CommandResponceEventArgs> ResponceReceived;
        /// <summary>
        /// Invoked when another application attempts to access a scanner that has been exclusively claimed by this application.
        /// </summary>
        public event EventHandler<IoEventArgs> ApplicationBlocked;

        /// <summary>
        /// Handles BardcodeEvent and invokes DataReceived.
        /// </summary>
        /// <param name="eventType">1 - Triggered when a decode is successful.</param>
        /// <param name="pscanData">Bar code string that contains information about the scanner that triggered the bar code event 
        /// including data type, data label and raw data of the scanned bar code.</param>
        private void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            if (DataReceived != null)
            {
                XDocument xdoc = XDocument.Parse(pscanData);
                DataReceived(this, new BarcodeScanEventArgs(ParseScannerId(xdoc), ParseBarcodeType(xdoc), ParseData(xdoc), ParseRawData(xdoc)));
            }
        }

        /// <summary>
        /// Handles PNPEvent and invokes ScannerAttached or ScannerDetached.
        /// </summary>
        /// <param name="eventtype">1 - Scanner attached.
        /// 2 - Scanner detached.</param>
        /// <param name="ppnpdata">Xml output.</param>
        private void OnPnpEvent(short eventtype, ref string ppnpdata)
        {
            XDocument xdoc = XDocument.Parse(ppnpdata);
            var scannerId = ParseScannerId(xdoc);

            if (ScannerAttached != null && eventtype == 1)
            {
                ScannerAttached(this, new PnpEventArgs(scannerId));
            }
            else if (ScannerDetached != null && eventtype == 2)
            {
                ScannerDetached(this, new PnpEventArgs(scannerId));
            }
        }

        /// <summary>
        /// Handles ImageEvent and invokes ImageReceived.
        /// </summary>
        /// <param name="eventtype"></param>
        /// <param name="size"></param>
        /// <param name="imageformat"></param>
        /// <param name="sfimageData"></param>
        /// <param name="pscannerdata"></param>
        private void OnImageEvent(short eventtype, int size, short imageformat, ref object sfimageData, ref string pscannerdata)
        {
            if (ImageEvent.CaptureCompleted == (ImageEvent)eventtype)
            {
                Array arr = (Array)sfimageData;
                long len = arr.LongLength;
                byte[] byImage = new byte[len];
                arr.CopyTo(byImage, 0);
                var xdoc = XDocument.Parse(pscannerdata);
                ImageFormat format = null;
                using (var ms = new MemoryStream(byImage))
                {
                    var image = Image.FromStream(ms);
                    if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Bmp)
                    {
                        format = ImageFormat.Bmp;
                    }
                    else if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Jpeg)
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Tiff)
                    {
                        format = ImageFormat.Tiff;
                    }
                    if (ImageReceived != null) ImageReceived(this, new ImageEventArgs(ParseScannerId(xdoc), format, image));
                }
            }
            else 
            {
                //TODO Implement what to do when capture fails.
            }
        }

        /// <summary>
        /// Handles VideoEvent and invokes VideoReceived.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="size"></param>
        /// <param name="sfvideoData"></param>
        /// <param name="pScannerData"></param>
        private void OnVideoEvent(short eventType, int size, ref object sfvideoData, ref string pScannerData)
        {
            //TODO Implement OnVideoEvent.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles ScanRMDEvent. Invokes FlashSessionStarted, DownloadStarted, BlockFinished, DownloadEnded, FlashSessionEnded, or FirmwareStatusOrErrorReceived.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="prmdData"></param>
        private void OnScanRmdEvent(short eventType, ref string prmdData)
        {
            XDocument xdoc = XDocument.Parse(prmdData);
            var status = (StatusCode)ParseStatus(xdoc);
            uint scannerId = ParseScannerId(xdoc);
            switch ((RmdEventType)eventType)
            {
                case RmdEventType.SessionStarted:
                {
                    if (FlashSessionStarted != null) FlashSessionStarted(this, new FlashStartEventArgs(scannerId, status, ParseTotalRecords(xdoc)));
                    break;
                }
                case RmdEventType.DownloadStarted:
                {
                    if(DownloadStarted != null) DownloadStarted(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc)));
                    break;
                }
                case RmdEventType.BlockFinished:
                {
                    if(BlockFinished != null) BlockFinished(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc), ParseProgress(xdoc)));
                    break;
                }
                case RmdEventType.DownloadEnded:
                {
                    if(DownloadEnded != null) DownloadEnded(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc)));
                    break;
                }
                case RmdEventType.SessionEnded:
                {
                    if(FlashSessionEnded != null) FlashSessionEnded(this, new FirmwareEventArgs(scannerId, status));
                    break;
                }
                case RmdEventType.ErrorOrStatus:
                {
                    if(FirmwareStatusOrErrorReceived != null) FirmwareStatusOrErrorReceived(this, new FirmwareEventArgs(scannerId, status));
                    break;
                }
            }
        }


        /// <summary>
        /// Handles ScannerNotificationEvent. Invokes DecodeModeEnabled, SnapshotModeEnabled, or VideoModeEnabled.
        /// </summary>
        /// <param name="notificationType"></param>
        /// <param name="pScannerData"></param>
        private void OnScannerNotificationEvent(short notificationType, ref string pScannerData)
        {
            XDocument xdoc = XDocument.Parse(pScannerData);
            var scannerId = ParseScannerId(xdoc);
            switch ((NotificationType)notificationType)
            {
                case NotificationType.DecodeMode:
                {
                    if (DecodeModeEnabled != null) DecodeModeEnabled(this, new ScannerEventArgs(scannerId));
                    break;
                }
                case NotificationType.SnapshotMode:
                {
                    if (SnapshotModeEnabled != null) SnapshotModeEnabled(this, new ScannerEventArgs(scannerId));
                    break;
                }
                case NotificationType.VideoMode:
                {
                    if (VideoModeEnabled != null) VideoModeEnabled(this, new ScannerEventArgs(scannerId));
                    break;
                }
            }
        }

        /// <summary>
        /// Handles CommandResponceEvent. Invokes ResponceReceived
        /// </summary>
        /// <param name="status"></param>
        /// <param name="prspData"></param>
        private void OnCommandResponceEvent(short status, ref string prspData)
        {
            XDocument outXml = XDocument.Parse(prspData);
            if (ResponceReceived != null) ResponceReceived(this, new CommandResponceEventArgs(outXml));
        }

        /// <summary>
        /// Handles IOEvents. Invokes ApplicationBlocked
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        private void OnIOEvent(short type, byte data)
        {
            if(ApplicationBlocked != null) ApplicationBlocked(this, new IoEventArgs(type, data));
        }
        #endregion

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