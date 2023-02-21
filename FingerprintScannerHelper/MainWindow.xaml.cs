using FingerprintScannerHelper.Components.Windows;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.IO.Ports;
using System.Windows;

namespace FingerprintScannerHelper
{
    public partial class MainWindow : Window
    {
        private readonly IMainServices _main = new MainServices();
        private readonly ISharedServices _shared = new SharedServices();
        static SerialPort _serialPort;

        public MainWindow()
        {
            InitializeComponent();

            picHolder.Source = _main.GetImage();
            tbScan.Text = _main.GetScanVariant() is null ? "Brak" : _main.GetScanVariant().Description;

            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = _shared.GetConfiguration().ArduinoPort;
                _serialPort.BaudRate = int.Parse(_shared.GetConfiguration().ArduinoBaud);
                _serialPort.Open();

                btnAccept.IsEnabled = true;
                btnReject.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Nie można połaczyć się z wagą! Sprawdź ustawienia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                btnAccept.IsEnabled = false;
                btnReject.IsEnabled = false;
            }
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
            _serialPort.Close();
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _main.MoveScan(_serialPort.ReadLine());
            _serialPort.DiscardOutBuffer();
            picHolder.Source = _main.GetImage();
            tbScan.Text = _main.GetScanVariant().Description;
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            _main.DeleteScan();
        }
    }
}
