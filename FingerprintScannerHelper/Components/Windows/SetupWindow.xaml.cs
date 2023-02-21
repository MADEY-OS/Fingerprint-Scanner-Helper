using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.IO;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{
    public partial class SetupWindow : Window
    {
        private readonly ISetupServices _setup = new SetupServices();
        private readonly ISharedServices _shared = new SharedServices();

        public SetupWindow()
        {
            InitializeComponent();
            DataContext = _shared.GetConfiguration();
            if (!File.Exists("config.json")) _setup.CreateConfiguration();
            var config = _shared.GetConfiguration();
            tbSrc.Text = config.SourcePath;
            tbDest.Text = config.DestinationPath;
            tbArduinoPort.Text = config.ArduinoPort;
            tbArduinoBaud.Text = config.ArduinoBaud;
        }

        private void BtnSrc_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _shared.FileDialog();
        }

        private void BtnDest_Click(object sender, RoutedEventArgs e)
        {
            tbDest.Text = _shared.FileDialog();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var config = _shared.GetConfiguration();
            _shared.ModifyConfiguration(tbSrc.Text, tbDest.Text, tbArduinoPort.Text, tbArduinoBaud.Text, config.PersonNumber, config.FingerNumber, config.Step);
            _setup.CreateVariantLibrary();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
