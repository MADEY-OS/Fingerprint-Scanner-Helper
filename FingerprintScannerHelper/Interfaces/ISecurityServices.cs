using FingerprintScannerHelper.Models;

namespace FingerprintScannerHelper.Interfaces
{
    public interface ISecurityServices
    {
        public void CreateSecurityRules();
        public SecurityModel GetSecurityRules();
        public bool ModifySecurityRules(bool? movedConfirmation = null, bool? rejectConfirmation = null, bool? rejectWarning = null);
    }
}
