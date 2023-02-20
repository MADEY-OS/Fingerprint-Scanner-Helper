using FingerprintScannerHelper.Components.Windows;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows;

namespace FingerprintScannerHelper
{
    public partial class MainWindow : Window
    {
        private readonly IMainServices _main = new MainServices();
        static SerialPort _serialPort;

        public MainWindow()
        {
            InitializeComponent();

            SetupWindow setup = new SetupWindow();
            setup.ShowDialog();

            picHolder.Source = _main.GetImage();
            tbScan.Text = _main.GetScanVariant().Description;
            _serialPort = new SerialPort();
            _serialPort.PortName = _main.GetConfiguration().ArduinoPort;
            _serialPort.BaudRate = int.Parse(_main.GetConfiguration().ArduinoBaud);
            //_serialPort.Open();
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

        private bool MoveScan() //refaktor i wrzutka do main.
        {
            var config = _main.GetConfiguration();
            var srcPath = config.SourcePath.ToString();
            var destPath = config.DestinationPath.ToString();
            var personNumber = config.PersonNumber;
            var fingerNumber = config.FingerNumber;
            var stepNumber = config.Step;

            var step = _main.GetScanVariant().Name;
            var weight = "100"; //_serialPort.ReadLine();
            var formatedPerson = "000" + personNumber.ToString();
            var formatedFinger = fingerNumber == 10 ? fingerNumber.ToString() : "0" + fingerNumber.ToString();

            if (personNumber >= 10 && personNumber < 100) formatedPerson = "00" + personNumber.ToString();
            if (personNumber >= 100 && personNumber < 1000) formatedPerson = "0" + personNumber.ToString();

            var fileFolder = Directory.GetDirectories(srcPath).FirstOrDefault();
            var file = Directory.GetFiles(fileFolder).FirstOrDefault(); //null checker
            var newFile = destPath + @"\" + formatedPerson + "_" + formatedFinger + "_" + step + weight + ".bmp";

            var newFingerNumber = fingerNumber == 10 ? 1 : fingerNumber + 1;
            var newStep = fingerNumber == 10 ? stepNumber + 1 : stepNumber;
            var newPersonNumber = stepNumber == 23 ? personNumber + 1 : personNumber;

            File.Move(file, newFile);
            Directory.Delete(fileFolder);

            //Dodać sprawdzacz dla wariantów, waga tylko na pierwszych 2.

            //_serialPort.DiscardOutBuffer();
            _main.ModifyConfiguration(config.SourcePath, config.DestinationPath, config.ArduinoPort, config.ArduinoBaud, newPersonNumber, newFingerNumber, newStep);
            return true;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            //Zrobić pokazywanie dialogów, zależne od configu.
            MoveScan();
            picHolder.Source = _main.GetImage();
            tbScan.Text = _main.GetScanVariant().Description;
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            _main.DeleteScan();
        }
    }
}
