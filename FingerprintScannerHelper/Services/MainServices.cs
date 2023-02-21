using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FingerprintScannerHelper.Services
{
    public class MainServices : IMainServices
    {
        private readonly ISharedServices _shared = new SharedServices();

        public BitmapImage GetImage()
        {
            var config = _shared.GetConfiguration();
            try
            {
                var fingerNumber = config.FingerNumber.ToString();
                return new BitmapImage(new Uri(@"Images/" + fingerNumber + ".png", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Nie można znaleźć wskazówek!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return new BitmapImage(new Uri(@"Images/base.png", UriKind.Relative));
            }
        }

        public ScanModel GetScanVariant()
        {
            var config = _shared.GetConfiguration();
            var lib = _shared.GetLibrary();
            try
            {
                var step = config.Step;
                return lib.FirstOrDefault(s => s.Id == step);
            }
            catch
            {
                MessageBox.Show("Nie można znaleźć wariantu skanowania!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteScan()
        {
            var config = _shared.GetConfiguration();
            var srcPath = config.SourcePath.ToString();
            try
            {
                var fileFolder = Directory.GetDirectories(srcPath).FirstOrDefault();
                Directory.Delete(fileFolder, true);
            }
            catch
            {
                MessageBox.Show("Ścieżka źródłowa jest pusta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void MoveScan(string serialReading)
        {

            var config = _shared.GetConfiguration();
            var srcPath = config.SourcePath.ToString();
            if (!Directory.Exists(srcPath)) Directory.CreateDirectory(srcPath);
            var destPath = config.DestinationPath.ToString();
            if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);
            var personNumber = config.PersonNumber;
            var fingerNumber = config.FingerNumber;
            var stepNumber = config.Step;
            var variantName = GetScanVariant().Name;
            var weight = serialReading.Remove(serialReading.Length - 1);

            var fileFolder = Directory.GetDirectories(srcPath).FirstOrDefault();

            if (fileFolder != null)
            {
                var file = Directory.GetFiles(fileFolder).FirstOrDefault();

                var formatedFinger = fingerNumber == 10 ? fingerNumber.ToString() : "0" + fingerNumber.ToString();
                var formatedPerson = "000" + personNumber.ToString();

                if (personNumber >= 10 && personNumber < 100) formatedPerson = "00" + personNumber.ToString();
                if (personNumber >= 100 && personNumber < 1000) formatedPerson = "0" + personNumber.ToString();

                var newFile = destPath + @"\" + formatedPerson + "_" + formatedFinger + "_" + variantName + ".bmp";
                if (config.Step == 2 || config.Step == 3) newFile = destPath + @"\" + formatedPerson + "_" + formatedFinger + "_" + variantName + weight + ".bmp";

                try
                {
                    File.Move(file, newFile);
                    Directory.Delete(fileFolder);

                    var newFingerNumber = fingerNumber == 10 ? 1 : fingerNumber + 1;
                    var newStep = fingerNumber == 10 ? stepNumber + 1 : stepNumber;
                    var newPersonNumber = newStep > 23 ? personNumber + 1 : personNumber;
                    if (newStep > 23) newStep = 1;

                    _shared.ModifyConfiguration(config.SourcePath, config.DestinationPath, config.ArduinoPort, config.ArduinoBaud, newPersonNumber, newFingerNumber, newStep);
                }
                catch
                {
                    MessageBoxResult result = MessageBox.Show("W folderze istnieje już plik o takiej nazwie. Czy chesz go zamienić?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        File.Delete(newFile);
                        File.Move(file, newFile);
                        Directory.Delete(fileFolder);

                        var newFingerNumber = fingerNumber == 10 ? 1 : fingerNumber + 1;
                        var newStep = fingerNumber == 10 ? stepNumber + 1 : stepNumber;
                        var newPersonNumber = newStep > 23 ? personNumber + 1 : personNumber;
                        if (newStep > 23) newStep = 1;

                        _shared.ModifyConfiguration(config.SourcePath, config.DestinationPath, config.ArduinoPort, config.ArduinoBaud, newPersonNumber, newFingerNumber, newStep);
                    }
                }
            }
            else
            {
                MessageBox.Show("W folderze źródłowym nie ma skanów.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
