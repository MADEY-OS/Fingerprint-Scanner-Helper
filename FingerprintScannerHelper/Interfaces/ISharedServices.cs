using FingerprintScannerHelper.Models;
using System.Collections.Generic;

namespace FingerprintScannerHelper.Interfaces
{
    public interface ISharedServices
    {
        public string FileDialog();
        public ConfigurationModel GetConfiguration();
        public bool ModifyConfiguration(string? src, string? dest, string? arduinoPort, string? arduinoBaud, int person, int finger, int step);
        public List<ScanModel> GetLibrary();
        public string GetHelp();
    }
}
