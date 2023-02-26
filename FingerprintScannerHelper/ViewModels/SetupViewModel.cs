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
        private readonly MainViewModel _mainViewModel;

        public ICommand OpenFileDialog { get; set; }
        public ICommand SaveConfiguration { get; set; }

        private string _sourcePath;
        public string SourcePath { get => _sourcePath; set { _sourcePath = value; OnPropertyChanged(); } }

        private string _destinationPath;
        public string DestinationPath { get => _destinationPath; set { _destinationPath = value; OnPropertyChanged(); } }

        private string _portName;
        public string PortName { get => _portName; set { _portName = value; OnPropertyChanged(); } }

        private string _portBaud;
        public string PortBaud { get => _portBaud; set { _portBaud = value; OnPropertyChanged(); } }

        public SetupViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            if (!File.Exists("config.json")) _setupServices.CreateConfiguration();

            var config = _sharedServices.GetConfiguration();
            SourcePath = config.SourcePath;
            DestinationPath = config.DestinationPath;
            PortName = config.PortName;
            PortBaud = config.PortBaud;

            OpenFileDialog = new OpenFileDialogCommand(this);
            SaveConfiguration = new SaveSetupCommand(this, _mainViewModel);
        }

    }
}
