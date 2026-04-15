using HarmonyLib;
using HexArmory.Core;
using HexArmory.Items;
using System.Collections.Generic;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(ItemDrop), nameof(ItemDrop.DropItem))]
    public static class ItemDropDropItemRepairPatch
    {
        private const string CustomKey = "HexArmoryItemId";

        [HarmonyPrefix]
        private static void Prefix(ItemDrop.ItemData item)
        {
            if (item == null || item.m_shared == null)
            {
                return;
            }

            // Only act for our custom capes
            if (item.m_shared.m_name != FireproofFeatherCapeItem.DisplayName
                && item.m_shared.m_name != Items.AshenCapeItem.DisplayName)
            {
                return;
            }

            if (item.m_customData == null)
            {
                item.m_customData = new Dictionary<string, string>();
            }

            // Map display name to prefab id
            if (item.m_shared.m_name == FireproofFeatherCapeItem.DisplayName)
            {
                item.m_customData[CustomKey] = FireproofFeatherCapeItem.PrefabName;
            }
            else if (item.m_shared.m_name == Items.AshenCapeItem.DisplayName)
            {
                item.m_customData[CustomKey] = Items.AshenCapeItem.PrefabName;
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

            Plugin.Log.LogInfo(
                nameof(ItemDropDropItemRepairPatch)
                + ": Forced vanilla drop prefab at drop time -> "
                + vanillaPrefab.name
            );
        }
    }
}