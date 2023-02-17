namespace FingerprintScannerHelper.Models
{
    public class ConfigurationModel
    {
        public string? SourcePath { get; set; }
        public string? DestinationPath { get; set; }
        public string? ArduinoPort { get; set; }
        public int PersonNumber { get; set; }
        public int FingerNumber { get; set; }
        public int Step { get; set; }
    }
}
