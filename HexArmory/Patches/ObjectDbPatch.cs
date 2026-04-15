using HarmonyLib;
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
                Plugin.Log.LogWarning(source + ": ObjectDB instance was null.");
                return;
            }

            try
            {
                var basePrefab = objectDb.GetItemPrefab(ItemNames.CapeFeather);
                if (basePrefab == null)
                {
                    Plugin.Log.LogInfo(source + ": CapeFeather not available yet. Skipping HexArmory registration.");
                    return;
                }

                Plugin.Log.LogInfo(source + ": Running HexArmory ObjectDB registration.");

                HexContentBuilder.BuildAll(objectDb);
                HexLifecycleRegistrar.RegisterAll(objectDb);

                // Diagnostics: log available PieceTables and CraftingStations to help identify station/piece prefab names
                try
                {
                    var pieceTables = Resources.FindObjectsOfTypeAll<PieceTable>();
                    foreach (var pt in pieceTables)
                    {
                        Plugin.Log.LogInfo($"PieceTable found: name='{pt.name}', pieces={pt.m_pieces?.Count ?? 0}");
                        if (pt.m_pieces != null)
                        {
                            foreach (var go in pt.m_pieces)
                            {
                                if (go == null) continue;
                                var pieceComp = go.GetComponent<Piece>();
                                string pieceName = pieceComp != null ? pieceComp.m_name : "<no Piece>";
                                string prefabName = go.name;
                                Plugin.Log.LogInfo($"  piece prefab='{prefabName}', gameObj='{go.name}', Piece.m_name='{pieceName}'");
                            }
                        }
                    }

                    var stations = Resources.FindObjectsOfTypeAll<CraftingStation>();
                    foreach (var cs in stations)
                    {
                        Plugin.Log.LogInfo($"CraftingStation found: name='{cs.name}', gameObj='{cs.gameObject?.name}', type='{cs.GetType().FullName}'");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogWarning("HexArmory station/piece diagnostics failed: " + ex);
                }

                Plugin.Log.LogInfo(source + ": HexArmory ObjectDB registration finished.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError(source + ": HexArmory ObjectDB registration failed: " + ex);
            }
        }
    }
}