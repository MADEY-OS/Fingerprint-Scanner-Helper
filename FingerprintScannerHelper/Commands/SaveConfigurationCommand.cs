using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;
using System;
using System.Windows;

namespace FingerprintScannerHelper.Commands
{
    public class SaveConfigurationCommand : BaseCommand
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly SettingsViewModel _settingsViewModel;
        private readonly MainViewModel _mainViewModel;
        public SaveConfigurationCommand(SettingsViewModel settingsViewModel, MainViewModel mainViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _mainViewModel = mainViewModel;
        }
        public override void Execute(object? parameter)
        {
            var result = _sharedServices.ModifyConfiguration(_settingsViewModel.SourcePath, _settingsViewModel.DestinationPath, _settingsViewModel.PortName, _settingsViewModel.PortBaud, Int32.Parse(_settingsViewModel.PersonNumber), _settingsViewModel.SelectedFinger + 1, _settingsViewModel.SelectedVariant + 1);
            _mainViewModel.SelectedViewModel = new HomeViewModel();
            if (result is true) MessageBox.Show("Konfiguracja pomyślnie zapisana.", "Sukces", MessageBoxButton.OK);
            if (result is false) MessageBox.Show("Nie udało się zapisać konfiguracji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
