/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;

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
        FlashDownloadSessionStarted = 11, // Triggered when flash download session starts
        ComponentDownloadStarted = 12, // Triggered when component download starts
        FlashBlockCompleted = 13, // Triggered when block(s) of flash completed
        ComponentDownloadCompleted = 14, // Triggered when component download ends
        FlashDownloadSessionCompleted = 15, // Triggered when flash download session ends
        ErrorOrStatusUpdate = 16 // Triggered when update error or status
    }

    internal enum ImageEvent
    {
        CaptureCompleted = 1, // Triggered when complete image captured
        ErrorOrStatusUpdate = 2 // Triggered when image error or status
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
        All = 1, // All Scanners
        Snapi = 2, // SNAPI Scanners
        Ssi = 3, // SSI Scanners (RS232)
        IbmHid = 6, // IBM Hand Held Scanners (USB OPOS)
        NixdorfModeB = 7, // Nixdorf Mode B scanners (RS232)
        UsbHidKeyboard = 8, // USB HID Keyboard emulation scanners
        IbmTableTop = 9 // IBM Table Top Scanners
    }

    public enum StatusCode
    {
        Success = 0, //  Generic success
        Locked = 10, //  Device is locked by another application
        InvalidAppHandle = 100, //  Invalid application handle. Reserved parameter. Value is zero.
        CommLibUnavailable = 101, //  Required Comm Lib is unavailable to support the requested Type
        NullBufferPointer = 102, //  Null buffer pointer
        InvalidBufferPointer = 103, //  Invalid buffer pointer
        IncorrectBufferSize = 104, //  Incorrect buffer size
        DuplicateTypeIds = 105, //  Requested Type IDs are duplicated
        IncorrectNumberOfTypes = 106, //  Incorrect value for number of Types
        InvalidArgument = 107, //  Invalid argument
        InvalidScannerId = 108, //  Invalid scanner ID
        IncorrectNumberOfEventIds = 109, //  Incorrect value for number of Event IDs
        DuplicateEventId = 110, //  Event IDs are duplicated
        InvalidEventId = 111, //  Invalid value for Event ID
        DeviceUnavailable = 112, //  Required device is unavailable
        InvalidOpcode = 113, //  Opcode is invalid
        InvalidType = 114, //  Invalid value for Type
        AsyncNotSupported = 115, //  Opcode does not support asynchronous method
        OpcodeNotSupported = 116, //  Device does not support the Opcode
        OperationFailed = 117, //  Operation failed in device
        RequestFailed = 118, //  Request failed in CoreScanner
        AlreadyOpened = 200, //  CoreScanner is already opened
        AlreadyClosed = 201, //  CoreScanner is already closed
        Closed = 202, //  CoreScanner is closed
        MalformedXml = 300, //  Malformed inXML
        XmlReaderInstantiationFailed = 301, //  XML Reader could not be instantiated
        XmlReaderInputSetFailed = 302, //  Input for XML Reader could not be set
        XmlReaderPropertySetFailed = 303, //  XML Reader property could not be set
        XmlWriterInstantiationFailed = 304, //  XML Writer could not be instantiated
        XmlWriterOutputSetFailed = 305, //  Output for XML Writer could not be set
        XmlWriterPropertySetFailed = 306, //  XML Writer property could not be set
        XmlElementReadFailed = 307, //  Cannot read element from XML input
        InvalidXmlArg = 308, //  Arguments in inXML are not valid
        XmlWriteFailed = 309, //  Write to XML output string failed
        XmlInputLengthExceeded = 310, //  InXML exceed length
        XmlBufferLengthExceeded = 311, //  buffer length for type exceeded
        NullPointer = 400, //  Null pointer
        DuplicateClient = 401, //  Cannot add a duplicate client
        InvalidFirmwareFile = 500, //  Invalid firmware file
        FirmwareUpdateFailedInScanner = 501, //  FW Update failed in scanner
        FailedToReadFirmwareDataFile = 502, //  Failed to read DAT file
        FirmwareUpdateInProgress = 503, //  Firmware Update is in progress (cannot proceed another FW Update or another command)
        FirmwareUpdateAlreadyAborted = 504, //  Firmware update is already aborted
        FirmwareUpdateAborted = 505, //  FW Update aborted
        ScannerDisconnectedDuringFirmwareUpdate = 506, //  Scanner is disconnected while updating firmware
        FirmwareAlreadyExistsOnScanner = 600 //  The software component is already resident in the scanner
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