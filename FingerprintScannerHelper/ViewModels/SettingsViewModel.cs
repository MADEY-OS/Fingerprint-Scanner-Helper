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
        public ICommand ToggleLibraSettings { get; set; }

        private ObservableCollection<string> _scanVariants;

        public ObservableCollection<string> ScanVariants
        { get => _scanVariants; set { _scanVariants = value; } }

        private string _sourcePath;

        public string SourcePath
        { get => _sourcePath; set { _sourcePath = value; OnPropertyChanged(); } }

        private string _destinationPath;

        public string DestinationPath
        { get => _destinationPath; set { _destinationPath = value; OnPropertyChanged(); } }

        private string _portName;

        public string PortName
        { get => _portName; set { _portName = value; OnPropertyChanged(); } }

        private string _portBaud;

        public string PortBaud
        { get => _portBaud; set { _portBaud = value; OnPropertyChanged(); } }

        private string _personNumber;

        public string PersonNumber
        { get => _personNumber; set { _personNumber = value; OnPropertyChanged(); } }

        private int? _selectedVariant;

        public int? SelectedVariant
        { get => _selectedVariant; set { _selectedVariant = value; OnPropertyChanged(); } }

        private int? _selectedFinger;

        public int? SelectedFinger
        { get => _selectedFinger; set { _selectedFinger = value; OnPropertyChanged(); } }

        private string _showLibraSettings;

        public string ShowLibraSettings
        { get => _showLibraSettings; set { _showLibraSettings = value; OnPropertyChanged(); } }

        private bool? _UseScale;

        public bool? UseScale
        { get => _UseScale; set { _UseScale = value; OnPropertyChanged(); } }

        private bool? _generateFolder;

        public bool? GenerateFolder
        { get => _generateFolder; set { _generateFolder = value; OnPropertyChanged(); } }

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
            GenerateFolder = config.GeneratePersonNumberFolder;

            ShowLibraSettings = "Collapsed";
            _UseScale = config.UseScale;
            if (_UseScale is true) ShowLibraSettings = "Visible";

            ToggleLibraSettings = new ToggleLibraSettingsCommand(this);
            OpenFileDialog = new OpenFileDialogCommand(this);
            SaveConfiguration = new SaveConfigurationCommand(this, _mainViewModel);
        }
    }
}