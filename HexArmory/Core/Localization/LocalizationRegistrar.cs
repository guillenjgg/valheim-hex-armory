using System.Collections.Generic;
using HexArmory.Core.Definitions;
using Jotunn.Entities;
using Jotunn.Managers;

namespace HexArmory.Core.Localization
{
    internal static class LocalizationRegistrar
    {
        internal static void Register()
        {
            var translations = new Dictionary<string, string>();

            // Auto-generate localization from item definitions
            foreach (var itemDef in ItemDefinitions.AllCustomItems)
            {
                translations[itemDef.DisplayNameToken] = itemDef.DisplayName;
                translations[itemDef.DescriptionToken] = itemDef.Description;
            }

            AddStatusEffectLocalizations(translations);

            CustomLocalization localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", translations);

            #if DEBUG
            Jotunn.Logger.LogInfo($"[HexArmory] Auto-registered localization for {ItemDefinitions.AllCustomItems.Length} items ({translations.Count} total entries).");
            #endif
        }

        private static void AddStatusEffectLocalizations(Dictionary<string, string> translations)
        {
            translations["se_hex_armory_troll_blood_name"] = "Troll Blood";
            translations["se_hex_armory_troll_blood_tooltip"] = "The blood of a troll courses through your veins.";
        }
    }
}