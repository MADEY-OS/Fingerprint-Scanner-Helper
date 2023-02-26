using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;

namespace FingerprintScannerHelper.Commands
{
    public class OpenFileDialogCommand : BaseCommand
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly SetupViewModel? _setupViewModel;
        private readonly SettingsViewModel? _settingsViewModel;
        public OpenFileDialogCommand(object obj)
        {
            switch (obj)
            {
                case SettingsViewModel: _settingsViewModel = (SettingsViewModel?)obj; break;
                case SetupViewModel: _setupViewModel = (SetupViewModel?)obj; break;
                default: break;
            }
        }

        public override void Execute(object? parameter)
        {
            switch (parameter.ToString())
            {
                case "SetupSourcePath": _setupViewModel.SourcePath = _sharedServices.FileDialog(); break;
                case "SetupDestinationPath": _setupViewModel.DestinationPath = _sharedServices.FileDialog(); break;
                case "SettingsSourcePath": _settingsViewModel.SourcePath = _sharedServices.FileDialog(); break;
                case "SettingsDestinationPath": _settingsViewModel.DestinationPath = _sharedServices.FileDialog(); break;
                default: break;
            }
        }
    }
}
