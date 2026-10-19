using Jotunn.Configs;
using System.Collections.Generic;
using HexArmory.Core;

namespace HexArmory.Core.Models
{
    internal sealed class ItemDefinitionEntry
    {
        internal ItemTypeDefinitionEnum Kind { get; }
        internal string PrefabName { get; }
        internal string BasePrefabName { get; }
        internal string AssetBundlePath { get; }
        internal string DisplayNameToken { get; }
        internal string DescriptionToken { get; }
        internal string DisplayName { get; }
        internal string Description { get; }
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
                var hasStatsOverride = StatsOverride != null;
                var hasEquipStatusEffect = EquipStatusEffect != null;
                var hasEquipEffectOverride = !string.IsNullOrEmpty(OverrideEquipEffectFromPrefab);
                var hasDamageModifiers = AddDamageModifiers != null && AddDamageModifiers.Count > 0;
                var hasDamageTypesToRemove = DamageTypesToRemove != null && DamageTypesToRemove.Length > 0;
                var isTrinket = Kind == ItemTypeDefinitionEnum.Trinket;

                return hasStatsOverride ||
                       hasEquipStatusEffect ||
                       hasEquipEffectOverride ||
                       hasDamageModifiers ||
                       hasDamageTypesToRemove ||
                       isTrinket;
            }
        }

        internal ItemDefinitionEntry(
            ItemTypeDefinitionEnum kind,
            string prefabName,
            string basePrefabName,
            string assetBundlePath,
            string displayNameToken,
            string descriptionToken,
            string displayName,
            string description,
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
            DisplayName = displayName;
            Description = description;
            Amount = amount;
            MinStationLevel = minStationLevel;
            CraftingStation = craftingStation;
            Requirements = requirements;
        }
    }
}
