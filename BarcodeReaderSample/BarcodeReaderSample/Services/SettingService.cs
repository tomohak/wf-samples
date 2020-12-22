namespace BarcodeReaderSample.Services
{
    public class SettingService
    {
        public static string CameraDeviceName
        {
            get
            {
                return Properties.Settings.Default.CameraDeviceName;
            }
            set
            {
                if (Properties.Settings.Default.CameraDeviceName != value)
                    Properties.Settings.Default.CameraDeviceName = value;
            }
        }

        public static string CSVExportPath
        {
            get
            {
                return Properties.Settings.Default.CSVExportPath;
            }
            set
            {
                if (Properties.Settings.Default.CSVExportPath != value)
                    Properties.Settings.Default.CSVExportPath = value;
            }
        }

        public static bool IsSaveToCSV
        {
            get
            {
                return Properties.Settings.Default.IsSaveToCSV;
            }
            set
            {
                if (Properties.Settings.Default.IsSaveToCSV != value)
                    Properties.Settings.Default.IsSaveToCSV = value;
            }
        }

        public static bool IsCopyToClipboard
        {
            get
            {
                return Properties.Settings.Default.IsCopyToClipboard;
            }
            set
            {
                if (Properties.Settings.Default.IsCopyToClipboard != value)
                    Properties.Settings.Default.IsCopyToClipboard = value;
            }
        }

        public static bool IsMirror
        {
            get
            {
                return Properties.Settings.Default.IsMirror;
            }
            set
            {
                if (Properties.Settings.Default.IsMirror != value)
                    Properties.Settings.Default.IsMirror = value;
            }
        }
    }
}
