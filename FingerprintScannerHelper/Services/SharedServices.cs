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

        public bool ModifyConfiguration(string? src, string? dest, string? portName, string? portBaud, int? person, int? finger, int? step, bool? useLibra, bool? generatePersonNumberFolder)
        {
            try
            {
                var newConfig = GetConfiguration();
                if (src is not null) newConfig.SourcePath = src;
                if (dest is not null) newConfig.DestinationPath = dest;
                if (portName is not null) newConfig.PortName = portName;
                if (portBaud is not null) newConfig.PortBaud = portBaud;
                if (person is not null) newConfig.PersonNumber = person;
                if (finger is not null) newConfig.FingerNumber = finger;
                if (step is not null) newConfig.Step = step;
                if (useLibra is not null) newConfig.UseLibra = useLibra;
                if (generatePersonNumberFolder is not null) newConfig.GeneratePersonNumberFolder = generatePersonNumberFolder;

                string json = JsonConvert.SerializeObject(newConfig, Formatting.Indented);
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
