using FingerprintScannerHelper.Models;

namespace FingerprintScannerHelper.Interfaces
{
    public interface ISecurityServices
    {
        public void CreateSecurityRules();
        public SecurityModel GetSecurityRule();
        public void ModifySecurityRules(bool useLibra, bool libraLock, bool movedConfirmation, bool rejectConfirmation, bool rejectWarning);
    }
}
