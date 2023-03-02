using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;
using System.Windows;

namespace FingerprintScannerHelper.Commands
{
    public class RejectScanCommand : BaseCommand
    {
        private readonly IMainServices _mainServices = new MainServices();
        private readonly ISecurityServices _securityServices = new SecurityServices();
        private readonly HomeViewModel _homeViewModel;

        public RejectScanCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override void Execute(object? parameter)
        {
            var result = false;
            if (_securityServices.GetSecurityRules().ShowRejectWarning is true)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć skan?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes) result = _mainServices.DeleteScan();
            }
            else
            {
                result = _mainServices.DeleteScan();
            }

            if (_securityServices.GetSecurityRules().ShowRejectConfirmation is true && result is true) MessageBox.Show("Usuwanie skanu zakończyło się sukcesem.", "Info", MessageBoxButton.OK);
            if (result is false) MessageBox.Show("Usuwanie skanu zakończyło się niepowodzeniem.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
