namespace FingerprintScannerHelper.Models
{
    public class ConfigurationModel
    {
        public string? SourcePath { get; set; }
        public string? DestinationPath { get; set; }
        public string? PortName { get; set; }
        public string? PortBaud { get; set; }
        public int? PersonNumber { get; set; }
        public int? FingerNumber { get; set; }
        public int? Step { get; set; }
        public bool? UseLibra { get; set; }
        public bool? GeneratePersonNumberFolder { get; set; }
    }
}
