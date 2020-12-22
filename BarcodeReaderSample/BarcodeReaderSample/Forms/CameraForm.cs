using AForge.Video;
using AForge.Video.DirectShow;
using BarcodeReaderSample.Common;
using BarcodeReaderSample.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BarcodeReaderSample.Forms
{
    public partial class CameraForm : Form
    {
        private System.Threading.SemaphoreSlim semaphore = new System.Threading.SemaphoreSlim(1, 1);
        private VideoCaptureDevice videoDevice;
        private BarcodeService barcodeService;
        private string lastDetectedBarcodeValue;

        public CameraForm()
        {
            InitializeComponent();
            this.ShowIcon = false;
            barcodeService = new BarcodeService();
            pictureBox1.Image = FontIcon.CreateGlyphIcon(FontIcon.Glyphs.Camera, iconWidth: 50, iconHeight: 50, emSize: 28, fontColor: Color.Red).ToBitmap();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            StartCapture();
        }

        private void StartCapture()
        {
            videoDevice = GetCaptureDevice();
            if (videoDevice != null)
            {
                CloseCurrentVideoSource();
                videoDevice.NewFrame += new NewFrameEventHandler(VideoDevice_FrameArrived);
                videoSourcePlayer1.VideoSource = videoDevice;
                videoSourcePlayer1.Start();
            }
        }

        private VideoCaptureDevice GetCaptureDevice()
        {
            VideoCaptureDevice videoCaptureDevice = null;

            if (!string.IsNullOrEmpty(SettingService.CameraDeviceName))
            {
                videoCaptureDevice = new VideoCaptureDevice(SettingService.CameraDeviceName);
            }

            if (videoCaptureDevice == null)
            {
                var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                    SettingService.CameraDeviceName = videoDevices[0].MonikerString;
                    videoCaptureDevice = new VideoCaptureDevice(SettingService.CameraDeviceName);
                }
            }

            return videoCaptureDevice;
        }

        private async void VideoDevice_FrameArrived(object sender, NewFrameEventArgs eventArgs)
        {
            if (SettingService.IsMirror)
                eventArgs.Frame.RotateFlip(RotateFlipType.RotateNoneFlipX);

            if (!await semaphore.WaitAsync(0))
                return;

            try
            {
                using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    var detectedBarcode = await barcodeService.DetectBarcodeFromBitmapAsync(bitmap);
                    if (detectedBarcode != null)
                    {
                        if (lastDetectedBarcodeValue != detectedBarcode.BarcodeValue)
                        {
                            WriteTextSafe(detectedBarcode.BarcodeValue);

                            if (SettingService.IsSaveToCSV)
                                ExportCSV(detectedBarcode);

                            if (SettingService.IsCopyToClipboard)
                                CopyToClipboard(detectedBarcode);

                            lastDetectedBarcodeValue = detectedBarcode.BarcodeValue;
                        }
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        public delegate void SafeCallDelegate(string text);

        private void WriteTextSafe(string text)
        {
            if (label1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                label1.Invoke(d, new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }

        private void ExportCSV(BarcodeDetectedResult barcodeDetectedResult)
        {
            if (string.IsNullOrEmpty(SettingService.CSVExportPath))
                SettingService.CSVExportPath = AppDomain.CurrentDomain.BaseDirectory;

            var filePathName = Path.Combine(SettingService.CSVExportPath, string.Format("{0}.csv", DateTime.Now.ToString("yyyyMMdd")));
            using (StreamWriter w = File.AppendText(filePathName))
            {
                w.WriteLine($"{barcodeDetectedResult.DetectedDateTime.ToString("yyyyMMdd hh:mm:ss")},{barcodeDetectedResult.BarcodeValue}");
            }
        }

        private void CopyToClipboard(BarcodeDetectedResult barcodeDetectedResult)
        {
            //Clipboard.SetText(detectedBarcode.BarcodeValue);

            Thread thread = new Thread(() => Clipboard.SetText(barcodeDetectedResult.BarcodeValue));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentVideoSource();
        }

        private void CloseCurrentVideoSource()
        {
            try
            {
                if (videoSourcePlayer1.VideoSource != null)
                {
                    videoSourcePlayer1.SignalToStop();
                    // wait ~ 3 seconds
                    for (int i = 0; i < 30; i++)
                    {
                        if (!videoSourcePlayer1.IsRunning)
                            break;
                        System.Threading.Thread.Sleep(100);
                    }
                    if (videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.Stop();
                    }
                    videoSourcePlayer1.VideoSource = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("CloseCurrentVideoSource exception:{0}", ex.Message));
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StartCapture();
            pictureBox1.Visible = false;
            videoSourcePlayer1.Visible = true;
            label1.Visible = true;
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {
            CloseCurrentVideoSource();
            videoSourcePlayer1.Visible = false;
            label1.Visible = false;
            pictureBox1.Visible = true;
        }
    }
}
