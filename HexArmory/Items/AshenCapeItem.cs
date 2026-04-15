using HexArmory.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemDrop.ItemData;

namespace HexArmory.Items
{
    public static class AshenCapeItem
    {
        public const string PrefabName = ItemNames.CapeFeather + "_" + ModConstants.ModPrefix + "_Ashen";
        // Distinguishable display name
        public const string DisplayName = "Ashen Wingmantle";
        public const string Description = "A smoky wingmantle imbued with feathered spring, reducing fall damage and improving jumps.";
        public const string StatusEffectName = "SE_" + ModConstants.ModPrefix + "_AshenCape";

        public static GameObject Create(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": objectDb was null.");
                return null;
            }

            // Find the vanilla Ash cape prefab to clone (try several common names).
            string[] ashCandidates = new[] { "Cape_Ash", "CapeAsh", "cape_ash", "capeash", "Cape_Ashen", "CapeAshen" };
            GameObject ashBasePrefab = null;
            foreach (var name in ashCandidates)
            {
                ashBasePrefab = objectDb.GetItemPrefab(name);
                if (ashBasePrefab != null) break;
            }

            if (ashBasePrefab == null)
            {
                // Fallback: try to find any ItemDrop with 'ash' in the name
                ashBasePrefab = Resources.FindObjectsOfTypeAll<ItemDrop>()
                    .FirstOrDefault(i => i != null && i.name.ToLower().Contains("ash"))?.gameObject;
            }

            if (ashBasePrefab == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Could not find an Ash cape base prefab.");
                return null;
            }

            var baseItemDrop = ashBasePrefab.GetComponent<ItemDrop>();
            if (baseItemDrop == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Ash base prefab was missing ItemDrop.");
                return null;
            }

            var ashSharedBase = baseItemDrop.m_itemData?.m_shared;
            if (ashSharedBase == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Ash base shared data was null.");
                return null;
            }

            bool baseWasActive = ashBasePrefab.activeSelf;
            GameObject clonedPrefab = null;

            try
            {
                ashBasePrefab.SetActive(false);

                clonedPrefab = Object.Instantiate(ashBasePrefab);
                if (clonedPrefab == null)
                {
                    Plugin.Log.LogError(nameof(AshenCapeItem) + ": Failed to clone base prefab.");
                    return null;
                }

                clonedPrefab.name = PrefabName;
                clonedPrefab.SetActive(false);
            }
            finally
            {
                ashBasePrefab.SetActive(baseWasActive);
            }

            var znv = clonedPrefab.GetComponent<ZNetView>();
            if (znv != null)
            {
                Plugin.Log.LogWarning(nameof(AshenCapeItem) + ": Removing ZNetView from " + clonedPrefab.name);
                Object.DestroyImmediate(znv);
            }

            var zst = clonedPrefab.GetComponent<ZSyncTransform>();
            if (zst != null)
            {
                Plugin.Log.LogWarning(nameof(AshenCapeItem) + ": Removing ZSyncTransform from " + clonedPrefab.name);
                Object.DestroyImmediate(zst);
            }

