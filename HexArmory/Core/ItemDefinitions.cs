using HexArmory.Core.Models;
using Jotunn.Configs;

namespace HexArmory.Core
{
    internal static class ItemDefinitions
    {
        internal static readonly ItemDefinitionEntry[] All =
        {
            new ItemDefinitionEntry
            {
                PrefabName = TemperedFeatherCape.PrefabName,
                BasePrefabName = VanillaPrefabNames.Capes.FeatherCape,
                DisplayNameToken = TemperedFeatherCape.DisplayNameToken,
                DescriptionToken = TemperedFeatherCape.DescriptionToken,
                Amount = TemperedFeatherCape.Amount,
                MinStationLevel = TemperedFeatherCape.MinStationLevel,
                CraftingStation = TemperedFeatherCape.CraftingStation,
                Requirements = TemperedFeatherCape.Requirements
            },
            new ItemDefinitionEntry
            {
                PrefabName = AshenWingMantleCape.PrefabName,
                BasePrefabName = VanillaPrefabNames.Capes.AshCape,
                DisplayNameToken = AshenWingMantleCape.DisplayNameToken,
                DescriptionToken = AshenWingMantleCape.DescriptionToken,
                Amount = AshenWingMantleCape.Amount,
                MinStationLevel = AshenWingMantleCape.MinStationLevel,
                CraftingStation = AshenWingMantleCape.CraftingStation,
                Requirements = AshenWingMantleCape.Requirements
            },
            new ItemDefinitionEntry
            {
                PrefabName = DualFlintKnives.PrefabName,
                IsCustomAssetPrefab = true,
                DisplayNameToken = DualFlintKnives.DisplayNameToken,
                DescriptionToken = DualFlintKnives.DescriptionToken,
                Amount = DualFlintKnives.Amount,
                MinStationLevel = DualFlintKnives.MinStationLevel,
                CraftingStation = DualFlintKnives.CraftingStation,
                Requirements = DualFlintKnives.Requirements,
                StatsOverride = DualFlintKnives.StatsOverride
            },
            new ItemDefinitionEntry
            {
                PrefabName = DualFlintAxes.PrefabName,
                IsCustomAssetPrefab = true,
                DisplayNameToken = DualFlintAxes.DisplayNameToken,
                DescriptionToken = DualFlintAxes.DescriptionToken,
                Amount = DualFlintAxes.Amount,
                MinStationLevel = DualFlintAxes.MinStationLevel,
                CraftingStation = DualFlintAxes.CraftingStation,
                Requirements = DualFlintAxes.Requirements,
                StatsOverride = DualFlintAxes.StatsOverride
            },
            new ItemDefinitionEntry
            {
                PrefabName = DualCopperKnives.PrefabName,
                IsCustomAssetPrefab = true,
                DisplayNameToken = DualCopperKnives.DisplayNameToken,
                DescriptionToken = DualCopperKnives.DescriptionToken,
                Amount = DualCopperKnives.Amount,
                MinStationLevel = DualCopperKnives.MinStationLevel,
                CraftingStation = DualCopperKnives.CraftingStation,
                Requirements = DualCopperKnives.Requirements,
                StatsOverride = DualCopperKnives.StatsOverride
            }
        };

        #region Armor
        internal static class TemperedFeatherCape
        {
            internal const string PrefabName = "CapeFeather_HexArmory_Tempered";
            internal const string DisplayNameToken = "$item_hexarmory_tempered_feather_cape";
            internal const string DescriptionToken = "$item_hexarmory_tempered_feather_cape_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.GaldrTable;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 10),
                new RequirementConfig(VanillaPrefabNames.Materials.ScaleHide, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Eitr, 20),
                new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 5)
            };
        }

        internal static class AshenWingMantleCape
        {
            internal const string PrefabName = "AshCape_HexArmory_Wingmantle_Cape";
            internal const string DisplayNameToken = "$item_hexarmory_ashen_wingmantle_cape";
            internal const string DescriptionToken = "$item_hexarmory_ashen_wingmantle_cape_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.BlackForge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.AskHide, 6),
                new RequirementConfig(VanillaPrefabNames.Materials.MorgenSinew, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.FlametalNew, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 20)
            };
        }
        #endregion

        #region Knives
        internal static class DualFlintKnives
        {
            internal const string PrefabName = "hex_armory_dual_flint_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_flint_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_flint_knives_desc";
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
                DeflectionForce = 10f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 40f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 5f
            };
        }

        internal static class DualCopperKnives
        {
            internal const string PrefabName = "hex_armory_dual_copper_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_copper_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_copper_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

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
                AttackForce = 10f,
                BackstabBonus = 6f,
                BlockPower = 4f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 10f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 2f,
                MovementModifier = 0f,
                AttackStamina = 6f
            };
        }
        #endregion

        #region Axes
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
        #endregion
    }
}