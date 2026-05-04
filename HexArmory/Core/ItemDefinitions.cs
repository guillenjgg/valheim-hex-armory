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
    }
}