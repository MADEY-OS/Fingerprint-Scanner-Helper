using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;

namespace FingerprintScannerHelper.ViewModels
{
    public class HelpViewModel : BaseViewModel
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private string _helpContent;

        public string HelpContent
        { get => _helpContent; set { _helpContent = value; OnPropertyChanged(); } }

        public HelpViewModel()
        {
            HelpContent = _sharedServices.GetHelp();
        }
    }
}