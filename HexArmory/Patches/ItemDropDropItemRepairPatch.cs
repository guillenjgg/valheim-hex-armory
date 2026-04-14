using HarmonyLib;
using HexArmory.Core;
using HexArmory.Items;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(ItemDrop), nameof(ItemDrop.DropItem))]
    public static class ItemDropDropItemRepairPatch
    {
        [HarmonyPrefix]
        private static void Prefix(ItemDrop.ItemData item)
        {
            if (item == null)
            {
                return;
            }

            if (item.m_shared == null)
            {
                return;
            }

            if (item.m_shared.m_name != FireproofFeatherCapeItem.DisplayName)
            {
                return;
            }

            if (ObjectDB.instance == null)
            {
                return;
            }

            var vanillaPrefab = ObjectDB.instance.GetItemPrefab(ItemNames.CapeFeather);
            if (vanillaPrefab == null)
            {
                return;
            }

            item.m_dropPrefab = vanillaPrefab;

            Plugin.Log.LogInfo("[Hex] Forced vanilla drop prefab at drop time -> " + vanillaPrefab.name);
        }
    }
}