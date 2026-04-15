using HarmonyLib;
using HexArmory.Items;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(ItemDrop), nameof(ItemDrop.Pickup))]
    public static class ItemDropPickupPatch
    {
        private const string CustomKey = "HexArmoryItemId";

        [HarmonyPrefix]
        private static void Prefix(ItemDrop __instance)
        {
            if (__instance == null || __instance.m_itemData == null)
            {
                return;
            }

            var item = __instance.m_itemData;

            if (item.m_customData == null)
            {
                return;
            }

            if (!item.m_customData.TryGetValue(CustomKey, out var prefabName))
            {
                return;
            }

            if (prefabName != FireproofFeatherCapeItem.PrefabName && prefabName != Items.AshenCapeItem.PrefabName)
            {
                return;
            }

            if (ObjectDB.instance == null)
            {
                Plugin.Log.LogWarning(nameof(ItemDropPickupPatch) + ": ObjectDB.instance was null.");
                return;
            }

            var customPrefab = ObjectDB.instance.GetItemPrefab(prefabName);
            if (customPrefab == null)
            {
                Plugin.Log.LogWarning(nameof(ItemDropPickupPatch) + ": Could not find custom prefab " + prefabName);
                return;
            }

            var customDrop = customPrefab.GetComponent<ItemDrop>();
            if (customDrop == null || customDrop.m_itemData == null)
            {
                Plugin.Log.LogWarning(nameof(ItemDropPickupPatch) + ": Custom prefab missing ItemDrop or item data.");
                return;
            }

            var restored = customDrop.m_itemData.Clone();

            restored.m_stack = item.m_stack;
            restored.m_durability = item.m_durability;
            restored.m_quality = item.m_quality;
            restored.m_variant = item.m_variant;
            restored.m_crafterID = item.m_crafterID;
            restored.m_crafterName = item.m_crafterName;
            restored.m_customData = item.m_customData;
            restored.m_dropPrefab = customPrefab;

            __instance.m_itemData = restored;

            Plugin.Log.LogInfo(
                nameof(ItemDropPickupPatch)
                + ": Restored custom item identity on pickup -> "
                + prefabName
            );
        }
    }
}