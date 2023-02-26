using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
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
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.InitialDirectory = baseDir;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return dialog.InitialDirectory.ToString();
            }
            else
            {
                string fileUri = dialog.SelectedPath;
                return fileUri.ToString();
            }
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

        public bool ModifyConfiguration(string src, string dest, string arduinoPort, string arduinoBaud, int person, int finger, int step)
        {
            try
            {
                var config = new ConfigurationModel
                {
                    SourcePath = src != GetConfiguration().SourcePath ? src : GetConfiguration().SourcePath,
                    DestinationPath = dest != GetConfiguration().DestinationPath ? dest : GetConfiguration().DestinationPath,
                    PortName = arduinoPort != GetConfiguration().PortName ? arduinoPort : GetConfiguration().PortName,
                    PortBaud = arduinoBaud != GetConfiguration().PortBaud ? arduinoBaud : GetConfiguration().PortBaud,
                    PersonNumber = person != GetConfiguration().PersonNumber ? person : GetConfiguration().PersonNumber,
                    FingerNumber = finger != GetConfiguration().FingerNumber ? finger : GetConfiguration().FingerNumber,
                    Step = step != GetConfiguration().Step ? step : GetConfiguration().Step
                };

                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(configFile, json);
                return true;
            }
            catch
            {
                return false;
            }
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

        public string GetHelp()
        {
            var result = File.Exists("help.txt") == true ? File.ReadAllText("help.txt") : "Czegoś tu brakuje...";
            return result;
        }
    }
}
