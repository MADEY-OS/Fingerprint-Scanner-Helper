using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMainServices _mainServices = new MainServices();

        public ICommand RejectCommand { get; set; }
        public ICommand AcceptCommand { get; set; }

        private string _variantImage;
        public string VariantImage { get => _variantImage; set { _variantImage = value; OnPropertyChanged(); } }

        private string _variantDescription;
        public string VariantDescription { get => _variantDescription; set { _variantDescription = value; OnPropertyChanged(); } }

        private bool _isConnectedToLibra = true;
        public bool IsConnectedToLibra { get => _isConnectedToLibra; set { _isConnectedToLibra = value; OnPropertyChanged(); } }

        private string _serialReading;
        public string SerialReading { get => _serialReading; set { _serialReading = value; OnPropertyChanged(); } }

        private bool _clearReading;
        public bool ClearReading { get => _clearReading; set { _clearReading = value; OnPropertyChanged(); } }

        public HomeViewModel()
        {
            VariantImage = _mainServices.GetImage();
            VariantDescription = _mainServices.GetScanVariant().Description;

            RejectCommand = new RejectScanCommand(this);
            AcceptCommand = new AcceptScanCommand(this);
        }
    }
}
