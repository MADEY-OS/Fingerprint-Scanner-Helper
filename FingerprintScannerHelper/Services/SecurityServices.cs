﻿using FingerprintScannerHelper.Interfaces;
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
                UseLibra = true,
                LibraLock = true,
                ShowMovedConfirmation = true,
                ShowRejectConfirmation = true,
                ShowRejectWarning = true,
            };
            string json = JsonConvert.SerializeObject(rules, Formatting.Indented);
            File.WriteAllText(secFile, json);
        }

        public SecurityModel GetSecurityRule()
        {
            var jsonFile = File.ReadAllText(secFile);
            return JsonConvert.DeserializeObject<SecurityModel>(jsonFile);
        }

        public void ModifySecurityRules(bool useLibra, bool libraLock, bool movedConfirmation, bool rejectConfirmation, bool rejectWarning)
        {
            var rules = GetSecurityRule();
            var newRules = new SecurityModel
            {
                UseLibra = useLibra != rules.UseLibra ? useLibra : rules.UseLibra,
                LibraLock = libraLock != rules.LibraLock ? libraLock : rules.LibraLock,
                ShowMovedConfirmation = movedConfirmation != rules.ShowMovedConfirmation ? movedConfirmation : rules.ShowMovedConfirmation,
                ShowRejectConfirmation = rejectConfirmation != rules.ShowRejectConfirmation ? rejectConfirmation : rules.ShowRejectConfirmation,
                ShowRejectWarning = rejectWarning != rules.ShowRejectWarning ? rejectWarning : rules.ShowRejectWarning,
            };

            string json = JsonConvert.SerializeObject(newRules, Formatting.Indented);
            File.WriteAllText(secFile, json);
        }
    }
}
