using FingerprintScannerHelper.Models;

namespace FingerprintScannerHelper.Interfaces
{
    public interface IMainServices
    {
        public string GetImage();

        public ScanModel GetScanVariant();

        public bool DeleteScan();

        public bool MoveScan(string weight);
    }
}