            var itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Cloned prefab was missing ItemDrop.");
                return null;
            }

            itemDrop.m_itemData = itemDrop.m_itemData.Clone();
            itemDrop.m_itemData.m_shared = CloneSharedData(itemDrop.m_itemData.m_shared);
            itemDrop.m_itemData.m_dropPrefab = clonedPrefab;

            var shared = itemDrop.m_itemData.m_shared;
            if (shared == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Shared item data was null.");
                return null;
            }

            // Preserve ash base shared properties
            shared.m_itemType = ashSharedBase.m_itemType;
            shared.m_attachOverride = ashSharedBase.m_attachOverride;
            shared.m_animationState = ashSharedBase.m_animationState;
            shared.m_icons = ashSharedBase.m_icons;
            shared.m_armorMaterial = ashSharedBase.m_armorMaterial;
            shared.m_movementModifier = ashSharedBase.m_movementModifier;
            shared.m_equipEffect = ashSharedBase.m_equipEffect;
            shared.m_unequipEffect = ashSharedBase.m_unequipEffect;

            // Copy capefeather equip status effect / attributes onto the ash shared
            var featherPrefab = objectDb.GetItemPrefab(ItemNames.CapeFeather);
            var featherShared = featherPrefab?.GetComponent<ItemDrop>()?.m_itemData?.m_shared;
            if (featherShared != null)
            {
                // Copy movement modifier if capefeather provides one
                if (featherShared.m_movementModifier != 0f)
                {
                    shared.m_movementModifier = featherShared.m_movementModifier;
                    Plugin.Log.LogInfo(nameof(AshenCapeItem) + ": Applied capefeather movementModifier=" + featherShared.m_movementModifier + " to " + clonedPrefab.name);
                }

                // Clone and attach capefeather equip status effect if available
                if (featherShared.m_equipStatusEffect != null)
                {
                    var seClone = Object.Instantiate(featherShared.m_equipStatusEffect);
                    seClone.name = StatusEffectName;
                    shared.m_equipStatusEffect = seClone;
                    Plugin.Log.LogInfo(nameof(AshenCapeItem) + ": Cloned and applied capefeather equip status effect to " + clonedPrefab.name + " as " + seClone.name);
                }
            }
            else
            {
                Plugin.Log.LogInfo(nameof(AshenCapeItem) + ": capefeather shared data not found; no feather attributes applied to " + clonedPrefab.name);
            }

            shared.m_name = DisplayName;
            shared.m_description = Description;

            Plugin.Log.LogInfo(
                nameof(AshenCapeItem)
                + ": itemType=" + shared.m_itemType
                + ", animationState=" + shared.m_animationState
                + ", attachOverride=" + shared.m_attachOverride
            );

            clonedPrefab.SetActive(true);

            // Re-clone after activation to ensure clean itemData/dropPrefab references (same pattern as Fireproof)
            itemDrop = clonedPrefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": ItemDrop missing after activation.");
                return null;
            }

            itemDrop.m_itemData = itemDrop.m_itemData.Clone();
            itemDrop.m_itemData.m_shared = CloneSharedData(itemDrop.m_itemData.m_shared);
            itemDrop.m_itemData.m_dropPrefab = clonedPrefab;

            shared = itemDrop.m_itemData.m_shared;
            if (shared == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeItem) + ": Shared item data was null after activation.");
                return null;
            }

            shared.m_itemType = ashSharedBase.m_itemType;
            shared.m_attachOverride = ashSharedBase.m_attachOverride;
            shared.m_animationState = ashSharedBase.m_animationState;
            shared.m_icons = ashSharedBase.m_icons;
            shared.m_armorMaterial = ashSharedBase.m_armorMaterial;
            shared.m_movementModifier = ashSharedBase.m_movementModifier;
            shared.m_equipEffect = ashSharedBase.m_equipEffect;
            shared.m_unequipEffect = ashSharedBase.m_unequipEffect;

            // Re-apply capefeather attributes on the active clone as well
            if (featherShared != null)
            {
                if (featherShared.m_movementModifier != 0f)
                {
                    shared.m_movementModifier = featherShared.m_movementModifier;
                    Plugin.Log.LogInfo(nameof(AshenCapeItem) + ": Re-applied capefeather movementModifier=" + featherShared.m_movementModifier + " to " + clonedPrefab.name);
                }

                if (featherShared.m_equipStatusEffect != null)
                {
                    var seClone2 = Object.Instantiate(featherShared.m_equipStatusEffect);
                    seClone2.name = StatusEffectName;
                    shared.m_equipStatusEffect = seClone2;
                    Plugin.Log.LogInfo(nameof(AshenCapeItem) + ": Re-cloned and applied capefeather equip status effect to " + clonedPrefab.name + " as " + seClone2.name);
                }
            }

            shared.m_name = DisplayName;
            shared.m_description = Description;

            Plugin.Log.LogInfo(
                nameof(AshenCapeItem)
                + ": Final drop prefab before return = "
                + (itemDrop.m_itemData.m_dropPrefab != null ? itemDrop.m_itemData.m_dropPrefab.name : "<null>")
            );

            Plugin.Log.LogInfo(
                nameof(AshenCapeItem)
                + ": Prefab activeSelf before return = "
                + clonedPrefab.activeSelf
            );

            return clonedPrefab;
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
