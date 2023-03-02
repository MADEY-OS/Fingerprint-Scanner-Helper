using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class SecurityViewModel : BaseViewModel
    {
        private readonly ISecurityServices _securityServices = new SecurityServices();
        private readonly MainViewModel _mainViewModel;

        public ICommand SaveSecurity { get; set; }

        private bool? _moveConfirm;
        public bool? MoveConfirm { get => _moveConfirm; set { _moveConfirm = value; OnPropertyChanged(); } }

        private bool? _rejectWarning;
        public bool? RejectWarning { get => _rejectWarning; set { _rejectWarning = value; OnPropertyChanged(); } }

        private bool? _rejectConfirm;
        public bool? RejectConfirm { get => _rejectConfirm; set { _rejectConfirm = value; OnPropertyChanged(); } }

        public SecurityViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            var rules = _securityServices.GetSecurityRules();
            MoveConfirm = rules.ShowMovedConfirmation;
            RejectWarning = rules.ShowRejectWarning;
            RejectConfirm = rules.ShowRejectConfirmation;
            SaveSecurity = new SaveSecurityCommand(this, _mainViewModel);
        }
    }
}
