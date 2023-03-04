using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FingerprintScannerHelper.Services
{
    public class SetupServices : ISetupServices
    {
        private readonly string configFile = "config.json";
        private readonly string libFile = "lib.json";
        private readonly string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public void CreateConfiguration()
        {
            if (!File.Exists(configFile))
            {
                var config = new ConfigurationModel
                {
                    SourcePath = baseDir + @"\FSH_src",
                    DestinationPath = baseDir + @"\FSH_dest",
                    PortName = "COM3",
                    PortBaud = "9600",
                    PersonNumber = 1,
                    FingerNumber = 1,
                    Step = 1,
                    UseScale = true,
                    GeneratePersonNumberFolder = true,
                };

                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(configFile, json);
            }
        }

        public void CreateVariantLibrary()
        {
            if (!File.Exists(libFile))
            {
                List<ScanModel> variantList = new List<ScanModel>
                {
                    new ScanModel{Id = 1, Name = "PS", Description="Palec przyłożony normalnie."},
                    new ScanModel{Id = 2, Name = "PL", Description="Palec przyłożony lekko."},
                    new ScanModel{Id = 3, Name = "PF", Description="Palec przyłożony mocno."},
                    new ScanModel{Id = 4, Name = "RR", Description="Palec rolowany w prawo."},
                    new ScanModel{Id = 5, Name = "RL", Description="Palec rolowany w lewo."},
                    new ScanModel{Id = 6, Name = "RTT", Description="Palec rolowany do góry."},
                    new ScanModel{Id = 7, Name = "CCW", Description="Palec obracany przeciwnie do wskazówek zegara."},
                    new ScanModel{Id = 8, Name = "ACW", Description="Palec obracany zgodnie ze wskazówkami zegara."},
                    new ScanModel{Id = 9, Name = "MTT", Description="Palec przesunięty w góre."},
                    new ScanModel{Id = 10, Name = "TB", Description="Palec przesunięty w dół."},
                    new ScanModel{Id = 11, Name = "TL", Description="Palec przesunięty w lewo."},
                    new ScanModel{Id = 12, Name = "TR", Description="Palec przesunięty w prawo."},
                    new ScanModel{Id = 13, Name = "TTL", Description="Palec przesunięty skośnie do góry w lewo."},
                    new ScanModel{Id = 14, Name = "TTR", Description="Palec przesunięty skośnie do góry w prawo."},
                    new ScanModel{Id = 15, Name = "TBL", Description="Palec przesunięty skośnie w dół w lewo."},
                    new ScanModel{Id = 16, Name = "TBR", Description="Palec przesunięty skośnie w dół w prawo."},
                    new ScanModel{Id = 17, Name = "czubek prosto", Description="Czubek palca przyłożony normalnie."},
                    new ScanModel{Id = 18, Name = "czubek lewy", Description="Lewa część czubka palca."},
                    new ScanModel{Id = 19, Name = "czubek prawy", Description="Prawa część czubka palca."},
                    new ScanModel{Id = 20, Name = "czubek rolowany w prawo", Description="Czubek Rolowany w prawo."},
                    new ScanModel{Id = 21, Name = "czubek rolowany w lewo", Description="Czubek Rolowany w lewo."},
                    new ScanModel{Id = 22, Name = "NW", Description="Palec przyłożony normalnie, palec musi być mokry."},
                    new ScanModel{Id = 23, Name = "ND", Description="Palec przyłożony normalnie, palec musi być suchy."}
                };

                string variantJson = JsonConvert.SerializeObject(variantList, Formatting.Indented);
                File.WriteAllText(libFile, variantJson);
            }
        }
    }
}