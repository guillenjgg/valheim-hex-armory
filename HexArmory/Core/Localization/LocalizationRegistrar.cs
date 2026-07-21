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

                { "item_hex_armory_dual_flint_axes", $"{DisplayNames.Axes.FlintAxes}" },
                { "item_hex_armory_dual_flint_axes_desc", "Two is better than one?" },

                { "item_hex_armory_flint_sword", $"{DisplayNames.Swords.FlintSword}" },
                { "item_hex_armory_flint_sword_desc", "A sword forged from flint, sharp and durable...kinda" },

                { "item_hex_armory_dual_flint_knives", $"{DisplayNames.Knives.FlintKnives}" },
                { "item_hex_armory_dual_flint_knives_desc", "Two is better than one?" },
                
                { "item_hex_armory_dual_bronze_axes", $"{DisplayNames.Axes.BronzeAxes}" },
                { "item_hex_armory_dual_bronze_axes_desc", "Sharper than stone, stronger than one." },
                
                { "item_hex_armory_dual_iron_axes", $"{DisplayNames.Axes.IronAxes}" },
                { "item_hex_armory_dual_iron_axes_desc", "Sharper than bronze, stronger than one." },
                
                { "item_hex_armory_dual_crystal_battle_axes", $"{DisplayNames.Axes.CrystalAxes}" },
                { "item_hex_armory_dual_crystal_battle_axes_desc", "Sharper than bronze, stronger than one." },

                { "item_hex_armory_dual_black_metal_axes", $"{DisplayNames.Axes.BlackMetalAxes}" },
                { "item_hex_armory_dual_black_metal_axes_desc", "Sharper than bronze, stronger than one." },

                { "item_hex_armory_dual_jotun_bane_axes", $"{DisplayNames.Axes.JotunBaneAxes}" },
                { "item_hex_armory_dual_jotun_bane_axes_desc", "Sharper than bronze, stronger than one." },

                { "item_hex_armory_dual_chitin_knives", $"{DisplayNames.Knives.ChitinKnives}" },
                { "item_hex_armory_dual_chitin_knives_desc", "Dual Chitin Knives" },
                
                { "item_hex_armory_dual_copper_knives", $"{DisplayNames.Knives.CopperKnives}" },
                { "item_hex_armory_dual_copper_knives_desc", "Forged from refined copper and sharpened to a keen edge, these twin knives excel at finding gaps in an enemy's defense." },
                
                { "item_hex_armory_dual_silver_knives", $"{DisplayNames.Knives.SilverKnives}" },
                { "item_hex_armory_dual_silver_knives_desc", "Forged from silver and tempered in fire, these paired knives leave smoldering wounds that linger long after the strike." },
                
                { "item_hex_armory_dual_black_metal_knives", $"{DisplayNames.Knives.BlackMetalKnives}" },
                { "item_hex_armory_dual_black_metal_knives_desc", "Forged from black metal and infused with biting frost, these paired knives tear flesh and freeze bone alike." },
                
                { "item_hex_armory_dual_iron_knives", $"{DisplayNames.Knives.IronKnives}" },
                { "item_hex_armory_dual_iron_knives_desc", "Dual Iron Knives" },
                
                { "item_hex_armory_skoll_hati_emberforged_knives", $"{DisplayNames.Knives.SkollAndHatiEmberforged}" },
                { "item_hex_armory_skoll_hati_emberforged_knives_desc", "The flames within these blades burn as fiercely as the hatred that gave them form." },
                
                { "item_hex_armory_dual_flame_metal_knives", $"{DisplayNames.Knives.FlameMetalKnives}" },
                { "item_hex_armory_dual_flame_metal_knives_desc", "Dual Flame Metal Knives" },

                { "item_hex_armory_dual_flame_metal_lightning_knives", $"{DisplayNames.Knives.FlameMetalLightningKnives}" },
                { "item_hex_armory_dual_flame_metal_lightning_knives_desc", "Dual Flame Metal Knives" },

                { "item_hex_armory_tarred_hide_cape", $"{DisplayNames.Capes.TarredHideCape}" },
                { "item_hex_armory_tarred_hide_cape_desc", "A deer hide cloak treated with resin and smoke. Its rugged craftsmanship keeps the bitter cold at bay." },
               
                { "item_hex_armory_troll_blood_cape", $"{DisplayNames.Capes.TrollBloodCape}" },
                { "item_hex_armory_troll_blood_cape_desc", "Crafted from troll hide and steeped in troll blood, this cape carries the endurance of the forest's ancient giants." },
                
                { "se_hex_armory_troll_blood_name", $"{DisplayNames.SEEffects.TrollBlood}" },
                { "se_hex_armory_troll_blood_tooltip", "The blood of a troll courses through your veins." },
            });
        }
    }
}