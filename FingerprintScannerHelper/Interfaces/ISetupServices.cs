namespace FingerprintScannerHelper.Interfaces
{
    public interface ISetupServices
    {
        public void CreateConfiguration();
        void CreateVariantLibrary();
        public string FileDialog();
    }
}
