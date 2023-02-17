using FingerprintScannerHelper.Components.Windows;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Windows;

namespace FingerprintScannerHelper
{
    public partial class MainWindow : Window
    {
        private readonly IMainServices _services = new MainServices();

        public MainWindow()
        {
            InitializeComponent();

            SetupWindow setup = new SetupWindow();
            setup.ShowDialog();

            picHolder.Source = _services.GetImage();
            tbScan.Text = _services.GetScan();

        }

        private void Help_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void Settings_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            picHolder.Source = _services.GetImage();
            tbScan.Text = _services.GetScan();
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
