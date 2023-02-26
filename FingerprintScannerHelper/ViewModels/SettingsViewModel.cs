using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly MainViewModel _mainViewModel;
        public ICommand OpenFileDialog { get; set; }
        public ICommand SaveConfiguration { get; set; }

        private ObservableCollection<string> _scanVariants;

        private string _sourcePath;
        private string _destinationPath;
        private string _portName;
        private string _portBaud;
        private string _personNumber;
        private int _selectedVariant;
        private int _selectedFinger;

        public string SourcePath { get => _sourcePath; set { _sourcePath = value; OnPropertyChanged(); } }
        public string DestinationPath { get => _destinationPath; set { _destinationPath = value; OnPropertyChanged(); } }
        public string PortName { get => _portName; set { _portName = value; OnPropertyChanged(); } }
        public string PortBaud { get => _portBaud; set { _portBaud = value; OnPropertyChanged(); } }
        public string PersonNumber { get => _personNumber; set { _personNumber = value; OnPropertyChanged(); } }
        public ObservableCollection<string> ScanVariants { get => _scanVariants; set { _scanVariants = value; } }
        public int SelectedVariant { get => _selectedVariant; set { _selectedVariant = value; OnPropertyChanged(); } }
        public int SelectedFinger { get => _selectedFinger; set { _selectedFinger = value; OnPropertyChanged(); } }

        public SettingsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            var config = _sharedServices.GetConfiguration();
            var lib = _sharedServices.GetLibrary();

            ObservableCollection<string> variants = new ObservableCollection<string>();
            lib.ForEach(x => variants.Add(x.Description));

            SourcePath = config.SourcePath;
            DestinationPath = config.DestinationPath;
            PortName = config.PortName;
            PortBaud = config.PortBaud;
            PersonNumber = config.PersonNumber.ToString();
            ScanVariants = variants;
            SelectedVariant = config.Step - 1;
            SelectedFinger = config.FingerNumber - 1;

            OpenFileDialog = new OpenFileDialogCommand(this);
            SaveConfiguration = new SaveConfigurationCommand(this, _mainViewModel);
        }
    }
}
