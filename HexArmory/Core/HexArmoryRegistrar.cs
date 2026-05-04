using HexArmory.Core;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
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

            var customItem = new CustomItem(
                itemDefinition.PrefabName,
                itemDefinition.BasePrefabName,
                itemConfig);

            // 🔥 Apply modifications BEFORE adding to Jotunn
            ApplyPostRegistrationChanges(itemDefinition, customItem);

            ItemManager.Instance.AddItem(customItem);

            Jotunn.Logger.LogInfo($"[HexArmory] Registered item: {itemDefinition.PrefabName}");

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

        private static void ApplyPostRegistrationChanges(ItemDefinitionEntry itemDefinition, CustomItem customItem)
        {
            if (itemDefinition == null || customItem == null)
            {
                return;
            }

            if (itemDefinition.PrefabName == ItemDefinitions.TemperedFeatherCape.PrefabName)
            {
                RemoveFireDamageModifier(customItem.ItemDrop);
                return;
            }

            if (itemDefinition.PrefabName == ItemDefinitions.AshenWingMantleCape.PrefabName)
            {
                OverrideEquipEffectWithFeatherFall(customItem.ItemDrop);
                return;
            }
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
    }
}