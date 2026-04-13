using System;
using HarmonyLib;
using HexArmory.Core;

namespace HexArmory.Patches
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    public static class ZNetScenePatch
    {
        [HarmonyPostfix]
        private static void Postfix(ZNetScene __instance)
        {
            if (__instance == null)
            {
                Plugin.Log.LogWarning("ZNetScene.Awake: ZNetScene instance was null.");
                return;
            }

            try
            {
                Plugin.Log.LogInfo("ZNetScene.Awake: Running HexArmory prefab registration.");

                HexLifecycleRegistrar.RegisterPrefabs(__instance);

                Plugin.Log.LogInfo("ZNetScene.Awake: HexArmory prefab registration finished.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError("ZNetScene.Awake: HexArmory prefab registration failed: " + ex);
            }
        }
    }
}