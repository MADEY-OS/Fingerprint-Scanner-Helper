using FingerprintScannerHelper.Models;
using System.Windows.Media.Imaging;

namespace FingerprintScannerHelper.Interfaces
{
    public interface IMainServices
    {
        public BitmapImage GetImage();
        public ScanModel GetScanVariant();
        public void DeleteScan();
        public void MoveScan(string serialReading);
    }
}
