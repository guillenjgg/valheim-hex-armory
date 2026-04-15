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
            if (__instance?.gameObject == null)
            {
                return;
            }

            var name = __instance.gameObject.name;

            if (!name.Contains("CapeFeather") && !name.Contains(FireproofFeatherCapeItem.PrefabName))
            {
                return;
            }

            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo($"{nameof(ItemDropPatch)}: Awake postfix on {name}");
            }
        }
    }
}