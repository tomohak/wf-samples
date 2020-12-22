using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BarcodeReaderSample.Services
{
    public class BarcodeService : IDisposable, INotifyPropertyChanged
    {        
        private ZXing.IBarcodeReader barcodeReader;

        public BarcodeService()
        {
            barcodeReader = new ZXing.BarcodeReader()
            {
                //AutoRotate = true,
                //TryInverted = true,
                Options = new ZXing.Common.DecodingOptions { TryHarder = true }
            };

            //List<ZXing.BarcodeFormat> barcodeFormats = new List<ZXing.BarcodeFormat>();
            //barcodeFormats.Add(ZXing.BarcodeFormat.DATA_MATRIX);
            //barcodeReader.Options.PossibleFormats = barcodeFormats;
        }

        public async Task<BarcodeDetectedResult> DetectBarcodeFromBitmapAsync(System.Drawing.Bitmap _bitmap)
        {
            try
            {
                using (System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)_bitmap.Clone())
                {
                    return await Task.Run(() =>
                    {
                        var result = Decode(_bitmap);
                        if (result == null)
                        {
                            _bitmap.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
                            result = Decode(_bitmap);
                        }
                        if (result != null)
                        {
                            return new BarcodeDetectedResult((int)result.BarcodeFormat, result.Text);
                        }
                        return null;
                    });
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(string.Format("DetectBarcodeFromBitmap exception:{0}", ex.Message));
            }           

            return null;
        }

        private ZXing.Result Decode(System.Drawing.Bitmap bitmap)
        {
            ZXing.LuminanceSource source = BitmapToLuminanceSource(bitmap);
            return barcodeReader.Decode(source);
        }
        
        private ZXing.LuminanceSource BitmapToLuminanceSource(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);

                byte[] arr = memoryStream.GetBuffer();

                ZXing.LuminanceSource source = new ZXing.RGBLuminanceSource(
                    arr,
                    bitmap.Width,
                    bitmap.Height,
                    ZXing.RGBLuminanceSource.BitmapFormat.Unknown);

                return source;
            }
        }

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            var raiseEvent = PropertyChanged;
            raiseEvent?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BarcodeDetectedResult
    {
        public string BarcodeValue { get; private set; }
        public int BarcodeFormatId { get; private set; }
        public DateTime DetectedDateTime { get; private set; }

        internal BarcodeDetectedResult(int barcodeFormatId, string barcodeValue)
        {
            BarcodeFormatId = barcodeFormatId;
            BarcodeValue = barcodeValue;
            DetectedDateTime = DateTime.Now;
        }
    }
}
