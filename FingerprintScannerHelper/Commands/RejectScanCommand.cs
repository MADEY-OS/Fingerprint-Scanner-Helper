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
            if (_securityServices.GetSecurityRule().ShowRejectWarning is true)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy chcesz usunąć skan?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes) result = _mainServices.DeleteScan();
            }
            else
            {
                result = _mainServices.DeleteScan();
            }

            if (_securityServices.GetSecurityRule().ShowRejectConfirmation is true && result is true) MessageBox.Show("Pomyślnie usunięto skan.", "Info", MessageBoxButton.OK);
            if (result is false) MessageBox.Show("Nie udało się usunąć skanu.", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
