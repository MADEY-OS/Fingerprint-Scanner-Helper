using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (!File.Exists(libFile)) return null;

            var jsonFile = File.ReadAllText(libFile);

            List<ScanModel> libJson = JsonConvert.DeserializeObject<List<ScanModel>>(jsonFile);

            return libJson;
        }

        public BitmapImage GetImage()
        {
            if (GetConfiguration() is null) return new BitmapImage(new Uri(@"Images/base.png", UriKind.Relative));

            var fingerNumber = GetConfiguration().FingerNumber.ToString();

            return new BitmapImage(new Uri(@"Images/" + fingerNumber + ".png", UriKind.Relative));
        }

        public string GetScanVariant()
        {
            var lib = GetLibrary();
            var step = GetConfiguration().Step;

            return lib.FirstOrDefault(s => s.Id == step).Description.ToString();
        }

        public void ModifyConfiguration(string? src, string? dest, string? arduino, int person, int finger, int step)
        {
            var newSrc = src != GetConfiguration().SourcePath ? src : GetConfiguration().SourcePath;
            var newDest = dest != GetConfiguration().DestinationPath ? dest : GetConfiguration().DestinationPath;
            var newArduino = arduino != GetConfiguration().ArduinoPort ? arduino : GetConfiguration().ArduinoPort;
            var newPerson = person != GetConfiguration().PersonNumber ? person : GetConfiguration().PersonNumber;
            var newFinger = finger != GetConfiguration().FingerNumber ? finger : GetConfiguration().FingerNumber;
            var newStep = step != GetConfiguration().Step ? step : GetConfiguration().Step;

            var config = new ConfigurationModel
            {
                SourcePath = newSrc,
                DestinationPath = newDest,
                ArduinoPort = newArduino,
                PersonNumber = newPerson,
                FingerNumber = newFinger,
                Step = newStep
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }
    }
}
