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
            Object.DontDestroyOnLoad(clonedPrefab);

            RemoveInvalidZSyncTransforms(clonedPrefab);

            var itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Cloned prefab was missing ItemDrop.");
                return null;
            }

            itemDrop.m_itemData.m_dropPrefab = basePrefab;

            Plugin.Log.LogInfo(
                nameof(FireproofFeatherCapeItem)
                + ": Assigned drop prefab = "
                + (itemDrop.m_itemData.m_dropPrefab != null ? itemDrop.m_itemData.m_dropPrefab.name : "<null>"));

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

            Plugin.Log.LogInfo(
    nameof(FireproofFeatherCapeItem)
    + ": Final drop prefab before return = "
    + (itemDrop.m_itemData.m_dropPrefab != null ? itemDrop.m_itemData.m_dropPrefab.name : "<null>"));

            return clonedPrefab;
        }

        private static void RemoveInvalidZSyncTransforms(GameObject prefab)
        {
            if (prefab == null)
                return;

            var syncTransforms = prefab.GetComponentsInChildren<ZSyncTransform>(true);

            foreach (var syncTransform in syncTransforms)
            {
                if (syncTransform == null)
                    continue;

                Plugin.Log.LogInfo(
                    nameof(RemoveInvalidZSyncTransforms) +
                    ": Removing ZSyncTransform from " + syncTransform.gameObject.name);

                Object.DestroyImmediate(syncTransform);
            }
        }

        private static void RemoveFireWeakness(ItemDrop.ItemData.SharedData shared)
        {
            if (shared == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": shared was null.");
                return;
            }

            if (shared.m_damageModifiers == null)
            {
                Plugin.Log.LogWarning(nameof(RemoveFireWeakness) + ": m_damageModifiers was null.");
                return;
            }

            int removedCount = shared.m_damageModifiers.RemoveAll(mod =>
                mod.m_type == HitData.DamageType.Fire
            );

            Plugin.Log.LogInfo(
                nameof(RemoveFireWeakness) +
                ": Removed " + removedCount + " fire damage modifier(s) from shared data."
            );
        }
    }
}