using System.Windows;

namespace FingerprintScannerHelper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            base.OnStartup(e);
        }
    }
}