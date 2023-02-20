using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.IO;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{
    public partial class SetupWindow : Window
    {
        private readonly ISetupServices _setup = new SetupServices();
        private readonly IMainServices _main = new MainServices();



        public SetupWindow()
        {
            InitializeComponent();
            if (!File.Exists("config.json")) _setup.CreateConfiguration();
            var config = _main.GetConfiguration();
            tbSrc.Text = config.SourcePath;
            tbDest.Text = config.DestinationPath;
            tbArduinoPort.Text = config.ArduinoPort;
            tbArduinoBaud.Text = config.ArduinoBaud;
        }

        private void BtnSrc_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _setup.FileDialog();
        }

        private void BtnDest_Click(object sender, RoutedEventArgs e)
        {
            tbDest.Text = _setup.FileDialog();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var config = _main.GetConfiguration();
            _main.ModifyConfiguration(tbSrc.Text, tbDest.Text, tbArduinoPort.Text, tbArduinoBaud.Text, config.PersonNumber, config.FingerNumber, config.Step);
            _setup.CreateVariantLibrary();
            Close();
        }
    }
}
