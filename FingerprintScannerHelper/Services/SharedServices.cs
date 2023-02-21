using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FingerprintScannerHelper.Services
{
    public class SharedServices : ISharedServices
    {
        private readonly string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string configFile = "config.json";
        private readonly string libFile = "lib.json";
        public string FileDialog()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = baseDir;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string fileUri = new string(dialog.FileName);
                return fileUri.ToString();
            }

            return dialog.InitialDirectory.ToString();
        }

        public ConfigurationModel GetConfiguration()
        {
            try
            {
                var jsonFile = File.ReadAllText(configFile);
                return JsonConvert.DeserializeObject<ConfigurationModel>(jsonFile);
            }
            catch
            {
                return null;
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

        public List<ScanModel> GetLibrary()
        {
            try
            {
                var jsonFile = File.ReadAllText(libFile);
                return JsonConvert.DeserializeObject<List<ScanModel>>(jsonFile);
            }
            catch
            {
                MessageBox.Show("Nie można znaleźć biblioteki!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
