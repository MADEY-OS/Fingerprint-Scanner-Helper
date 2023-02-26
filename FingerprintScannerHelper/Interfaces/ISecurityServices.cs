using FingerprintScannerHelper.Models;

namespace FingerprintScannerHelper.Interfaces
{
    public interface ISecurityServices
    {
        public void CreateSecurityRules();
        public SecurityModel GetSecurityRule();
        public bool ModifySecurityRules(bool useLibra, bool movedConfirmation, bool rejectConfirmation, bool rejectWarning);
    }
}
