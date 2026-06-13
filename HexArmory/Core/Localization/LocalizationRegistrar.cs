using System.Collections.Generic;
using Jotunn.Entities;
using Jotunn.Managers;

namespace HexArmory.Core.Localization
{
    internal static class LocalizationRegistrar
    {
        internal static void Register()
        {
            CustomLocalization localization = LocalizationManager.Instance.GetLocalization();

            localization.AddTranslation("English", new Dictionary<string, string>
            {
                { "item_hexarmory_tempered_feather_cape", $"{DisplayNames.Capes.TemperedFeatherCape}" },
                { "item_hexarmory_tempered_feather_cape_desc", "A refined feather cape without the fire weakness." },
                { "item_hexarmory_ashen_wingmantle_cape", $"{DisplayNames.Capes.AshenWingmantleCape}" },
                { "item_hexarmory_ashen_wingmantle_cape_desc", "A feather cape imbued with the power of the Ashen Wing." },
                { "item_hex_armory_dual_flint_knives", $"{DisplayNames.Knives.FlintKnives}" },
                { "item_hex_armory_dual_flint_knives_desc", "Two is better than one?" },
                { "item_hex_armory_dual_flint_axes", $"{DisplayNames.Axes.FlintAxes}" },
                { "item_hex_armory_dual_flint_axes_desc", "Sharper than stone, stronger than one." },
                { "item_hex_armory_dual_copper_knives", $"{DisplayNames.Knives.CopperKnives}" },
                { "item_hex_armory_dual_copper_knives_desc", "Forged from refined copper and sharpened to a keen edge, these twin knives excel at finding gaps in an enemy's defense." },
                { "item_hex_armory_dual_silver_knives", $"{DisplayNames.Knives.SilverKnives}" },
                { "item_hex_armory_dual_silver_knives_desc", "Forged from silver and tempered in fire, these paired knives leave smoldering wounds that linger long after the strike." },
                { "item_hex_armory_dual_black_metal_knives", $"{DisplayNames.Knives.BlackMetalKnives}" },
                { "item_hex_armory_dual_black_metal_knives_desc", "Forged from black metal and infused with biting frost, these paired knives tear flesh and freeze bone alike." },
            });
        }
    }
}