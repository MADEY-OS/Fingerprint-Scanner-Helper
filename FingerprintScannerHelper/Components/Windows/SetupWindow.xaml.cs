using FingerprintScannerHelper.Models;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public SetupWindow()
        {
            InitializeComponent();
            string fileName = "config.json";
            if (File.Exists(fileName))
            {
                var jsonFile = File.ReadAllText(fileName);
                ConfigurationModel configJson = JsonSerializer.Deserialize<ConfigurationModel>(jsonFile);
                TBSrc.Text = configJson.SourcePath;
                TBDest.Text = configJson.DestinationPath;
                TBArduino.Text = configJson.ArduinoPort;
            }
            else
            {
                TBSrc.Text = "C:\\Users";
                TBDest.Text = "C:\\Users";
                TBArduino.Text = "8000";
            }
        }

        private string FileDialogHandler()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
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
            string fileName = "config.json";
            string newSrc = src;
            string newDest = dest;
            string newArduino = arduino;
            int newPerson = 1;
            int newStep = 1;

            if (File.Exists(fileName))
            {
                var jsonFile = File.ReadAllText(fileName);
                ConfigurationModel configJson = JsonSerializer.Deserialize<ConfigurationModel>(jsonFile);

                newSrc = src != configJson.SourcePath ? src : configJson.SourcePath;
                newDest = dest != configJson.DestinationPath ? dest : configJson.DestinationPath;
                newArduino = arduino != configJson.ArduinoPort ? arduino : configJson.ArduinoPort;
                newPerson = configJson.PersonNumber;
                newStep = configJson.Step;
            }

            var config = new ConfigurationModel
            {
                SourcePath = newSrc,
                DestinationPath = newDest,
                ArduinoPort = newArduino,
                PersonNumber = newPerson,
                Step = newStep
            };

            string json = JsonSerializer.Serialize(config);
            File.WriteAllText(fileName, json);
        }

        private void BtnSrc_Click(object sender, RoutedEventArgs e)
        {
            TBSrc.Text = FileDialogHandler();
        }

        private void BtnDest_Click(object sender, RoutedEventArgs e)
        {
            TBDest.Text = FileDialogHandler();
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            ConfigFileHelper(TBSrc.Text, TBDest.Text, TBArduino.Text);
            Close();
        }
    }
}
