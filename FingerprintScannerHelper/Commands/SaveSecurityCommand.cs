using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;
using System.Windows;

namespace FingerprintScannerHelper.Commands
{
    public class SaveSecurityCommand : BaseCommand
    {
        private readonly ISecurityServices _securityServices = new SecurityServices();

        private readonly SecurityViewModel _securityViewModel;
        private readonly MainViewModel _mainViewModel;

        public SaveSecurityCommand(SecurityViewModel securityViewModel, MainViewModel mainViewModel)
        {
            _securityViewModel = securityViewModel;
            _mainViewModel = mainViewModel;
        }


        public override void Execute(object? parameter)
        {
            var result = _securityServices.ModifySecurityRules(_securityViewModel.MoveConfirm, _securityViewModel.RejectConfirm, _securityViewModel.RejectWarning);
            _mainViewModel.SelectedViewModel = new HomeViewModel();
            if (result is true) MessageBox.Show("Pomyślnie zapisano ustawienia.", "Sukces", MessageBoxButton.OK);
            if (result is false) MessageBox.Show("Nie udało się zapisać zabezpieczeń.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
