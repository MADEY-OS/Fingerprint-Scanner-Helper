using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.IO;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly ISetupServices _setupServices = new SetupServices();
        private readonly ISecurityServices _securityServices = new SecurityServices();
        private readonly MainViewModel _mainViewModel;

        public ICommand OpenFileDialog { get; set; }
        public ICommand SaveConfiguration { get; set; }
        public ICommand ToggleLibraSettings { get; set; }

        private string _sourcePath;
        public string SourcePath { get => _sourcePath; set { _sourcePath = value; OnPropertyChanged(); } }

        private string _destinationPath;
        public string DestinationPath { get => _destinationPath; set { _destinationPath = value; OnPropertyChanged(); } }

        private string _portName;
        public string PortName { get => _portName; set { _portName = value; OnPropertyChanged(); } }

        private string _portBaud;
        public string PortBaud { get => _portBaud; set { _portBaud = value; OnPropertyChanged(); } }

        private bool? _useLibra;
        public bool? UseLibra { get => _useLibra; set { _useLibra = value; OnPropertyChanged(); } }

        private string _showLibraSettings;
        public string ShowLibraSettings { get => _showLibraSettings; set { _showLibraSettings = value; OnPropertyChanged(); } }

        public SetupViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            if (!File.Exists("config.json")) _setupServices.CreateConfiguration();
            if (!File.Exists("security.json")) _securityServices.CreateSecurityRules();
            if (!File.Exists("lib.json")) _setupServices.CreateVariantLibrary();

            var config = _sharedServices.GetConfiguration();
            SourcePath = config.SourcePath;
            DestinationPath = config.DestinationPath;
            PortName = config.PortName;
            PortBaud = config.PortBaud;
            ShowLibraSettings = "Collapsed";

            _useLibra = config.UseLibra;
            if (_useLibra is true) ShowLibraSettings = "Visible";

            OpenFileDialog = new OpenFileDialogCommand(this);
            ToggleLibraSettings = new ToggleLibraSettingsCommand(this);
            SaveConfiguration = new SaveSetupCommand(this, _mainViewModel);
        }

    }
}
