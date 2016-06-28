/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace Motorola.Snapi.Constants.Enums
{
    internal enum DeviceParameter
    {
        DateOfManufacture = 535,

        FirmwareVersion = 20004,

        UpcAStatus = 1,

        BeeperVolume = 140,

        AdfRule = 392
    }

    internal enum FirmwareUpdateEvent
    {
        [Display(Name = "Flash Download Session Started", Description = "Triggered when flash download session starts")]
        FlashDownloadSessionStarted = 11,

        [Display(Name = "Componen tDownload Started", Description = "Triggered when component download starts")]
        ComponentDownloadStarted = 12,

        [Display(Name = "Flash Block Completed", Description = "Triggered when block(s) of flash completed")]
        FlashBlockCompleted = 13,

        [Display(Name = "Component Download Completed", Description = "Triggered when component download ends")]
        ComponentDownloadCompleted = 14,

        [Display(Name = "Flash Download Session Completed", Description = "Triggered when flash download session ends")]
        FlashDownloadSessionCompleted = 15,

        [Display(Name = "Error Or Status Update", Description = "Triggered when update error or status")]
        ErrorOrStatusUpdate = 16
    }

    internal enum ImageEvent
    {
        [Display(Name = "Capture Completed", Description = "Triggered when complete image captured")]
        CaptureCompleted = 1,

        [Display(Name = "Error Or Status Update", Description = "Triggered when image error or status")]
        ErrorOrStatusUpdate = 2
    }

    internal enum ImageFormat
    {
        Bmp = 3,

        Tiff = 4,

        Jpeg = 1
    }

    internal enum PnpEvent
    {
        ScannerAttached = 0, // Triggered when a Motorola Scanner is attached.

        ScannerDetached = 1 // Triggered when a Motorola Scanner is detached.
    }

    internal enum ScannerCommand
    {
        // Scanner SDK
        GetVersion = 1000,

        RegisterForEvents = 1001,

        UnregisterForEvents = 1002,

        // Scanner Access Control Commands
        ClaimDevice = 1500,

        ReleaseDevice = 1501,

        // Scanner Common Commands
        AbortMacroPdf = 2000,

        AbortUpdateFirmware = 2001,

        AimOff = 2002,

        AimOn = 2003,

        FlushMacroPdf = 2005,

        DevicePullTrigger = 2011,

        DeviceReleaseTrigger = 2012,

        ScanDisable = 2013,

        ScanEnable = 2014,

        SetParameterDefaults = 2015,

        DeviceSetParameters = 2016,

        SetParameterPersistence = 2017,

        RebootScanner = 2019,

        // Scanner Operation Mode Commands
        DeviceCaptureImage = 3000,

        DeviceCaptureBarcode = 3500,

        DeviceCaptureVideo = 4000,

        //Scanner Management Commands
        AttrGetAll = 5000,

        AttrGet = 5001,

        AttrGetNext = 5002,

        AttrSet = 5004,

        AttrStore = 5005,

        GetDeviceTopology = 5006,

        StartNewFirmware = 5014,

        UpdateFirmware = 5016,

        UpdateFirmwareFromPlugin = 5017,

        // Scanner Action Commands
        SetAction = 6000,

        // Serial Scanner Commands
        DeviceSetSerialPortSettings = 6101,

        // Other Commands
        DeviceSwitchHostMode = 6200,

        // Keyboard Emulator Commands
        KeyboardEmulatorEnable = 6300,

        KeyboardEmulatorSetLocale = 6301,

        KeyboardEmulatorGetConfig = 6302,

        // Scale Commands
        ScaleReadWeight = 7000,

        ScaleZeroScale = 7002,

        ScaleSystemReset = 7015
    }

    internal enum ScannerType
    {
        [Display(Name = "All", Description = "All Scanners")]
        All = 1,

        [Display(Name = "Snapi", Description = "SNAPI Scanners")]
        Snapi = 2,

        [Display(Name = "Ssi", Description = "SSI Scanners (RS232)")]
        Ssi = 3,

        [Display(Name = "IbmHid", Description = "IBM Hand Held Scanners (USB OPOS)")]
        IbmHid = 6,

        [Display(Name = "NixdorfModeB", Description = "Nixdorf Mode B scanners (RS232)")]
        NixdorfModeB = 7,

        [Display(Name = "UsbHidKeyboard", Description = "USB HID Keyboard emulation scanners")]
        UsbHidKeyboard = 8,

        [Display(Name = "IbmTableTop", Description = "IBM Table Top Scanners")]
        IbmTableTop = 9
    }

    public enum StatusCode
    {
        [Display(Name = "Success", Description = "Generic success")]
        Success = 0,

        [Display(Name = "Locked", Description = "Device is locked by another application")]
        Locked = 10,

        [Display(Name = "Invalid App Handle", Description = "Invalid application handle. Reserved parameter. Value is zero.")]
        InvalidAppHandle = 100,

        [Display(Name = "Comm Lib Unavailable", Description = "Required Comm Lib is unavailable to support the requested Type")]
        CommLibUnavailable = 101,

        [Display(Name = "Null Buffer Pointer", Description = "Null buffer pointer")]
        NullBufferPointer = 102,

        [Display(Name = "Invalid Buffer Pointer", Description = "Invalid buffer pointer")]
        InvalidBufferPointer = 103,

        [Display(Name = "Incorrect Buffer Size", Description = "Incorrect buffer size")]
        IncorrectBufferSize = 104,

        [Display(Name = "Duplicate Type Ids", Description = "Requested Type IDs are duplicated")]
        DuplicateTypeIds = 105,

        [Display(Name = "Incorrect Number Of Types", Description = "Incorrect value for number of Types")]
        IncorrectNumberOfTypes = 106,

        [Display(Name = "Invalid Argument", Description = "Invalid argument")]
        InvalidArgument = 107,

        [Display(Name = "Invalid ScannerId", Description = "Invalid scanner ID")]
        InvalidScannerId = 108,

        [Display(Name = "Incorrect Number Of Event Ids", Description = "Incorrect value for number of Event IDs")]
        IncorrectNumberOfEventIds = 109,

        [Display(Name = "Duplicate Event Id", Description = "Event IDs are duplicated")]
        DuplicateEventId = 110,

        [Display(Name = "Invalid Event Id", Description = "Invalid value for Event ID")]
        InvalidEventId = 111,

        [Display(Name = "Device Unavailable", Description = "Required device is unavailable")]
        DeviceUnavailable = 112,

        [Display(Name = "Invalid Opcode", Description = "Opcode is invalid")]
        InvalidOpcode = 113,

        [Display(Name = "Invalid Type", Description = "Invalid value for Type")]
        InvalidType = 114,

        [Display(Name = "Async Not Supported", Description = "Opcode does not support asynchronous method")]
        AsyncNotSupported = 115,

        [Display(Name = "Opcode Not Supported", Description = "Device does not support the Opcode")]
        OpcodeNotSupported = 116,

        [Display(Name = "Operation Failed", Description = "Operation failed in device")]
        OperationFailed = 117,

        [Display(Name = "Request Failed", Description = "Request failed in CoreScanner")]
        RequestFailed = 118,

        [Display(Name = "Already Opened", Description = "CoreScanner is already opened")]
        AlreadyOpened = 200,

        [Display(Name = "Already Closed", Description = "CoreScanner is already closed")]
        AlreadyClosed = 201,

        [Display(Name = "Closed", Description = "CoreScanner is closed")]
        Closed = 202,

        [Display(Name = "Malformed Xml", Description = "Malformed inXML")]
        MalformedXml = 300,

        [Display(Name = "Xml Reader Instantiation Failed", Description = "XML Reader could not be instantiated")]
        XmlReaderInstantiationFailed = 301,

        [Display(Name = "Xml Reader Input Set Failed", Description = "Input for XML Reader could not be set")]
        XmlReaderInputSetFailed = 302,

        [Display(Name = "Xml ReaderPropertySetFailed", Description = "XML Reader property could not be set")]
        XmlReaderPropertySetFailed = 303,

        [Display(Name = "Xml Writer Instantiation Failed", Description = "Xml Writer could not be instantiated")]
        XmlWriterInstantiationFailed = 304,

        [Display(Name = "Xml Writer Output Set Failed", Description = "Output for XML Writer could not be set")]
        XmlWriterOutputSetFailed = 305,

        [Display(Name = "Xml Writer Property Set Failed", Description = "Xml Writer property could not be set")]
        XmlWriterPropertySetFailed = 306,

        [Display(Name = "Xml Element Read Failed", Description = "Cannot read element from XML input")]
        XmlElementReadFailed = 307,

        [Display(Name = "Invalid Xml Arg", Description = "Arguments in inXML are not valid")]
        InvalidXmlArg = 308,

        [Display(Name = "Xml Write Failed", Description = "Write to XML output string failed")]
        XmlWriteFailed = 309,

        [Display(Name = "Xml Input Length Exceeded", Description = "InXML exceed length")]
        XmlInputLengthExceeded = 310,

        [Display(Name = "Xml Buffer Length Exceeded", Description = "buffer length for type exceeded")]
        XmlBufferLengthExceeded = 311,

        [Display(Name = "Null Pointer", Description = "Null pointer")]
        NullPointer = 400,

        [Display(Name = "Duplicate Client", Description = "Cannot add a duplicate client")]
        DuplicateClient = 401,

        [Display(Name = "Invalid Firmware File", Description = "Invalid firmware file")]
        InvalidFirmwareFile = 500,

        [Display(Name = "Firmware Update Failed In Scanner", Description = "FW Update failed in scanner")]
        FirmwareUpdateFailedInScanner = 501,

        [Display(Name = "Failed To Read Firmware Data File", Description = "Failed to read DAT file")]
        FailedToReadFirmwareDataFile = 502,

        [Display(Name = "Firmware Update In Progress", Description = "Firmware Update is in progress (cannot proceed another FW Update or another command)")]
        FirmwareUpdateInProgress = 503,

        [Display(Name = "Firmware Update Already Aborted", Description = "Firmware update is already aborted")]
        FirmwareUpdateAlreadyAborted = 504,

        [Display(Name = "Firmware Update Aborted", Description = "FW Update aborted")]
        FirmwareUpdateAborted = 505,

        [Display(Name = "Scanner Disconnected During Firmware Update", Description = "Scanner is disconnected while updating firmware")]
        ScannerDisconnectedDuringFirmwareUpdate = 506,

        [Display(Name = "Firmware Already Exists On Scanner", Description = "The software component is already resident in the scanner")]
        FirmwareAlreadyExistsOnScanner = 600

    }

    [Flags]
    internal enum Subscribe
    {
        Barcode = 1,

        Image = 2,

        Video = 4,

        Rmd = 8,

        Pnp = 16,

        Other = 32
    }
}