namespace BarcodeReaderSample
{
    public class ApplicationContext : System.Windows.Forms.ApplicationContext
    {
        private ApplicationManager applicationManager = new ApplicationManager();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                applicationManager.Dispose();

            base.Dispose(disposing);
        }
    }
}
