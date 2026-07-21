using Jotunn.Configs;

namespace HexArmory.Core
{
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
            new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 10, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.ScaleHide, 5, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.Eitr, 20, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 5, 0)
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
            new RequirementConfig(VanillaPrefabNames.Materials.AskHide, 6, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.MorgenSinew, 2, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.FlametalNew, 5, 1),
            new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 20, 0)
        };
    }

    internal static class TarredHideCape
    {
        internal const string PrefabName = "hex_armory_tarred_hide_cape";
        internal const string DisplayNameToken = "$item_hex_armory_tarred_hide_cape";
        internal const string DescriptionToken = "$item_hex_armory_tarred_hide_cape_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.DeerHide, 4, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 10, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Stone, 5, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Resin, 5, 0)
        };
    }

    internal static class TrollBloodCape
    {
        internal const string PrefabName = "hex_armory_troll_blood_cape";
        internal const string DisplayNameToken = "$item_hex_armory_troll_blood_cape";
        internal const string DescriptionToken = "$item_hex_armory_troll_blood_cape_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.TrollHide, 10, 0),
            new RequirementConfig(VanillaPrefabNames.Materials.Bronze, 10, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.MushroomYellow, 0),
            new RequirementConfig(VanillaPrefabNames.Trophies.TrophyFrostTroll, 0)
        };
    }
}
