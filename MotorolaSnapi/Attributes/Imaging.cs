using System;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    //TODO Comment this class.
    class Imaging : MotorolaAttributeSet
    {
        internal Imaging(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        public ushort CropTop
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(ImagingAttribute.CropTop)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute{Id = ImagingAttribute.CropTop, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value});
            }
        }

        public ushort CropLeft
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(ImagingAttribute.CropLeft)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.CropLeft, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value });
            }
        }

        public ushort CropBottom
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(ImagingAttribute.CropBottom)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.CropBottom, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value });
            }
        }

        public ushort JPEGFileSize
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(ImagingAttribute.JPEGFileSizeWord)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.JPEGFileSizeWord, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value });
            }
        }

        public ushort Exposure
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(ImagingAttribute.Exposure)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.Exposure, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value });
            }
        }

        public bool SnapshotByMotionEnabled
        {
            get
            {
                return (bool)GetAttribute(ImagingAttribute.SnapshotByMotion)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.SnapshotByMotion, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        public bool ContinuousSnapshotEnabled
        {
            get
            {
                return (bool)GetAttribute(ImagingAttribute.ContinuousSnapshot)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.ContinuousSnapshot, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        public ushort ImageEdgeSharpen
        {
            get
            {
                return (ushort)GetAttribute(ImagingAttribute.ImageEdgeSharpen)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.ContinuousSnapshot, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        public ushort ImageRotation
        {
            get
            {
                return (ushort)GetAttribute(ImagingAttribute.ImageRotation)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute{ Id = ImagingAttribute.ImageRotation, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        public bool ContrastEnhancement
        {
            get
            {
                return (bool)GetAttribute(ImagingAttribute.ContrastEnhancement)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.ContrastEnhancement, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        public ushort ImageResolution
        {
            get
            {
                return (ushort)GetAttribute(ImagingAttribute.VideoSubsample)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.VideoSubsample, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        public ushort AimBrightness
        {
            get
            {
                return (ushort)GetAttribute(ImagingAttribute.AimBrightness)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.AimBrightness, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        public ushort IlluminationBrightness
        {
            get
            {
                return (ushort)GetAttribute(ImagingAttribute.IlluminationBrightness)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = ImagingAttribute.IlluminationBrightness, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }
    }
}
