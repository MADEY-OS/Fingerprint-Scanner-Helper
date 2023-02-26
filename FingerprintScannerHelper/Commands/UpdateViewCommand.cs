using FingerprintScannerHelper.ViewModels;
using System;
using System.Windows.Input;

namespace FingerprintScannerHelper.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": _mainViewModel.SelectedViewModel = new HomeViewModel(); break;
                case "Settings": _mainViewModel.SelectedViewModel = new SettingsViewModel(_mainViewModel); break;
                case "Security": _mainViewModel.SelectedViewModel = new SecurityViewModel(); break;
                case "Help": _mainViewModel.SelectedViewModel = new HelpViewModel(); break;
                default: _mainViewModel.SelectedViewModel = new HomeViewModel(); break;
            }
        }
    }
}
