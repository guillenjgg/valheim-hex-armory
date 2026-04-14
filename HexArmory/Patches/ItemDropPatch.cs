using HarmonyLib;
using HexArmory.Core;
using HexArmory.Items;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(ItemDrop), nameof(ItemDrop.Awake))]
    public static class ItemDropPatch
    {
        [HarmonyPostfix]
        private static void Postfix(ItemDrop __instance)
        {
            if (__instance == null)
            {
                return;
            }

            if (__instance.gameObject == null)
            {
                return;
            }

            Plugin.Log.LogInfo(nameof(ItemDropPatch) + ": Awake postfix on " + __instance.gameObject.name);

            if (__instance.m_itemData == null)
            {
                return;
            }

            if (__instance.m_itemData.m_shared == null)
            {
                return;
            }

            if (__instance.m_itemData.m_shared.m_name != FireproofFeatherCapeItem.DisplayName)
            {
                return;
            }

            if (ObjectDB.instance == null)
            {
                Plugin.Log.LogWarning(nameof(ItemDropPatch) + ": ObjectDB.instance was null.");
                return;
            }

            var vanillaPrefab = ObjectDB.instance.GetItemPrefab(ItemNames.CapeFeather);
            if (vanillaPrefab == null)
            {
                Plugin.Log.LogWarning(nameof(ItemDropPatch) + ": Could not find vanilla cape prefab.");
                return;
            }

            __instance.m_itemData.m_dropPrefab = vanillaPrefab;

            Plugin.Log.LogInfo(
                nameof(ItemDropPatch)
                + ": Reset drop prefab for "
                + __instance.gameObject.name
                + " -> "
                + vanillaPrefab.name);
        }
    }
}