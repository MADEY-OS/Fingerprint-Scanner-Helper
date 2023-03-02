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

        private string _showLibra;
        public string ShowLibra { get => _showLibra; set { _showLibra = value; OnPropertyChanged(); } }

        private string _libraReading;
        public string LibraReading { get => _libraReading; set { _libraReading = value; OnPropertyChanged(); } }

        public HomeViewModel()
        {
            VariantImage = _mainServices.GetImage();
            ShowLibra = _mainServices.GetScanVariant().Id > 3 ? "Collapsed" : "Visible";
            VariantDescription = _mainServices.GetScanVariant().Description;

            RejectCommand = new RejectScanCommand(this);
            AcceptCommand = new AcceptScanCommand(this);
        }
    }
}
