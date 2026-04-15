using HexArmory.Items;

namespace HexArmory.Core
{
    public static class HexItemRepair
    {
        public static void EnsureFireproofCapeDropPrefab(ItemDrop.ItemData item)
        {
            if (item == null)
            {
                return;
            }

            if (item.m_dropPrefab != null)
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
                Plugin.Log.LogWarning(nameof(HexItemRepair) + ": ObjectDB.instance was null while repairing dropPrefab.");
                return;
            }

            var prefab = ObjectDB.instance.GetItemPrefab(FireproofFeatherCapeItem.PrefabName);
            if (prefab == null)
            {
                Plugin.Log.LogWarning(nameof(HexItemRepair) + ": Could not resolve prefab " + FireproofFeatherCapeItem.PrefabName);
                return;
            }

            item.m_dropPrefab = prefab;

            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo(
                    $"{nameof(HexItemRepair)}: Repaired dropPrefab for {item.m_shared.m_name} -> {prefab.name}");
            }
        }
    }
}