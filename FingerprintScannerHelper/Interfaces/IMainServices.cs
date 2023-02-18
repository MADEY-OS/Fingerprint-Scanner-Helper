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
        public string GetScanVariant();
        public void ModifyConfiguration(string? src, string? dest, string? arduino, int person, int finger, int step);
    }
}
