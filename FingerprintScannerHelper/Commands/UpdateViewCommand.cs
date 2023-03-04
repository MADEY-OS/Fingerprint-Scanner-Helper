using FingerprintScannerHelper.ViewModels;

namespace FingerprintScannerHelper.Commands
{
    public class UpdateViewCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": _mainViewModel.SelectedViewModel = new HomeViewModel(); break;
                case "Settings": _mainViewModel.SelectedViewModel = new SettingsViewModel(_mainViewModel); break;
                case "Security": _mainViewModel.SelectedViewModel = new SecurityViewModel(_mainViewModel); break;
                case "Help": _mainViewModel.SelectedViewModel = new HelpViewModel(); break;
                default: _mainViewModel.SelectedViewModel = new HomeViewModel(); break;
            }
        }
    }
}