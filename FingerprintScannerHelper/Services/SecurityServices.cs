using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Models;
using Newtonsoft.Json;
using System.IO;

namespace FingerprintScannerHelper.Services
{
    public class SecurityServices : ISecurityServices
    {
        private readonly string secFile = "security.json";

        public void CreateSecurityRules()
        {
            var rules = new SecurityModel
            {
                ShowMovedConfirmation = true,
                ShowRejectConfirmation = true,
                ShowRejectWarning = true,
            };

            string json = JsonConvert.SerializeObject(rules, Formatting.Indented);
            File.WriteAllText(secFile, json);
        }

        public SecurityModel GetSecurityRules()
        {
            var jsonFile = File.ReadAllText(secFile);
            return JsonConvert.DeserializeObject<SecurityModel>(jsonFile);
        }

        public bool ModifySecurityRules(bool? movedConfirmation, bool? rejectConfirmation, bool? rejectWarning)
        {
            try
            {
                SecurityModel newRules = GetSecurityRules();
                if (movedConfirmation is not null) newRules.ShowMovedConfirmation = movedConfirmation;
                if (rejectConfirmation is not null) newRules.ShowRejectConfirmation = rejectConfirmation;
                if (rejectWarning is not null) newRules.ShowRejectWarning = rejectWarning;

                string json = JsonConvert.SerializeObject(newRules, Formatting.Indented);
                File.WriteAllText(secFile, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
