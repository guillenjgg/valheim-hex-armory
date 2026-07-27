using Jotunn.Configs;
using HexArmory.Core.Models;

namespace HexArmory.Core
{
    internal static class DualFlintKnives
    {
        internal const string PrefabName = "hex_armory_dual_flint_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_flint_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_flint_knives_desc";
        internal const string DisplayName = "Dual Flint Knives";
        internal const string Description = "Two is better than one?";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Flint, 8, 4),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 0)
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 5f,
            PierceDamage = 5f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 10f,
            BackstabBonus = 6f,
            BlockPower = 4f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 40f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 5f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualCopperKnives
    {
        internal const string PrefabName = "hex_armory_dual_copper_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_copper_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_copper_knives_desc";
        internal const string DisplayName = "Dual Copper Knives";
        internal const string Description = "Forged from refined copper and sharpened to a keen edge, these twin knives excel at finding gaps in an enemy's defense.";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Copper, 16, 4),
            new RequirementConfig(VanillaPrefabNames.Materials.GreydwarfEye, 0, 8)
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 12f,
            PierceDamage = 12f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 15f,
            BackstabBonus = 6f,
            BlockPower = 4f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 5f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualChitinKnives
    {
        internal const string PrefabName = "hex_armory_dual_chitin_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_chitin_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_chitin_knives_desc";
        internal const string DisplayName = "Dual Abyssal Razors";
        internal const string Description = "Dual Chitin Knives";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Chitin, 40, 10),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 20f,
            PierceDamage = 20f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 10f,
            BackstabBonus = 6f,
            BlockPower = 4f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 8f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualIronKnives
    {
        internal const string PrefabName = "hex_armory_dual_iron_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_iron_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_iron_knives_desc";
        internal const string DisplayName = "Dual Iron Knives";
        internal const string Description = "Dual Iron Knives";
        internal const int Amount = 1;
        internal const int MinStationLevel = 3;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.Iron, 30, 5),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 6, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.TrophySkeleton, 2, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 22f,
            PierceDamage = 22f,
            Spirit = 12f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 15f,
            BackstabBonus = 6f,
            BlockPower = 8f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 8f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualSilverKnives
    {
        internal const string PrefabName = "hex_armory_dual_silver_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_silver_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_silver_knives_desc";
        internal const string DisplayName = "Dual Emberforged Silver Knives";
        internal const string Description = "Forged from silver and tempered in fire, these paired knives leave smoldering wounds that linger long after the strike.";
        internal const int Amount = 1;
        internal const int MinStationLevel = 3;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.Silver, 20, 5),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 6, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 4, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 25f,
            PierceDamage = 25f,
            Spirit = 0f,
            Fire = 12f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 10f,
            BackstabBonus = 6f,
            BlockPower = 12f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 10f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualBlackMetalKnives
    {
        internal const string PrefabName = "hex_armory_dual_black_metal_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_black_metal_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_black_metal_knives_desc";
        internal const string DisplayName = "Dual Frostforged Black Metal Knives";
        internal const string Description = "Forged from black metal and infused with biting frost, these paired knives tear flesh and freeze bone alike.";
        internal const int Amount = 1;
        internal const int MinStationLevel = 4;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.BlackMetal, 20, 8),
            new RequirementConfig(VanillaPrefabNames.Materials.LinenThread, 10, 10),
            new RequirementConfig(VanillaPrefabNames.Materials.FreezeGland, 5, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 34f,
            PierceDamage = 34f,
            Frost = 12f,
            Spirit = 20f,
            SlashDamagePerLevel = 1f,
            PierceDamagePerLevel = 1f,
            MaxQuality = 4,
            AttackForce = 10f,
            BackstabBonus = 6f,
            BlockPower = 24f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 15f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 12f,
            TimedBlockBonus = 6f
        };
    }

    internal static class SkollAndHatiEmberForged
    {
        internal const string PrefabName = "hex_armory_skoll_hati_emberforged";
        internal const string DisplayNameToken = "$item_hex_armory_skoll_hati_emberforged";
        internal const string DescriptionToken = "$item_hex_armory_skoll_hati_emberforged_desc";
        internal const string DisplayName = "Emberforged Skoll and Hati";
        internal const string Description = "The flames within these blades burn as fiercely as the hatred that gave them form.";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.BlackForge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Iron, 10, 4),
            new RequirementConfig(VanillaPrefabNames.Materials.BlackMetal, 20, 8),
            new RequirementConfig(VanillaPrefabNames.Materials.FreezeGland, 8, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 5, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            Fire = 20f,
            Frost = 20f,
            TimedBlockBonus = 6f
        };
    }

    internal static class DualFlameMetalKnives
    {
        internal const string PrefabName = "hex_armory_dual_flame_metal_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_flame_metal_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_flame_metal_knives_desc";
        internal const string DisplayName = "Dual Flame Metal Knives";
        internal const string Description = "Dual Flame Metal Knives";
        internal const int Amount = 1;
        internal const int MinStationLevel = 4;

        internal static readonly string CraftingStation = CraftingStations.BlackForge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.CharredBone, 15, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.FlametalNew, 24, 15),
            new RequirementConfig(VanillaPrefabNames.Materials.AskHide, 3, 1),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 120f,
            PierceDamage = 120f,
            Spirit = 20f,
            Frost = 20f,
            SlashDamagePerLevel = 3f,
            PierceDamagePerLevel = 3f,
            MaxQuality = 4,
            AttackForce = 20f,
            BackstabBonus = 6f,
            BlockPower = 57f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            MaxDurability = 175f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 16f,
            TimedBlockBonus = 4f,
        };
    }

    internal static class DualFlameMetalLightningKnives
    {
        internal const string PrefabName = "hex_armory_dual_flame_metal_lightning_knives";
        internal const string DisplayNameToken = "$item_hex_armory_dual_flame_metal_lightning_knives";
        internal const string DescriptionToken = "$item_hex_armory_dual_flame_metal_lightning_knives_desc";
        internal const string DisplayName = "Dual Flame Metal Lightning Knives";
        internal const string Description = "Dual Flame Metal Knives";
        internal const int Amount = 1;
        internal const int MinStationLevel = 4;

        internal static readonly string CraftingStation = CraftingStations.BlackForge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Knives.DualFlameMetalKnives, 1, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.FlametalNew, 0, 10),
            new RequirementConfig(VanillaPrefabNames.Materials.GemstoneBlue, 1, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 120f,
            PierceDamage = 120f,
            Lightning = 100f,
            SlashDamagePerLevel = 3f,
            PierceDamagePerLevel = 3f,
            MaxQuality = 4,
            AttackForce = 20f,
            BackstabBonus = 6f,
            BlockPower = 57f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            MaxDurability = 175f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 16f,
            TimedBlockBonus = 4f,
        };
    }
}
