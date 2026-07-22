using Jotunn.Configs;
using System.Collections.Generic;
using HexArmory.Core.Models;

namespace HexArmory.Core
{
    internal sealed class ItemDefinitionEntry
    {
        internal ItemTypeDefinitionEnum Kind { get; }
        internal string PrefabName { get; }
        internal string BasePrefabName { get; }
        internal string AssetBundlePath { get; }
        internal string DisplayNameToken { get; }
        internal string DescriptionToken { get; }
        internal int Amount { get; }
        internal int MinStationLevel { get; }
        internal string CraftingStation { get; }
        internal RequirementConfig[] Requirements { get; }

        internal string OverrideEquipEffectFromPrefab { get; set; }
        internal HitData.DamageType[] DamageTypesToRemove { get; set; }
        internal ItemStatsOverride StatsOverride { get; set; }
        internal List<HitData.DamageModPair> AddDamageModifiers { get; set; }
        internal StatusEffect EquipStatusEffect { get; set; }

        internal bool HasPostRegistrationChanges
        {
            get
            {
                return StatsOverride != null ||
                    EquipStatusEffect != null ||
                    !string.IsNullOrEmpty(OverrideEquipEffectFromPrefab) ||
                    (AddDamageModifiers != null && AddDamageModifiers.Count > 0) ||
                    (DamageTypesToRemove != null && DamageTypesToRemove.Length > 0);
            }
        }

        internal ItemDefinitionEntry(
            ItemTypeDefinitionEnum kind,
            string prefabName,
            string basePrefabName,
            string assetBundlePath,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements)
        {
            Kind = kind;
            PrefabName = prefabName;
            BasePrefabName = basePrefabName;
            AssetBundlePath = assetBundlePath;
            DisplayNameToken = displayNameToken;
            DescriptionToken = descriptionToken;
            Amount = amount;
            MinStationLevel = minStationLevel;
            CraftingStation = craftingStation;
            Requirements = requirements;
        }
    }
}
