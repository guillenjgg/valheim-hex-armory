using Jotunn.Configs;

namespace HexArmory.Core
{
    internal class ItemDefinitionEntry
    {
        internal string PrefabName;
        internal string BasePrefabName;
        internal string DisplayNameToken;
        internal string DescriptionToken;
        internal int Amount;
        internal int MinStationLevel;
        internal string CraftingStation;
        internal RequirementConfig[] Requirements;
    }
}