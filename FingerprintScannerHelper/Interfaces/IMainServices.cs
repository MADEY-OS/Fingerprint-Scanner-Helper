using FingerprintScannerHelper.Models;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace FingerprintScannerHelper.Interfaces
{
    public interface IMainServices
    {
        public ConfigurationModel GetConfiguration();
        public List<ScanModel> GetLibrary();
        public BitmapImage GetImage();
        public ScanModel GetScanVariant();
        public void DeleteScan();
        public void ModifyConfiguration(string? src, string? dest, string? arduinoPort, string? arduinoBaud, int person, int finger, int step);
    }
}
