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
            StatusEffect addEquipStatusEffect = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorCape,
                prefabName,
                basePrefabName,
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
            List<HitData.DamageModPair> addDamageModifiers = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorHelmet,
                prefabName,
                basePrefabName,
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
            List<HitData.DamageModPair> addDamageModifiers = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorPants,
                prefabName,
                basePrefabName,
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

        internal static ItemDefinitionEntry ArmorChests(
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
            List<HitData.DamageModPair> addDamageModifiers = null)
        {
            return Create(
                ItemTypeDefinitionEnum.ArmorChest,
                prefabName,
                basePrefabName,
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
            List<HitData.DamageModPair> addDamageModifiers = null)
        {
            return Create(
                ItemTypeDefinitionEnum.WeaponKnife,
                prefabName,
                basePrefabName,
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
            List<HitData.DamageModPair> addDamageModifiers = null)
        {
            return Create(
                ItemTypeDefinitionEnum.WeaponAxe,
                prefabName,
                basePrefabName,
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

