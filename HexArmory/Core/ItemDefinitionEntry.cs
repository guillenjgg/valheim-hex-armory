using HexArmory.Core.Models;
using Jotunn.Configs;

namespace HexArmory.Core
{
    internal sealed class ItemDefinitionEntry
    {
        internal string PrefabName { get; }
        internal string BasePrefabName { get; }
        internal string DisplayNameToken { get; }
        internal string DescriptionToken { get; }
        internal int Amount { get; }
        internal int MinStationLevel { get; }
        internal string CraftingStation { get; }
        internal RequirementConfig[] Requirements { get; }

        internal string OverrideEquipEffectFromPrefab { get; set; }
        internal HitData.DamageType[] DamageTypesToRemove { get; set; }
        internal ItemStatsOverride StatsOverride { get; set; }

        internal bool HasPostRegistrationChanges
        {
            get
            {
                return StatsOverride != null ||
                    !string.IsNullOrEmpty(OverrideEquipEffectFromPrefab) ||
                    (DamageTypesToRemove != null && DamageTypesToRemove.Length > 0);
            }
        }

        internal ItemDefinitionEntry(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements)
        {
            PrefabName = prefabName;
            BasePrefabName = basePrefabName;
            DisplayNameToken = displayNameToken;
            DescriptionToken = descriptionToken;
            Amount = amount;
            MinStationLevel = minStationLevel;
            CraftingStation = craftingStation;
            Requirements = requirements;
        }
    }
}