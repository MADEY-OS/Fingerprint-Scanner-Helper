using FingerprintScannerHelper.ViewModels;

namespace FingerprintScannerHelper.Commands
{
    public class ToggleLibraSettingsCommand : BaseCommand
    {
        private readonly SetupViewModel? _setupViewModel;
        private readonly SettingsViewModel? _settingsViewModel;

        public ToggleLibraSettingsCommand(object obj)
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
                case "Settings": _settingsViewModel.ShowLibraSettings = _settingsViewModel.UseScale is true ? "Visible" : "Collapsed"; break;
                case "Setup": _setupViewModel.ShowLibraSettings = _setupViewModel.UseScale is true ? "Visible" : "Collapsed"; break;
            }
        }
    }
}
