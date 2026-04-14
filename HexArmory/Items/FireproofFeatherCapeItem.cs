using HexArmory.Core;
using System.Collections.Generic;
using UnityEngine;
using static ItemDrop.ItemData;

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

            var baseItemDrop = basePrefab.GetComponent<ItemDrop>();
            if (baseItemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Base prefab was missing ItemDrop.");
                return null;
            }

            var baseShared = baseItemDrop.m_itemData?.m_shared;
            if (baseShared == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Base shared data was null.");
                return null;
            }

            bool baseWasActive = basePrefab.activeSelf;
            GameObject clonedPrefab = null;

            try
            {
                basePrefab.SetActive(false);

                clonedPrefab = Object.Instantiate(basePrefab);
                if (clonedPrefab == null)
                {
                    Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Failed to clone base prefab.");
                    return null;
                }

                clonedPrefab.name = PrefabName;
                clonedPrefab.SetActive(false);
            }
            finally
            {
                basePrefab.SetActive(baseWasActive);
            }

            var znv = clonedPrefab.GetComponent<ZNetView>();
            if (znv != null)
            {
                Plugin.Log.LogWarning(nameof(FireproofFeatherCapeItem) + ": Removing ZNetView from " + clonedPrefab.name);
                Object.DestroyImmediate(znv);
            }

            var zst = clonedPrefab.GetComponent<ZSyncTransform>();
            if (zst != null)
            {
                Plugin.Log.LogWarning(nameof(FireproofFeatherCapeItem) + ": Removing ZSyncTransform from " + clonedPrefab.name);
                Object.DestroyImmediate(zst);
            }

            var itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Cloned prefab was missing ItemDrop.");
                return null;
            }

            itemDrop.m_itemData = itemDrop.m_itemData.Clone();
            itemDrop.m_itemData.m_shared = CloneSharedData(itemDrop.m_itemData.m_shared);
            itemDrop.m_itemData.m_dropPrefab = clonedPrefab;

            var shared = itemDrop.m_itemData.m_shared;
            if (shared == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Shared item data was null.");
                return null;
            }

            shared.m_itemType = baseShared.m_itemType;
            shared.m_attachOverride = baseShared.m_attachOverride;
            shared.m_animationState = baseShared.m_animationState;
            shared.m_icons = baseShared.m_icons;
            shared.m_armorMaterial = baseShared.m_armorMaterial;
            shared.m_movementModifier = baseShared.m_movementModifier;
            shared.m_equipEffect = baseShared.m_equipEffect;
            shared.m_unequipEffect = baseShared.m_unequipEffect;

            if (baseShared.m_equipStatusEffect != null)
            {
                var seClone = Object.Instantiate(baseShared.m_equipStatusEffect);
                seClone.name = StatusEffectName;
                shared.m_equipStatusEffect = seClone;
            }

            shared.m_name = DisplayName;
            shared.m_description = Description;

            RemoveFireWeakness(shared);

            Plugin.Log.LogInfo(
                nameof(FireproofFeatherCapeItem)
                + ": itemType=" + shared.m_itemType
                + ", animationState=" + shared.m_animationState
                + ", attachOverride=" + shared.m_attachOverride
            );

            Plugin.Log.LogInfo(
                nameof(FireproofFeatherCapeItem)
                + ": Final drop prefab before activation = "
                + (itemDrop.m_itemData.m_dropPrefab != null ? itemDrop.m_itemData.m_dropPrefab.name : "<null>")
            );

            clonedPrefab.SetActive(true);

            itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": ItemDrop missing after activation.");
                return null;
            }

            itemDrop.m_itemData = itemDrop.m_itemData.Clone();
            itemDrop.m_itemData.m_shared = CloneSharedData(itemDrop.m_itemData.m_shared);
            itemDrop.m_itemData.m_dropPrefab = clonedPrefab;

            shared = itemDrop.m_itemData.m_shared;
            if (shared == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeItem) + ": Shared item data was null after activation.");
                return null;
            }

            shared.m_itemType = baseShared.m_itemType;
            shared.m_attachOverride = baseShared.m_attachOverride;
            shared.m_animationState = baseShared.m_animationState;
            shared.m_icons = baseShared.m_icons;
            shared.m_armorMaterial = baseShared.m_armorMaterial;
            shared.m_movementModifier = baseShared.m_movementModifier;
            shared.m_equipEffect = baseShared.m_equipEffect;
            shared.m_unequipEffect = baseShared.m_unequipEffect;

            if (baseShared.m_equipStatusEffect != null)
            {
                var seClone = Object.Instantiate(baseShared.m_equipStatusEffect);
                seClone.name = StatusEffectName;
                shared.m_equipStatusEffect = seClone;
            }

            shared.m_name = DisplayName;
            shared.m_description = Description;

            RemoveFireWeakness(shared);

            Plugin.Log.LogInfo(
                nameof(FireproofFeatherCapeItem)
                + ": Final drop prefab before return = "
                + (itemDrop.m_itemData.m_dropPrefab != null ? itemDrop.m_itemData.m_dropPrefab.name : "<null>")
            );

            Plugin.Log.LogInfo(
                nameof(FireproofFeatherCapeItem)
                + ": Prefab activeSelf before return = "
                + clonedPrefab.activeSelf
            );

            return clonedPrefab;
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

            int removedCount = shared.m_damageModifiers.RemoveAll(mod => mod.m_type == HitData.DamageType.Fire);

            Plugin.Log.LogInfo(
                nameof(RemoveFireWeakness) +
                ": Removed " + removedCount + " fire damage modifier(s) from shared data."
            );
        }

        private static ItemDrop.ItemData.SharedData CloneSharedData(ItemDrop.ItemData.SharedData original)
        {
            if (original == null)
            {
                return null;
            }

            var clone = new ItemDrop.ItemData.SharedData();

            foreach (var field in typeof(ItemDrop.ItemData.SharedData).GetFields())
            {
                field.SetValue(clone, field.GetValue(original));
            }

            clone.m_damageModifiers = original.m_damageModifiers != null
                ? new List<HitData.DamageModPair>(original.m_damageModifiers)
                : new List<HitData.DamageModPair>();

            clone.m_helmetHairSettings = original.m_helmetHairSettings != null
                ? new List<HelmetHairSettings>(original.m_helmetHairSettings)
                : new List<HelmetHairSettings>();

            clone.m_helmetBeardSettings = original.m_helmetBeardSettings != null
                ? new List<HelmetHairSettings>(original.m_helmetBeardSettings)
                : new List<HelmetHairSettings>();

            clone.m_itemStandOffsets = original.m_itemStandOffsets != null
                ? new List<ItemStand.OrientationSettings>(original.m_itemStandOffsets)
                : new List<ItemStand.OrientationSettings>();

            return clone;
        }
    }
}