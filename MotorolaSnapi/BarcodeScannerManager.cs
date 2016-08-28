/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    ///     BarcodeScannerManager is where all barcode scanners are managed and where a user application or library can open an
    ///     instance of the driver.
    ///     This should be the first class accessed in this library by a user application.
    ///     <example>
    ///         <para>To start using this library you will need to do the following.</para>
    ///         <para>First open an instance of the CoreScanner driver.</para>
    ///         <code>
    /// BarcodeScannerManager.Instance.Open();
    /// </code>
    ///         <para>Now you can register for whatever events you want to listen for in your application.</para>
    ///         For example:
    ///         <para> </para>
    ///         <code>
    /// BarcodeScannerManager.Instance.RegisterForEvents(EventType.Barcode, EventType.Pnp, EventType.Image, EventType.Other, EventType.Rmd);
    /// </code>
    ///         <para>If you need to unregister for an event..</para>
    ///         <code>
    /// BarcodeScannerManager.Instance.UnRegisterForEvents(EventType.Barcode, EventType.Pnp, ...);
    /// </code>
    ///         <para>Adding a handler for an event is simply</para>
    ///         <code>
    /// BarcodeScannerManager.Instance.ScannerAttached += YourHandler;
    /// </code>
    ///         <para>
    ///             Now you can use BarcodeScannerManager.Instance.GetDevices() to get a list containing an
    ///             IMotorolaBarcodeScanner object for each of your scanners from which you can perform scanner specific tasks.
    ///         </para>
    ///     </example>
    /// </summary>
    public class BarcodeScannerManager : IDisposable
    {
        /// <summary>
        ///     Returns a singleton instance of the manager.
        ///     If the core scanner libraries can't be found or the object otherwise initialized, the instance
        /// </summary>
        public static readonly BarcodeScannerManager Instance = new BarcodeScannerManager();

        private CCoreScanner _scannerDriver;

        private BarcodeScannerManager()
        {
            try
            {
                if (_scannerDriver == null)
                    _scannerDriver = new CCoreScannerClass();

                Keyboard = new Keyboard(_scannerDriver);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Initialization of the Motorola/Zebra BarcodeScannerManager failed:{Environment.NewLine}{ex.Message}");
                _scannerDriver = null;
                Keyboard = null;
            }
        }

        /// <summary>
        ///     Used to determine if this instance can talk to the Interop drivers
        /// </summary>
        /// <returns>false when drivers are not installed or there are problems otherwise</returns>
        public bool IsInitialized => _scannerDriver != null;

        #region Commands

        /// <summary>
        ///     Version number of the CoreScanner driver.
        /// </summary>
        public string DriverVersion
        {
            get
            {
                if (_scannerDriver == null) return string.Empty;

                var inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.GetVersion, ref inXml, out outXml, out status);

                var xdoc = XDocument.Parse(outXml);
                var keyEnumState = xdoc.Descendants("arg-string").First();
                return keyEnumState.Value;
            }
        }

        public Keyboard Keyboard { get; }

        public void Close()
        {
            if (_scannerDriver == null) return;

            int status;
            UnRegisterForEvents(EventType.Barcode, EventType.Pnp, EventType.Image, EventType.Other, EventType.Rmd, EventType.Video);
            _scannerDriver.Close(0, out status);
        }

        /// <summary>
        ///     Find all connected devices
        /// </summary>
        /// <returns>A list of IMotorolaSnapiScanner</returns>
        public List<IMotorolaBarcodeScanner> GetDevices()
        {
            var retval = new List<IMotorolaBarcodeScanner>();
            if ((_scannerDriver == null) || !Open()) return retval;

            // Lets list down all the scanners connected to the host
            short numberOfScanners; // Number of scanners expect to be used
            var connectedScannerIDList = new int[32]; // Random number - more than expected

            // List of scanner IDs to be returned
            string outXml; //Scanner details output
            int status; // Extended API return code
            _scannerDriver.GetScanners(out numberOfScanners, connectedScannerIDList, out outXml, out status);
            var xdoc = XDocument.Parse(outXml);
            var scanners = xdoc.Descendants("scanner").ToList();

            foreach (var s in scanners)
            {
                var scanner = new BarcodeScanner(_scannerDriver, s);
                retval.Add(scanner);
            }

            return retval;
        }

        /// <summary>
        ///     Opens an application instance from the user application or user library.
        /// </summary>
        /// <returns>True if opened successfully</returns>
        public bool Open()
        {
            if (_scannerDriver == null) return false;

            //Call Open API
            int status; // Extended API return code
            _scannerDriver.Open(0 /* const: always 0 */,
                                new[]
                                {
                                    (short)ScannerType.All
                                } /* array of scanner types */,
                                1 /* size of prev parameter */,
                                out status);

            return ((StatusCode)status == StatusCode.Success) || ((StatusCode)status == StatusCode.AlreadyOpened);
        }

        /// <summary>
        ///     Registers the API for the given event types.
        /// </summary>
        /// <param name="events">Events to register for.</param>
        public void RegisterForEvents(params EventType[] events)
        {
            if (_scannerDriver == null) return;

            if (_registeredEvents == null)
                _registeredEvents = new List<EventType>();
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
            if (arg.Equals("")) return;

            arg = arg.Substring(0, arg.Length - 1);
            var inXml = string.Format(template, count, arg);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.RegisterForEvents, ref inXml, out outXml, out status);
        }

        /// <summary>
        ///     Unregisters the API for the given event types.
        /// </summary>
        /// <param name="events">Events to unregister from.</param>
        public void UnRegisterForEvents(params EventType[] events)
        {
            if (_scannerDriver == null) return;
            if (_registeredEvents == null) return;

            var template = @"<inArgs><cmdArgs><arg-int>{0}</arg-int><arg-int>{1}</arg-int></cmdArgs></inArgs>";

            var count = 0;
            var arg = "";
            foreach (var eventType in events)
            {
                if (!_registeredEvents.Contains(eventType)) continue;

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
            if (arg.Equals("")) return;

            arg = arg.Substring(0, arg.Length - 1);
            var inXml = string.Format(template, count, arg);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.UnregisterForEvents, ref inXml, out outXml, out status);
        }

        #endregion Commands

        #region Parsers

        /// <summary>
        ///     Gets barcode type from barcode xml.
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
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the current software component number from xml
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>SOftware component number</returns>
        private int ParseComponent(XDocument xdoc)
        {
            return int.Parse(xdoc.Descendants("software_component").Single().Value);
        }

        /// <summary>
        ///     Parses out the hex array from the XElement and converts each to a char and appends to string
        /// </summary>
        /// <param name="xdoc">XDocument containing xml to parse.</param>
        /// <returns>Data string</returns>
        private string ParseData(XDocument xdoc)
        {
            try
            {
                // rawdata contains the headers that are stripped from datalabel
                var datalabelData = xdoc.Descendants("datalabel").First();
                var array = datalabelData.Value.Trim().Split(' ');
                var retval = new StringBuilder(array.Length);
                foreach (var c in array)
                    retval.Append((char)Convert.ToInt32(c, 16));
                return retval.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="xdoc">XDocument generated from barcode event.</param>
        /// <returns></returns>
        private int ParseProgress(XDocument xdoc)
        {
            return int.Parse(xdoc.Descendants("progress").Single().Value);
        }

        /// <summary>
        ///     Gets rawdata from barcode xml.
        /// </summary>
        /// <param name="xdoc">XDocument generated from barcode event.</param>
        /// <returns>byte[] containing the rawdata</returns>
        private byte[] ParseRawData(XDocument xdoc)
        {
            return ValueConverters.HexStringToByteArray(xdoc.Descendants("rawdata").Single().Value);
        }

        /// <summary>
        ///     Gets the scanner ID from xml
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
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the status from xml
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
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the total number of records from xml
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
            {
                return 0;
            }
        }

        #endregion Parsers

        #region Events

        private List<EventType> _registeredEvents;

        /// <summary>
        ///     Invoked when another application attempts to access a scanner that has been exclusively claimed by this
        ///     application.
        /// </summary>
        public event EventHandler<IoEventArgs> ApplicationBlocked;

        /// <summary>
        ///     Invoked when a record finishes downloading to update on the progress.
        /// </summary>
        public event EventHandler<DownloadEventArgs> BlockFinished;

        /// <summary>
        ///     Invoked when bar code data is received by a scanner.
        /// </summary>
        public event EventHandler<BarcodeScanEventArgs> DataReceived;

        /// <summary>
        ///     Invoked when a scanner's operation mode is changed to decode barcode mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> DecodeModeEnabled;

        /// <summary>
        ///     Invoked when a component download ends
        /// </summary>
        public event EventHandler<DownloadEventArgs> DownloadEnded;

        /// <summary>
        ///     Invoked when a firmware download has begun.
        /// </summary>
        public event EventHandler<DownloadEventArgs> DownloadStarted;

        /// <summary>
        ///     Invoked when a status message or error message is received relating to firmware update.
        /// </summary>
        public event EventHandler<FirmwareEventArgs> FirmwareStatusOrErrorReceived;

        /// <summary>
        ///     Invoked when a firmware download session ends.
        /// </summary>
        public event EventHandler<FirmwareEventArgs> FlashSessionEnded;

        /// <summary>
        ///     Invoked when a firmware update session has begun.
        /// </summary>
        public event EventHandler<FlashStartEventArgs> FlashSessionStarted;

        /// <summary>
        ///     Invoked when a scanner captures an image.
        /// </summary>
        public event EventHandler<ImageEventArgs> ImageReceived;

        /// <summary>
        ///     Invoked when a scanner is attached by plugging in the usb or after a reboot.
        /// </summary>
        public event EventHandler<PnpEventArgs> ScannerAttached;

        /// <summary>
        ///     Invoked when a scanner is detached.
        /// </summary>
        public event EventHandler<PnpEventArgs> ScannerDetached;

        /// <summary>
        ///     Invoked when a scanner's operation mode is changed to snapshot mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> SnapshotModeEnabled;

        /// <summary>
        ///     Invoked when a scanner's operation mode is changed to video mode.
        /// </summary>
        public event EventHandler<ScannerEventArgs> VideoModeEnabled;

        /// <summary>
        ///     Invoked when a scanner captures video.
        /// </summary>
        public event EventHandler<VideoEventArgs> VideoReceived;

        /// <summary>
        ///     Invoked when a responce to a command is received.
        ///     TODO Figure out what to do with this. Should probably be handled inside the wrapper or not used.
        /// </summary>
        internal event EventHandler<CommandResponceEventArgs> ResponceReceived;

        public IEnumerable<EventType> RegisteredEvents => _registeredEvents;

        /// <summary>
        ///     Handles BardcodeEvent and invokes DataReceived.
        /// </summary>
        /// <param name="eventType">1 - Triggered when a decode is successful.</param>
        /// <param name="pscanData">
        ///     Bar code string that contains information about the scanner that triggered the bar code event
        ///     including data type, data label and raw data of the scanned bar code.
        /// </param>
        private void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            if (DataReceived == null) return;

            var xdoc = XDocument.Parse(pscanData);
            DataReceived(this, new BarcodeScanEventArgs(ParseScannerId(xdoc), ParseBarcodeType(xdoc), ParseData(xdoc), ParseRawData(xdoc)));
        }

        /// <summary>
        ///     Handles CommandResponceEvent. Invokes ResponceReceived
        /// </summary>
        /// <param name="status"></param>
        /// <param name="prspData"></param>
        private void OnCommandResponceEvent(short status, ref string prspData)
        {
            if (ResponceReceived == null) return;

            var outXml = XDocument.Parse(prspData);
            ResponceReceived(this, new CommandResponceEventArgs(outXml));
        }

        /// <summary>
        ///     Handles ImageEvent and invokes ImageReceived.
        /// </summary>
        /// <param name="eventtype"></param>
        /// <param name="size"></param>
        /// <param name="imageformat"></param>
        /// <param name="sfimageData"></param>
        /// <param name="pscannerdata"></param>
        private void OnImageEvent(short eventtype, int size, short imageformat, ref object sfimageData, ref string pscannerdata)
        {
            if (ImageEvent.CaptureCompleted != (ImageEvent)eventtype) return;

            var arr = (Array)sfimageData;
            var len = arr.LongLength;
            var byImage = new byte[len];
            arr.CopyTo(byImage, 0);
            var xdoc = XDocument.Parse(pscannerdata);
            ImageFormat format = null;
            using (var ms = new MemoryStream(byImage))
            {
                var image = Image.FromStream(ms);

                if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Bmp)
                    format = ImageFormat.Bmp;
                else if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Jpeg)
                    format = ImageFormat.Jpeg;
                else if ((Constants.Enums.ImageFormat)imageformat == Constants.Enums.ImageFormat.Tiff)
                    format = ImageFormat.Tiff;

                ImageReceived?.Invoke(this, new ImageEventArgs(ParseScannerId(xdoc), format, image));
            }
        }

        /// <summary>
        ///     Handles IOEvents. Invokes ApplicationBlocked
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        private void OnIOEvent(short type, byte data)
        {
            ApplicationBlocked?.Invoke(this, new IoEventArgs(type, data));
        }

        /// <summary>
        ///     Handles PNPEvent and invokes ScannerAttached or ScannerDetached.
        /// </summary>
        /// <param name="eventtype">
        ///     1 - Scanner attached.
        ///     2 - Scanner detached.
        /// </param>
        /// <param name="ppnpdata">Xml output.</param>
        private void OnPnpEvent(short eventtype, ref string ppnpdata)
        {
            var xdoc = XDocument.Parse(ppnpdata);
            var scannerId = ParseScannerId(xdoc);

            if ((ScannerAttached != null) && (eventtype == 0))
                ScannerAttached(this, new PnpEventArgs(scannerId));
            else if ((ScannerDetached != null) && (eventtype == 1))
                ScannerDetached(this, new PnpEventArgs(scannerId));
        }

        /// <summary>
        ///     Handles ScannerNotificationEvent. Invokes DecodeModeEnabled, SnapshotModeEnabled, or VideoModeEnabled.
        /// </summary>
        /// <param name="notificationType"></param>
        /// <param name="pScannerData"></param>
        private void OnScannerNotificationEvent(short notificationType, ref string pScannerData)
        {
            var xdoc = XDocument.Parse(pScannerData);
            var scannerId = ParseScannerId(xdoc);
            switch ((NotificationType)notificationType)
            {
                case NotificationType.DecodeMode:
                {
                    DecodeModeEnabled?.Invoke(this, new ScannerEventArgs(scannerId));
                    break;
                }
                case NotificationType.SnapshotMode:
                {
                    SnapshotModeEnabled?.Invoke(this, new ScannerEventArgs(scannerId));
                    break;
                }
                case NotificationType.VideoMode:
                {
                    VideoModeEnabled?.Invoke(this, new ScannerEventArgs(scannerId));
                    break;
                }
            }
        }

        /// <summary>
        ///     Handles ScanRMDEvent. Invokes FlashSessionStarted, DownloadStarted, BlockFinished, DownloadEnded,
        ///     FlashSessionEnded, or FirmwareStatusOrErrorReceived.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="prmdData"></param>
        private void OnScanRmdEvent(short eventType, ref string prmdData)
        {
            var xdoc = XDocument.Parse(prmdData);
            var status = (StatusCode)ParseStatus(xdoc);
            var scannerId = ParseScannerId(xdoc);
            switch ((RmdEventType)eventType)
            {
                case RmdEventType.SessionStarted:
                {
                    FlashSessionStarted?.Invoke(this, new FlashStartEventArgs(scannerId, status, ParseTotalRecords(xdoc)));
                    break;
                }
                case RmdEventType.DownloadStarted:
                {
                    DownloadStarted?.Invoke(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc)));
                    break;
                }
                case RmdEventType.BlockFinished:
                {
                    BlockFinished?.Invoke(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc), ParseProgress(xdoc)));
                    break;
                }
                case RmdEventType.DownloadEnded:
                {
                    DownloadEnded?.Invoke(this, new DownloadEventArgs(scannerId, status, ParseComponent(xdoc)));
                    break;
                }
                case RmdEventType.SessionEnded:
                {
                    FlashSessionEnded?.Invoke(this, new FirmwareEventArgs(scannerId, status));
                    break;
                }
                case RmdEventType.ErrorOrStatus:
                {
                    FirmwareStatusOrErrorReceived?.Invoke(this, new FirmwareEventArgs(scannerId, status));
                    break;
                }
            }
        }

        /// <summary>
        ///     Handles VideoEvent and invokes VideoReceived.
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

        #endregion Events

        #region IDisposable

        // Flag: Has Dispose already been called?
        private bool _disposed;

        ~BarcodeScannerManager() { Dispose(false); }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() { Dispose(true); }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Close();
            }

            // Free any unmanaged objects here.
            //
            _scannerDriver = null;
            _disposed = true;
        }

        #endregion IDisposable
    }
}