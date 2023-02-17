using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using FingerprintScannerHelper.Services;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{
    public partial class SetupWindow : Window
    {
        private readonly ISetupServices _services = new SetupServices();

        private string configFile = "config.json";
        private string libFile = "lib.json";
        private readonly string initDir = "C:\\Users";

        public SetupWindow()
        {
            InitializeComponent();
            Setup(configFile);
        }

        private void Setup(string configFile)
        {
            if (File.Exists(configFile))
            {
                var jsonFile = File.ReadAllText(configFile);

                ConfigurationModel configJson = JsonConvert.DeserializeObject<ConfigurationModel>(jsonFile);
                TBSrc.Text = configJson.SourcePath;
                TBDest.Text = configJson.DestinationPath;
                TBArduino.Text = configJson.ArduinoPort;
            }
            else
            {
                TBSrc.Text = initDir;
                TBDest.Text = initDir;
                TBArduino.Text = "8000";
            }
        }

        private string FileDialogHandler()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = initDir;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string fileUri = new string(dialog.FileName);
                return fileUri.ToString();
            }

            return dialog.InitialDirectory.ToString();
        }

        public void ConfigFileHelper(string src, string dest, string arduino)
        {
            string fileName = configFile;
            string newSrc = src;
            string newDest = dest;
            string newArduino = arduino;
            int newPerson = 1;
            int newStep = 1;
            int newFingerNumber = 1;

            if (File.Exists(fileName))
            {
                var jsonFile = File.ReadAllText(fileName);
                ConfigurationModel configJson = JsonConvert.DeserializeObject<ConfigurationModel>(jsonFile);

                newSrc = src != configJson.SourcePath ? src : configJson.SourcePath;
                newDest = dest != configJson.DestinationPath ? dest : configJson.DestinationPath;
                newArduino = arduino != configJson.ArduinoPort ? arduino : configJson.ArduinoPort;
                newPerson = configJson.PersonNumber;
                newStep = configJson.Step;
                newFingerNumber = configJson.FingerNumber;
            }

            var config = new ConfigurationModel
            {
                SourcePath = newSrc,
                DestinationPath = newDest,
                ArduinoPort = newArduino,
                PersonNumber = newPerson,
                Step = newStep,
                FingerNumber = newFingerNumber
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void CreateWariantLibrary()
        {
            string wariantLibrary = libFile;

            if (!File.Exists(wariantLibrary))
            {
                List<ScanModel> variantList = new List<ScanModel>
                {
                    new ScanModel{Id = 1, Name = "PS", Description="Palec przyłożony normalnie."},
                    new ScanModel{Id = 2, Name = "PL", Description="Palec przyłożony lekko."},
                    new ScanModel{Id = 3, Name = "PF", Description="Palec przyłożony mocno."},
                    new ScanModel{Id = 4, Name = "RR", Description="Palec rolowany w prawo."},
                    new ScanModel{Id = 5, Name = "RL", Description="Palec rolowany w lewo."},
                    new ScanModel{Id = 6, Name = "RTT", Description="Palec rolowany do góry."},
                    new ScanModel{Id = 7, Name = "CCW", Description="Palec obracany przeciwnie do wskazówek zegara."},
                    new ScanModel{Id = 8, Name = "ACW", Description="Palec obracany zgodnie ze wskazówkami zegara."},
                    new ScanModel{Id = 9, Name = "MTT", Description="Palec przesunięty w góre."},
                    new ScanModel{Id = 10, Name = "TB", Description="Palec przesunięty w dół."},
                    new ScanModel{Id = 11, Name = "TL", Description="Palec przesunięty w lewo."},
                    new ScanModel{Id = 12, Name = "TR", Description="Palec przesunięty w prawo."},
                    new ScanModel{Id = 13, Name = "TTL", Description="Palec przesunięty skośnie do góry w lewo."},
                    new ScanModel{Id = 14, Name = "TTR", Description="Palec przesunięty skośnie do góry w prawo."},
                    new ScanModel{Id = 15, Name = "TBL", Description="Palec przesunięty skośnie w dół w lewo."},
                    new ScanModel{Id = 16, Name = "TBR", Description="Palec przesunięty skośnie w dół w prawo."},
                    new ScanModel{Id = 17, Name = "czubek prosto", Description="Czubek palca przyłożony normalnie."},
                    new ScanModel{Id = 18, Name = "czubek lewy", Description="Lewa część czubka palca."},
                    new ScanModel{Id = 19, Name = "czubek prawy", Description="Prawa część czubka palca."},
                    new ScanModel{Id = 20, Name = "czubek rolowany w prawo", Description="Czubek Rolowany w prawo."},
                    new ScanModel{Id = 21, Name = "czubek rolowany w lewo", Description="Czubek Rolowany w lewo."},
                    new ScanModel{Id = 22, Name = "NW", Description="Palec przyłożony normalnie, palec musi być mokry."},
                    new ScanModel{Id = 23, Name = "ND", Description="Palec przyłożony normalnie, palec musi być suchy."}
                };

                string variantJson = JsonConvert.SerializeObject(variantList, Formatting.Indented);
                File.WriteAllText(wariantLibrary, variantJson);
            }
        }

        private void BtnSrc_Click(object sender, RoutedEventArgs e)
        {
            TBSrc.Text = FileDialogHandler();
        }

        private void BtnDest_Click(object sender, RoutedEventArgs e)
        {
            TBDest.Text = FileDialogHandler();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            ConfigFileHelper(TBSrc.Text, TBDest.Text, TBArduino.Text);
            CreateWariantLibrary();
            Close();
        }
    }
}
