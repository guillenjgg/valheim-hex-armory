using System.Collections.Generic;
using Jotunn.Entities;
using Jotunn.Managers;

namespace HexArmory.Core
{
    internal static class LocalizationRegistrar
    {
        internal static void Register()
        {
            CustomLocalization localization = LocalizationManager.Instance.GetLocalization();

            localization.AddTranslation("English", new Dictionary<string, string>
            {
                { "item_hexarmory_tempered_feather_cape", "Tempered Feather Cape" },
                { "item_hexarmory_tempered_feather_cape_desc", "A refined feather cape without the fire weakness." }
            });
        }
    }
}