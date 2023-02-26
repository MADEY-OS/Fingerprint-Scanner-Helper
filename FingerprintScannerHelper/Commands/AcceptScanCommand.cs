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
        private readonly HomeViewModel _homeViewModel;

        public AcceptScanCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override void Execute(object? parameter)
        {
            var result = _mainServices.MoveScan();

            if (result is false) MessageBox.Show("Transfer skanu zakończył się niepowodzeniem.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            if (result is true && _securityServices.GetSecurityRule().ShowMovedConfirmation is true) MessageBox.Show("Transfer skanu zakończył się sukcesem!", "Sukces", MessageBoxButton.OK);

            _homeViewModel.VariantDescription = _mainServices.GetScanVariant().Description;
            _homeViewModel.VariantImage = _mainServices.GetImage();
        }
    }
}
