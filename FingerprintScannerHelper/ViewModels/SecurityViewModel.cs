using FingerprintScannerHelper.Commands;
using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class SecurityViewModel : BaseViewModel
    {
        private readonly ISecurityServices _securityServices = new SecurityServices();

        public ICommand SaveSecurity { get; set; }

        private bool _useLibra;
        public bool UseLibra { get => _useLibra; set { _useLibra = value; OnPropertyChanged(); } }

        private bool _moveConfirm;
        public bool MoveConfirm { get => _moveConfirm; set { _moveConfirm = value; OnPropertyChanged(); } }

        private bool _rejectWarning;
        public bool RejectWarning { get => _rejectWarning; set { _rejectWarning = value; OnPropertyChanged(); } }

        private bool _rejectConfirm;
        public bool RejectConfirm { get => _rejectConfirm; set { _rejectConfirm = value; OnPropertyChanged(); } }

        public SecurityViewModel()
        {
            UseLibra = _securityServices.GetSecurityRule().UseLibra;
            MoveConfirm = _securityServices.GetSecurityRule().ShowMovedConfirmation;
            RejectWarning = _securityServices.GetSecurityRule().ShowRejectWarning;
            RejectConfirm = _securityServices.GetSecurityRule().ShowRejectConfirmation;
            SaveSecurity = new SaveSecurityCommand(this);

        }
    }
}
