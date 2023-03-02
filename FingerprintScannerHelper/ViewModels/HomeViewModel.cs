using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMainServices _mainServices = new MainServices();
        private readonly ISharedServices _sharedServices = new SharedServices();

        public ICommand RejectCommand { get; set; }
        public ICommand AcceptCommand { get; set; }

        private string _variantImage;
        public string VariantImage { get => _variantImage; set { _variantImage = value; OnPropertyChanged(); } }

        private string _variantDescription;
        public string VariantDescription { get => _variantDescription; set { _variantDescription = value; OnPropertyChanged(); } }

        private string _showScale;
        public string ShowScale { get => _showScale; set { _showScale = value; OnPropertyChanged(); } }

        private string _weight;
        public string Weight { get => _weight; set { _weight = value; OnPropertyChanged(); } }

        public HomeViewModel()
        {
            VariantImage = _mainServices.GetImage();
            ShowScale = _mainServices.GetScanVariant().Id > 3 || _sharedServices.GetConfiguration().UseScale is true ? "Collapsed" : "Visible";
            VariantDescription = _mainServices.GetScanVariant().Description;

            RejectCommand = new RejectScanCommand(this);
            AcceptCommand = new AcceptScanCommand(this);
        }
    }
}
