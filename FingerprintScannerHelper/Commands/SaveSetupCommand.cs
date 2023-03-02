using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using FingerprintScannerHelper.ViewModels;

namespace FingerprintScannerHelper.Commands
{
    public class SaveSetupCommand : BaseCommand
    {
        private readonly ISharedServices _sharedServices = new SharedServices();
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
            _sharedServices.ModifyConfiguration(src: _setupViewModel.SourcePath, dest: _setupViewModel.DestinationPath, portName: _setupViewModel.PortName, portBaud: _setupViewModel.PortBaud, UseScale: _setupViewModel.UseScale);
            _mainViewModel.SelectedViewModel = new HomeViewModel();
            _mainViewModel.MenuVisibility = "Visible";
        }
    }
}
