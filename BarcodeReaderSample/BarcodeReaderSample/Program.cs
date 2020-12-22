using System;
using System.Windows.Forms;

namespace BarcodeReaderSample
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationContext());
            //Application.Run(new Forms.CameraForm());
            //Application.Run(new Forms.SettingsForm());
            //Application.Run(new Forms.AboutBox());

        }
    }
}
