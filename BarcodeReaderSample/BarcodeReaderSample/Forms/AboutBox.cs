using BarcodeReaderSample.Services;
using System.Windows.Forms;

namespace BarcodeReaderSample.Forms
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.logoPictureBox.Image = ApplicationManager.Logo;
            this.Text = "About";
            this.labelProductName.Text = AssemblyService.AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", AssemblyService.AssemblyVersion);
            this.labelCopyright.Text = AssemblyService.AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyService.AssemblyCompany;
            this.textBoxDescription.Text = AssemblyService.AssemblyDescription;
        }
    }
}
