using HarmonyLib;
using UnityEngine;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.SetupVisEquipment))]
    public static class HumanoidSetupVisEquipmentDebugPatch
    {
        [HarmonyPrefix]
        private static void Prefix(Humanoid __instance, VisEquipment visEq, bool isRagdoll)
        {
            if (__instance == null)
            {
                return;
            }

            var shoulderField = AccessTools.Field(typeof(Humanoid), "m_shoulderItem");
            if (shoulderField == null)
            {
                Plugin.Log.LogWarning(nameof(HumanoidSetupVisEquipmentDebugPatch) + ": Could not find m_shoulderItem field.");
                return;
            }

            var shoulderItem = shoulderField.GetValue(__instance) as ItemDrop.ItemData;
            if (shoulderItem == null)
            {
                Plugin.Log.LogInfo(nameof(HumanoidSetupVisEquipmentDebugPatch) + ": m_shoulderItem is null.");
                return;
            }

            var itemName = shoulderItem.m_shared != null ? shoulderItem.m_shared.m_name : "<null shared>";
            var dropPrefabName = shoulderItem.m_dropPrefab != null ? shoulderItem.m_dropPrefab.name : "<null drop prefab>";

            Plugin.Log.LogInfo(
                nameof(HumanoidSetupVisEquipmentDebugPatch)
                + ": shoulder item="
                + itemName
                + ", dropPrefab="
                + dropPrefabName
                + ", variant="
                + shoulderItem.m_variant);
        }
    }
}