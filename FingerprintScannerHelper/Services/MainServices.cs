using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FingerprintScannerHelper.Services
{
    public class MainServices : IMainServices
    {
        private readonly string configFile = "config.json";
        private readonly string libFile = "lib.json";

        public ConfigurationModel GetConfiguration()
        {
            if (!File.Exists(configFile)) return null;

            var jsonFile = File.ReadAllText(configFile);

            ConfigurationModel configJson = JsonConvert.DeserializeObject<ConfigurationModel>(jsonFile);

            return configJson;
        }

        public List<ScanModel> GetLibrary()
        {
            try
            {
                var jsonFile = File.ReadAllText(libFile);
                //List<ScanModel> libJson = JsonConvert.DeserializeObject<List<ScanModel>>(jsonFile);
                return JsonConvert.DeserializeObject<List<ScanModel>>(jsonFile); ;
            }
            catch
            {
                MessageBox.Show("Nie można znaleźć biblioteki!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public BitmapImage GetImage()
        {
            if (GetConfiguration() is null) return new BitmapImage(new Uri(@"Images/base.png", UriKind.Relative));

            var fingerNumber = GetConfiguration().FingerNumber.ToString();

            return new BitmapImage(new Uri(@"Images/" + fingerNumber + ".png", UriKind.Relative));
        }

        public ScanModel GetScanVariant()
        {
            var lib = GetLibrary();
            var step = GetConfiguration().Step;
            return lib.FirstOrDefault(s => s.Id == step);
        }

        public void DeleteScan()
        {
            var srcPath = GetConfiguration().SourcePath.ToString();
            try
            {
                var fileFolder = Directory.GetDirectories(srcPath).FirstOrDefault();
                Directory.Delete(fileFolder, true);
                //dorobić sprawdzacz czy folder ma w środku plik bmp!
            }
            catch
            {
                MessageBox.Show("Ścieżka źródłowa jest pusta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ModifyConfiguration(string? src, string? dest, string? arduinoPort, string? arduinoBaud, int person, int finger, int step)
        {
            var config = new ConfigurationModel
            {
                SourcePath = src != GetConfiguration().SourcePath ? src : GetConfiguration().SourcePath,
                DestinationPath = dest != GetConfiguration().DestinationPath ? dest : GetConfiguration().DestinationPath,
                ArduinoPort = arduinoPort != GetConfiguration().ArduinoPort ? arduinoPort : GetConfiguration().ArduinoPort,
                ArduinoBaud = arduinoBaud != GetConfiguration().ArduinoBaud ? arduinoBaud : GetConfiguration().ArduinoBaud,
                PersonNumber = person != GetConfiguration().PersonNumber ? person : GetConfiguration().PersonNumber,
                FingerNumber = finger != GetConfiguration().FingerNumber ? finger : GetConfiguration().FingerNumber,
                Step = step != GetConfiguration().Step ? step : GetConfiguration().Step
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }
    }
}
