using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;
using System.IO;

namespace FingerprintScannerHelper.Commands
{
    public class SaveSetupCommand : BaseCommand
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
        private readonly ISetupServices _setupServices = new SetupServices();
        private readonly ISecurityServices _securityServices = new SecurityServices();

        private readonly SetupViewModel _setupViewModel;
        private readonly MainViewModel _mainViewModel;

        public SaveSetupCommand(SetupViewModel setupViewModel, MainViewModel mainViewModel)
        {
            _setupViewModel = setupViewModel;
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            var config = _sharedServices.GetConfiguration();
            _sharedServices.ModifyConfiguration(_setupViewModel.SourcePath, _setupViewModel.DestinationPath, _setupViewModel.PortName, _setupViewModel.PortBaud, config.PersonNumber, config.FingerNumber, config.Step);

            if (!File.Exists("lib.json")) _setupServices.CreateVariantLibrary();
            if (!File.Exists("security.json")) _securityServices.CreateSecurityRules();

            _mainViewModel.SelectedViewModel = new HomeViewModel();
            _mainViewModel.MenuVisibility = "Visible";
        }
    }
}
