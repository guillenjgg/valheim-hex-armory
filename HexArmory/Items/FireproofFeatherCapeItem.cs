using HexArmory.Core;
using HexArmory.Utils;
using UnityEngine;

namespace HexArmory.Items
{
    public static class FireproofFeatherCapeItem
    {
        public const string PrefabName = ItemNames.CapeFeather + "_" + ModConstants.ModPrefix + "_Fireproof";
        public const string DisplayName = "Fireproof Feather Cape";
        public const string Description = "A feather cape without weakness to fire.";
        public const string StatusEffectName = "SE_" + ModConstants.ModPrefix + "_FireproofFeatherCape";

        public static GameObject Create(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": objectDb was null.");
                return null;
            }

            var basePrefab = objectDb.GetItemPrefab(ItemNames.CapeFeather);
            if (basePrefab == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Could not find base prefab: " + ItemNames.CapeFeather);
                return null;
            }

            var clonedPrefab = Object.Instantiate(basePrefab);
            if (clonedPrefab == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Failed to clone base prefab.");
                return null;
            }

            clonedPrefab.name = PrefabName;

            var itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Cloned prefab was missing ItemDrop.");
                return null;
            }

            itemDrop.m_itemData.m_dropPrefab = clonedPrefab;

            var shared = itemDrop.m_itemData.m_shared;
            if (shared == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Shared item data was null.");
                return null;
            }

            shared.m_name = DisplayName;
            shared.m_description = Description;

            RemoveFireWeakness(shared);

            Plugin.Log.LogInfo(nameof(FireproofFeatherCapeItem) + ": Created prefab " + clonedPrefab.name);

            return clonedPrefab;
        }

        private static void RemoveFireWeakness(ItemDrop.ItemData.SharedData shared)
        {
            if (shared == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": shared was null.");
                return;
            }

            if (shared.m_equipStatusEffect == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": Equip status effect was null.");
                return;
            }

            var clonedStatusEffect = CloneHelpers.CloneStatusEffect(shared.m_equipStatusEffect, StatusEffectName);
            if (clonedStatusEffect == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": Failed to clone equip status effect.");
                return;
            }

            var stats = clonedStatusEffect as SE_Stats;
            if (stats == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": Equip status effect was not SE_Stats.");
                shared.m_equipStatusEffect = clonedStatusEffect;
                return;
            }

            var removedCount = stats.m_mods.RemoveAll(delegate (HitData.DamageModPair mod)
            {
                return mod.m_type == HitData.DamageType.Fire;
            });

            shared.m_equipStatusEffect = stats;

            Plugin.Log.LogInfo(
                nameof(RemoveFireWeakness) + ": Removed " + removedCount + " fire damage modifier(s) from equip status effect.");
        }
    }
}