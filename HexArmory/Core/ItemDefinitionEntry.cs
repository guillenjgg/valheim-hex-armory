using HexArmory.Core.Models;
using Jotunn.Configs;

namespace HexArmory.Core
{
    internal sealed class ItemDefinitionEntry
    {
        internal string PrefabName { get; set; }
        internal string BasePrefabName { get; set; }
        internal string DisplayNameToken { get; set; }
        internal string DescriptionToken { get; set; }
        internal int Amount { get; set; }
        internal int MinStationLevel { get; set; }
        internal string CraftingStation { get; set; }
        internal RequirementConfig[] Requirements { get; set; }

        internal ItemStatsOverride StatsOverride { get; set; }
    }
}