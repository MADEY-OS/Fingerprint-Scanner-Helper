using FingerprintScannerHelper.Components.Windows;
using System.Windows;

namespace FingerprintScannerHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SetupWindow setupWindow = new SetupWindow();
            setupWindow.Show();

            base.OnStartup(e);
        }
    }
}
