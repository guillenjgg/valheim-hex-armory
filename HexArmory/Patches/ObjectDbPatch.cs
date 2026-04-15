using HarmonyLib;
using HexArmory.Core;
using UnityEngine;
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
                Plugin.Log.LogError($"{source}: ObjectDB instance was null. Registration skipped.");
                return;
            }

            try
            {
                var basePrefab = objectDb.GetItemPrefab(ItemNames.CapeFeather);
                if (basePrefab == null)
                {
                    Plugin.Log.LogInfo($"{source}: CapeFeather not available yet. Skipping HexArmory registration.");
                    return;
                }

                Plugin.Log.LogInfo($"{source}: Running HexArmory ObjectDB registration.");

                HexContentBuilder.BuildAll(objectDb);
                HexLifecycleRegistrar.RegisterAll(objectDb);

                Plugin.Log.LogInfo($"{source}: HexArmory ObjectDB registration finished.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"{source}: HexArmory ObjectDB registration failed: {ex}");
            }
        }
    }
}