using Jotunn.Configs;
using HexArmory.Core.Models;

namespace HexArmory.Core
{
    internal static class DualFlintAxes
    {
        internal const string PrefabName = "hex_armory_dual_flint_axes";
        internal const string DisplayNameToken = "$item_hex_armory_dual_flint_axes";
        internal const string DescriptionToken = "$item_hex_armory_dual_flint_axes_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 8, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Flint, 12, 6),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 2),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 20f,
            ChopDamage = 25f,
            PierceDamage = 0f,
            SlashDamagePerLevel = 4f,
            ChopDamagePerLevel = 2f,
            MaxQuality = 4,
            AttackForce = 20f,
            BackstabBonus = 3f,
            BlockPower = 8f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 30f,
            UseDurabilityDrain = 2f,
            MovementModifier = 0f,
            AttackStamina = 6f
        };
    }

    internal static class DualBronzeAxes
    {
        internal const string PrefabName = "hex_armory_dual_bronze_axes";
        internal const string DisplayNameToken = "$item_hex_armory_dual_bronze_axes";
        internal const string DescriptionToken = "$item_hex_armory_dual_bronze_axes_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 2;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Bronze, 16, 8),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 2),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 25f,
            ChopDamage = 30f,
            PierceDamage = 0f,
            SlashDamagePerLevel = 5f,
            ChopDamagePerLevel = 3f,
            MaxQuality = 4,
            AttackForce = 50f,
            BackstabBonus = 3f,
            BlockPower = 12f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 30f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 8f,
            ToolTier = 2
        };
    }

    internal static class DualIronAxes
    {
        internal const string PrefabName = "hex_armory_dual-iron-axes";
        internal const string DisplayNameToken = "$item_hex_armory_dual_iron_axes";
        internal const string DescriptionToken = "$item_hex_armory_dual_iron_axes_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 3;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Iron, 40, 20),
            new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 2),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 30f,
            ChopDamage = 35f,
            Spirit = 5f,
            PierceDamage = 0f,
            SlashDamagePerLevel = 5f,
            ChopDamagePerLevel = 3f,
            MaxQuality = 4,
            AttackForce = 50f,
            BackstabBonus = 3f,
            BlockPower = 12f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 30f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 10f,
            ToolTier = 3
        };
    }

    internal static class DualCrystalAxes
    {
        internal const string PrefabName = "hex_armory_dual_crystal_battle_axes";
        internal const string DisplayNameToken = "$item_hex_armory_dual_crystal_battle_axes";
        internal const string DescriptionToken = "$item_hex_armory_dual_crystal_battle_axes_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 3;

        internal static readonly string CraftingStation = CraftingStations.Forge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.AncientBark, 40, 5),
            new RequirementConfig(VanillaPrefabNames.Materials.Silver, 30, 15),
            new RequirementConfig(VanillaPrefabNames.Materials.Crystal, 10, 0),
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 60f,
            ChopDamage = 35f,
            Spirit = 20f,
            PierceDamage = 0f,
            SlashDamagePerLevel = 5f,
            ChopDamagePerLevel = 3f,
            MaxQuality = 4,
            AttackForce = 50f,
            BackstabBonus = 3f,
            BlockPower = 20f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 30f,
            DeflectionForcePerLevel = 5f,
            DurabilityPerLevel = 30f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 10f,
            ToolTier = 3
        };
    }
}
