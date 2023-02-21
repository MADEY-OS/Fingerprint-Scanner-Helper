using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{

    public partial class SettingsWindow : Window
    {
        private readonly ISetupServices _setup = new SetupServices();
        private readonly IMainServices _main = new MainServices();
        public SettingsWindow()
        {
            InitializeComponent();
            tbSrc.Text = _main.GetConfiguration().SourcePath;
            tbDest.Text = _main.GetConfiguration().DestinationPath;
            tbArduinoPort.Text = _main.GetConfiguration().ArduinoPort;
            tbArduinoBaud.Text = _main.GetConfiguration().ArduinoBaud;
            tbPerson.Text = _main.GetConfiguration().PersonNumber.ToString();
            cbFinger.SelectedIndex = _main.GetConfiguration().FingerNumber - 1;
            foreach (var variant in _main.GetLibrary())
            {
                cbScan.Items.Add(variant.Description.ToString());
            }
            cbScan.SelectedIndex = _main.GetConfiguration().Step - 1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _main.ModifyConfiguration(tbSrc.Text, tbDest.Text, tbArduinoPort.Text, tbArduinoBaud.Text, Int32.Parse(tbPerson.Text), cbFinger.SelectedIndex + 1, cbScan.SelectedIndex + 1);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnDest_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _setup.FileDialog();
        }

        private void btnSrc_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _setup.FileDialog();
        }
    }
}
