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
                PrefabName = FlintKnives.PrefabName,
                BasePrefabName = VanillaPrefabNames.Knives.SkollAndHati,
                DisplayNameToken = FlintKnives.DisplayNameToken,
                DescriptionToken = FlintKnives.DescriptionToken,
                Amount = FlintKnives.Amount,
                MinStationLevel = FlintKnives.MinStationLevel,
                CraftingStation = FlintKnives.CraftingStation,
                Requirements = FlintKnives.Requirements,
                StatsOverride = FlintKnives.StatsOverride
            }
        };

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

        internal static class FlintKnives
        {
            internal const string PrefabName = "HexArmory_FlintKnives_Item";
            internal const string DisplayNameToken = "$item_hexarmory_flint_knives";
            internal const string DescriptionToken = "$item_hexarmory_flint_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 2, 1),
                new RequirementConfig(VanillaPrefabNames.Materials.Flint, 4, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 2, 1)
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
                BlockPowerPerLevel = 1f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 40f,
                DurabilityDrain = 0f,
                MovementModifier = 0f,
                AttackStamina = 4f
            };
        }
    }
}