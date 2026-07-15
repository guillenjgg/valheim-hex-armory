using Jotunn.Configs;

namespace HexArmory.Core.Definitions.Armor
{
    internal static class AshChestFenrig
    {
        internal const string PrefabName = "hexarmory_chest_medium_ashlands";
        internal const string DisplayNameToken = "$item_hexarmory_chest_medium_ashlands";
        internal const string DescriptionToken = "$item_hexarmory_chest_medium_ashlands_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 4;

        internal static readonly string CraftingStation = CraftingStations.BlackForge;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.TrollHide, 10),
        };
    }
}
