using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows;

namespace FingerprintScannerHelper.Services
{
    public class MainServices : IMainServices
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly ISecurityServices _securityServices = new SecurityServices();

        public string GetImage()
        {
            string workingDirectory = Environment.CurrentDirectory;
            try
            {
                var config = _sharedServices.GetConfiguration();
                var fingerNumber = config.FingerNumber.ToString();
                return Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\" + fingerNumber + ".png";
            }
            catch
            {
                MessageBox.Show("Nie można znaleźć wskazówek!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\base.png";
            }
        }

        public ScanModel GetScanVariant()
        {
            var config = _sharedServices.GetConfiguration();
            var lib = _sharedServices.GetLibrary();
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

        public bool DeleteScan()
        {
            var srcPath = _sharedServices.GetConfiguration().SourcePath;
            try
            {
                var fileFolder = Directory.GetDirectories(srcPath).FirstOrDefault();
                Directory.Delete(fileFolder, true);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool MoveScan()
        {
            var config = _sharedServices.GetConfiguration();
            var stepNumber = config.Step;
            var variantName = GetScanVariant().Name;

            if (!Directory.Exists(config.SourcePath) || !Directory.Exists(config.DestinationPath)) return false;

            var fileFolder = Directory.GetDirectories(config.SourcePath).FirstOrDefault();

            if (fileFolder == null) return false;

            var scanFile = Directory.GetFiles(fileFolder).FirstOrDefault();

            if (scanFile == null) return false;

            var newFile = config.DestinationPath + @"\" + config.PersonNumber.ToString().PadLeft(4, '0') + "_" + config.FingerNumber.ToString().PadLeft(2, '0') + "_" + variantName + ".bmp";

            if (config.Step == 2 || config.Step == 3)
            {
                if (_securityServices.GetSecurityRule().UseLibra == true)
                {
                    try
                    {
                        using (SerialPort port = new SerialPort(_sharedServices.GetConfiguration().PortName, int.Parse(_sharedServices.GetConfiguration().PortBaud)))
                        {
                            port.Open();
                            var reading = port.ReadLine();
                            var weight = reading.Remove(reading.Length - 1);
                            newFile = config.DestinationPath + @"\" + config.PersonNumber.ToString().PadLeft(4, '0') + "_" + config.FingerNumber.ToString().PadLeft(2, '0') + "_" + variantName + weight + ".bmp";
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            try
            {
                File.Move(scanFile, newFile);
                Directory.Delete(fileFolder);

                var newFingerNumber = config.FingerNumber == 10 ? 1 : config.FingerNumber + 1;
                var newStep = config.FingerNumber == 10 ? stepNumber + 1 : stepNumber;
                var newPersonNumber = newStep > 23 ? config.PersonNumber + 1 : config.PersonNumber;
                if (newStep > 23) newStep = 1;

                _sharedServices.ModifyConfiguration(config.SourcePath, config.DestinationPath, config.PortName, config.PortBaud, newPersonNumber, newFingerNumber, newStep);
                return true;
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("W folderze istnieje już plik o takiej nazwie. Czy chesz go zamienić?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(newFile);
                    File.Move(scanFile, newFile);
                    Directory.Delete(fileFolder);

                    var newFingerNumber = config.FingerNumber == 10 ? 1 : config.FingerNumber + 1;
                    var newStep = config.FingerNumber == 10 ? stepNumber + 1 : stepNumber;
                    var newPersonNumber = newStep > 23 ? config.PersonNumber + 1 : config.PersonNumber;
                    if (newStep > 23) newStep = 1;

                    _sharedServices.ModifyConfiguration(config.SourcePath, config.DestinationPath, config.PortName, config.PortBaud, newPersonNumber, newFingerNumber, newStep);
                    return true;
                }

                return false;
            }

        }
    }
}
