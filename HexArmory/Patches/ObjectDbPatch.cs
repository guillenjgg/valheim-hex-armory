using HarmonyLib;
using HexArmory.Core;
using System;

namespace HexArmory.Patches
{
    [HarmonyPatch]
    public static class ObjectDbPatch
    {
        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
        [HarmonyPostfix]
        private static void ObjectDBAwakePostfix(ObjectDB __instance)
        {
            RunRegistration(__instance, "ObjectDB.Awake");
        }

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB))]
        [HarmonyPostfix]
        private static void ObjectDBCopyOtherDBPostfix(ObjectDB __instance)
        {
            RunRegistration(__instance, "ObjectDB.CopyOtherDB");
        }

        private static void RunRegistration(ObjectDB objectDb, string source)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogWarning(source + ": ObjectDB instance was null.");
                return;
            }

            try
            {
                Plugin.Log.LogInfo(source + ": Running " + nameof(HexArmory) + " ObjectDB registration.");

                HexContentBuilder.BuildAll(objectDb);

                if (ZNetScene.instance != null)
                {
                    HexLifecycleRegistrar.RegisterPrefabs(ZNetScene.instance);
                }

                HexLifecycleRegistrar.RegisterAll(objectDb);

                Plugin.Log.LogInfo(source + ": " + nameof(HexArmory) + " ObjectDB registration finished.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError(source + ": " + nameof(HexArmory) + " ObjectDB registration failed: " + ex);
            }
        }
    }
}