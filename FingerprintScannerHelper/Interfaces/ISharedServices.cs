using FingerprintScannerHelper.Models;
using System.Collections.Generic;

namespace FingerprintScannerHelper.Interfaces
{
    public interface ISharedServices
    {
        public string FileDialog();
        public ConfigurationModel GetConfiguration();
        public bool ModifyConfiguration(string? src = null, string? dest = null, string? portName = null, string? portBaud = null, int? person = null, int? finger = null, int? step = null, bool? UseScale = null, bool? generatePersonNumberFolder = null);
        public List<ScanModel> GetLibrary();
        public string GetHelp();
    }
}
