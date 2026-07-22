using Jotunn.Configs;
using System.Collections.Generic;
using HexArmory.Core.Models;

namespace HexArmory.Core
{
    internal static class ItemDefinitionFactory
    {
        internal static ItemDefinitionEntry ArmorCape(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            HitData.DamageType[] damageTypesToRemove = null,
            string overrideEquipEffectFromPrefab = null,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            StatusEffect addEquipStatusEffect = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorCape,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                damageTypesToRemove,
                overrideEquipEffectFromPrefab,
                statsOverride,
                addDamageModifiers,
                addEquipStatusEffect);
        }

        internal static ItemDefinitionEntry ArmorHelmet(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            HitData.DamageType[] damageTypesToRemove = null,
            string overrideEquipEffectFromPrefab = null,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorHelmet,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                damageTypesToRemove,
                overrideEquipEffectFromPrefab,
                statsOverride,
                addDamageModifiers);
        }

        internal static ItemDefinitionEntry ArmorPants(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            HitData.DamageType[] damageTypesToRemove = null,
            string overrideEquipEffectFromPrefab = null,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorPants,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                damageTypesToRemove,
                overrideEquipEffectFromPrefab,
                statsOverride,
                addDamageModifiers);
        }

        internal static ItemDefinitionEntry ArmorChest(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            HitData.DamageType[] damageTypesToRemove = null,
            string overrideEquipEffectFromPrefab = null,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorChest,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                damageTypesToRemove,
                overrideEquipEffectFromPrefab,
                statsOverride,
                addDamageModifiers);
        }

        internal static ItemDefinitionEntry WeaponKnife(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.WeaponKnife,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                statsOverride: statsOverride,
                addDamageModifiers: addDamageModifiers);
        }

        internal static ItemDefinitionEntry WeaponAxe(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.WeaponAxe,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                statsOverride: statsOverride,
                addDamageModifiers: addDamageModifiers);
        }

        internal static ItemDefinitionEntry WeaponSword(
            string prefabName,
            string basePrefabName,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            string assetBundlePath = null)
        {
            return Create(
                ItemTypeDefinitionEnum.Sword,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements,
                statsOverride: statsOverride,
                addDamageModifiers: addDamageModifiers);
        }

        private static ItemDefinitionEntry Create(
            ItemTypeDefinitionEnum kind,
            string prefabName,
            string basePrefabName,
            string assetBundlePath,
            string displayNameToken,
            string descriptionToken,
            int amount,
            int minStationLevel,
            string craftingStation,
            RequirementConfig[] requirements,
            HitData.DamageType[] damageTypesToRemove = null,
            string overrideEquipEffectFromPrefab = null,
            ItemStatsOverride statsOverride = null,
            List<HitData.DamageModPair> addDamageModifiers = null,
            StatusEffect addEquipStatusEffect = null)
        {
            return new ItemDefinitionEntry(
                kind,
                prefabName,
                basePrefabName,
                assetBundlePath,
                displayNameToken,
                descriptionToken,
                amount,
                minStationLevel,
                craftingStation,
                requirements)
            {
                DamageTypesToRemove = damageTypesToRemove,
                OverrideEquipEffectFromPrefab = overrideEquipEffectFromPrefab,
                StatsOverride = statsOverride,
                AddDamageModifiers = addDamageModifiers,
                EquipStatusEffect = addEquipStatusEffect
            };
        }
    }
}

