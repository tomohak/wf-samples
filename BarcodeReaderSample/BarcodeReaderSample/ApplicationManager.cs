using BarcodeReaderSample.Common;
using BarcodeReaderSample.Forms;
using BarcodeReaderSample.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace BarcodeReaderSample
{
    public partial class ApplicationManager : Component
    {
        private BarcodeService barcodeService;
        private static Properties.Settings settings = Properties.Settings.Default;

        public ApplicationManager()
        {
            InitializeComponent();

            barcodeService = new BarcodeService();

            notifyIcon1.Text = AssemblyService.AssemblyProduct;
            notifyIcon1.Icon = Icon;

            SetupToolStripMenuItem();

            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;
            toolStripMenuItem3.Click += ToolStripMenuItem3_Click;
            toolStripMenuItem4.Click += ToolStripMenuItem4_Click;

            settings.PropertyChanged += Settings_PropertyChanged;

            Disposed += ApplicationManager_Disposed;
        }

        public ApplicationManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        private void SetupToolStripMenuItem()
        {
            toolStripMenuItem1.Image = FontIcon.CreateGlyphIcon(FontIcon.Glyphs.Play).ToBitmap();
            toolStripMenuItem1.Text = string.Format("{0} barcode scanning", "Start");
            toolStripMenuItem2.Image = FontIcon.CreateGlyphIcon(FontIcon.Glyphs.Setting).ToBitmap();
            toolStripMenuItem3.Image = FontIcon.CreateGlyphIcon(FontIcon.Glyphs.Info).ToBitmap();
            toolStripMenuItem4.Image = FontIcon.CreateGlyphIcon(FontIcon.Glyphs.SignOut).ToBitmap();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm<CameraForm>();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowForm<SettingsForm>();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowForm<AboutBox>(isDialog: true);
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowForm<T>(bool isDialog = false) where T : Form, new()
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    Form n = Application.OpenForms[i];
                    if (n is T)
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    if (isDialog)
                    {
                        using (T form = new T())
                        {
                            SetFormLocation(form);
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        T form = new T();
                        SetFormLocation(form);
                        form.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("ShowForm exception:{0}", ex.Message));
            }
        }

        private void SetFormLocation(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int left = workingArea.Width - form.Width;
            int top = workingArea.Height - form.Height;
            form.Location = new System.Drawing.Point(left, top);
        }

        public static System.Drawing.Icon Icon => ((System.Drawing.Icon)(new ComponentResourceManager(typeof(Properties.Resources)).GetObject("BarcodeReaderSample.ICON")));

        public static System.Drawing.Image Logo => ((System.Drawing.Image)(new ComponentResourceManager(typeof(Properties.Resources)).GetObject("BarcodeReaderSample.BMP")));

        private void ApplicationManager_Disposed(object sender, EventArgs e)
        {
            barcodeService.Dispose();
            settings.PropertyChanged -= Settings_PropertyChanged;
            notifyIcon1.Dispose();
        }
    }
}
