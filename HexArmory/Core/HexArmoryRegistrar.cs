using HexArmory.Core;
using HexArmory.Core.Models;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace HexArmory
{
    internal static class HexArmoryRegistrar
    {
        private static bool _registered;

        internal static void RegisterItems()
        {
            if (_registered)
            {
                return;
            }

            if (Plugin.Instance == null)
            {
                return;
            }

            int registeredCount = CreateCustomItems();

            _registered = true;
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterItems;

            Jotunn.Logger.LogInfo($"[HexArmory] items registered. Count: {registeredCount}");
        }

        private static int CreateCustomItems()
        {
            int registeredCount = 0;

            foreach (var itemDefinition in ItemDefinitions.All)
            {
                if (CreateCustomItem(itemDefinition))
                {
                    registeredCount++;
                }
            }

            return registeredCount;
        }

        private static bool CreateCustomItem(ItemDefinitionEntry itemDefinition)
        {
            if (itemDefinition == null)
            {
                Jotunn.Logger.LogWarning("[HexArmory] Item definition is null.");
                return false;
            }

            var itemConfig = BuildItemConfig(itemDefinition);

            var customItems = new List<CustomItem>();

            if (!itemDefinition.IsCustomAssetPrefab)
            {
                var customItem = new CustomItem(
                    itemDefinition.PrefabName,
                    itemDefinition.BasePrefabName,
                    itemConfig);

                customItems.Add(customItem);
            }
            else
            {
                string assetName;

                if (!AssetNames.PrefabPathByItemPrefabName.TryGetValue(itemDefinition.PrefabName, out assetName))
                {
                    Jotunn.Logger.LogError(
                        $"[HexArmory] No asset bundle prefab path mapped for item: {itemDefinition.PrefabName}");

                    return false;
                }

                var customItem = new CustomItem(
                    Plugin.Instance.AssetBundle,
                    assetName,
                    true,
                    itemConfig);

                if (customItem == null || customItem.ItemPrefab == null || customItem.ItemDrop == null)
                {
                    Jotunn.Logger.LogError(
                        $"[HexArmory] Failed to load prefab from asset bundle. Item={itemDefinition.PrefabName}, Asset={assetName}");

                    return false;
                }

                customItems.Add(customItem);
            }

            ApplyPostRegistrationChanges(itemDefinition, customItems);

            foreach(var item in customItems)
            {
                ItemManager.Instance.AddItem(item);
            }

            Jotunn.Logger.LogInfo($"Registered item: {itemDefinition.PrefabName}");

            return true;
        }

        private static ItemConfig BuildItemConfig(ItemDefinitionEntry itemDefinition)
        {
            return new ItemConfig
            {
                Name = itemDefinition.DisplayNameToken,
                Description = itemDefinition.DescriptionToken,
                Amount = itemDefinition.Amount,
                CraftingStation = itemDefinition.CraftingStation,
                MinStationLevel = itemDefinition.MinStationLevel,
                Requirements = itemDefinition.Requirements
            };
        }

        private static void ApplyPostRegistrationChanges(ItemDefinitionEntry itemDefinition, IEnumerable<CustomItem> customItems)
        {
            foreach(var customItem in customItems)
            {
                if (itemDefinition == null || customItem == null)
                {
                    continue;
                }

                if (itemDefinition.PrefabName == ItemDefinitions.TemperedFeatherCape.PrefabName)
                {
                    RemoveFireDamageModifier(customItem.ItemDrop);
                    continue;
                }

                if (itemDefinition.PrefabName == ItemDefinitions.AshenWingMantleCape.PrefabName)
                {
                    OverrideEquipEffectWithFeatherFall(customItem.ItemDrop);
                    continue;
                }

                if (itemDefinition.PrefabName == ItemDefinitions.DualFlintKnives.PrefabName 
                    || itemDefinition.PrefabName == ItemDefinitions.DualFlintAxes.PrefabName
                    || itemDefinition.PrefabName == ItemDefinitions.DualCopperKnives.PrefabName)
                {
                    AddWeaponStats(customItem.ItemDrop, itemDefinition.StatsOverride);

                    continue;
                }
            }

            return;
        }

        private static void RemoveFireDamageModifier(ItemDrop itemDrop)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Invalid ItemDrop while removing fire modifier.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            int removedCount = shared.m_damageModifiers.RemoveAll(
                mod => mod.m_type == HitData.DamageType.Fire);

            Jotunn.Logger.LogInfo(
                $"[HexArmory] Removed fire damage modifiers from {itemDrop.name}. Count: {removedCount}");
        }

        private static void OverrideEquipEffectWithFeatherFall(ItemDrop targetItemDrop)
        {
            if (targetItemDrop == null ||
                targetItemDrop.m_itemData == null ||
                targetItemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Invalid target ItemDrop.");
                return;
            }

            var targetShared = targetItemDrop.m_itemData.m_shared;

            var featherPrefab = PrefabManager.Instance.GetPrefab(VanillaPrefabNames.Capes.FeatherCape);

            if (featherPrefab == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Could not find Feather Cape prefab.");
                return;
            }

            var featherDrop = featherPrefab.GetComponent<ItemDrop>();

            if (featherDrop == null ||
                featherDrop.m_itemData == null ||
                featherDrop.m_itemData.m_shared == null ||
                featherDrop.m_itemData.m_shared.m_equipStatusEffect == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Feather Cape equip effect not found.");
                return;
            }

            var sourceEffect = featherDrop.m_itemData.m_shared.m_equipStatusEffect;

            if (targetShared.m_equipStatusEffect != null)
            {
                Jotunn.Logger.LogInfo(
                    $"[HexArmory] Replacing existing equip effect on {targetItemDrop.name}: {targetShared.m_equipStatusEffect.name}");
            }

            var slowFallClone = Object.Instantiate(sourceEffect);
            slowFallClone.name = "SE_HexArmory_AshenWingmantleCape";

            targetShared.m_equipStatusEffect = slowFallClone;

            Jotunn.Logger.LogInfo(
                $"[HexArmory] Applied Feather Fall to {targetItemDrop.name}: {slowFallClone.name}");
        }

        private static void AddWeaponStats(ItemDrop itemDrop, ItemStatsOverride stats)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Invalid ItemDrop while applying weapon stats.");
                return;
            }

            if (stats == null)
            {
                Jotunn.Logger.LogWarning($"[HexArmory] No weapon stats override found for {itemDrop.name}.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            shared.m_damages.m_slash = stats.SlashDamage;
            shared.m_damages.m_pierce = stats.PierceDamage;
            shared.m_damages.m_chop = stats.ChopDamage;

            shared.m_damagesPerLevel.m_slash = stats.SlashDamagePerLevel;
            shared.m_damagesPerLevel.m_pierce = stats.PierceDamagePerLevel;
            shared.m_damagesPerLevel.m_chop = stats.ChopDamagePerLevel;

            shared.m_maxQuality = stats.MaxQuality;

            shared.m_attackForce = stats.AttackForce;
            shared.m_backstabBonus = stats.BackstabBonus;

            shared.m_blockPower = stats.BlockPower;
            shared.m_blockPowerPerLevel = stats.BlockPowerPerLevel;

            shared.m_deflectionForce = stats.DeflectionForce;
            shared.m_deflectionForcePerLevel = stats.DeflectionForcePerLevel;

            shared.m_durabilityPerLevel = stats.DurabilityPerLevel;
            shared.m_useDurabilityDrain = 1;
            shared.m_movementModifier = stats.MovementModifier;

            shared.m_attack.m_attackStamina = stats.AttackStamina;


            Jotunn.Logger.LogInfo(
                $"[HexArmory] Applied weapon stats to {itemDrop.name}. " +
                $"Slash={shared.m_damages.m_slash}, Pierce={shared.m_damages.m_pierce}, " +
                $"SlashPerLevel={shared.m_damagesPerLevel.m_slash}, PiercePerLevel={shared.m_damagesPerLevel.m_pierce}, " +
                $"MaxQuality={shared.m_maxQuality}");
        }
    }
}