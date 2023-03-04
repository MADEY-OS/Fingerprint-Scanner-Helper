using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;
using System.Windows;

namespace FingerprintScannerHelper.Commands
{
    public class AcceptScanCommand : BaseCommand
    {
        private readonly IMainServices _mainServices = new MainServices();
        private readonly ISecurityServices _securityServices = new SecurityServices();
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly HomeViewModel _homeViewModel;

        public AcceptScanCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override void Execute(object? parameter)
        {
            var result = _mainServices.MoveScan(_homeViewModel.Weight);

            if (result is true)
            {
                if (_securityServices.GetSecurityRules().ShowMovedConfirmation is true) MessageBox.Show("Transfer skanu zakończył się sukcesem!", "Sukces", MessageBoxButton.OK);
                _homeViewModel.Weight = null;
                _homeViewModel.VariantDescription = _mainServices.GetScanVariant().Description;
                _homeViewModel.VariantImage = _mainServices.GetImage();
            }
            else
            {
                MessageBox.Show("Transfer skanu zakończył się niepowodzeniem.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _homeViewModel.ShowScale = _mainServices.GetScanVariant().Id > 3 || _sharedServices.GetConfiguration().UseScale is true ? "Collapsed" : "Visible";
        }
    }
}