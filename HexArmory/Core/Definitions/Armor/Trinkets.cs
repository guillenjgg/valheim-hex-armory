using Jotunn.Configs;

namespace HexArmory.Core.Definitions.Armor
{
    internal static class Trinkets
    {
        internal static class PulsatingEarrings
        {
            internal const string PrefabName = "hex_armory_pulsating_earrings";
            internal const string DisplayNameToken = "$item_hex_armory_pulsating_earrings";
            internal const string DescriptionToken = "$item_hex_armory_pulsating_earrings_desc";
            internal const string DisplayName = "HexArmory Pulsating Earrings";
            internal const string Description = "Earrings that pulse with a strange energy. Permanently increase Eitr regeneration.";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;
            internal static readonly string CraftingStation = CraftingStations.BlackForge;
            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Carapace, 5, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Eitr, 5, 0),
                new RequirementConfig(VanillaPrefabNames.Trophies.TrophyGjall, 1, 0)
            };
        }
    }
}
