using Jotunn.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HexArmory.Core.Services
{
    internal static class HexArmoryAssetManagerService
    {
        internal static AssetBundle AssetBundle { get; private set; }
        private static Dictionary<string, string> _assetPathByPrefabName;

        internal static StatusEffect TrollBloodStatusEffect { get; private set; }

        internal static void LoadAssets()
        {
            AssetBundle = AssetUtils.LoadAssetBundleFromResources("HexArmory.Assets.AssetBundles.hexarmory");

            if (AssetBundle == null)
            {
                #if DEBUG
                Jotunn.Logger.LogError("[HexArmory] Embedded asset bundle failed to load!");
                #endif
            }
            else
            {
                BuildAssetLookup();

                #if DEBUG
                Jotunn.Logger.LogInfo("[HexArmory] Embedded asset bundle loaded successfully.");
                var assets = AssetBundle.GetAllAssetNames();
                Jotunn.Logger.LogInfo("[HexArmory] Assets in bundle: " + string.Join(", ", assets));
                #endif
            }

            LoadStatusEffects();
        }

        internal static bool TryGetAssetPathForPrefab(string prefabName, out string assetPath)
        {
            assetPath = null;

            if (string.IsNullOrEmpty(prefabName) || _assetPathByPrefabName == null)
            {
                return false;
            }

            return _assetPathByPrefabName.TryGetValue(prefabName, out assetPath);
        }

        internal static void LoadStatusEffects()
        {
            if (TryGetAssetPathForPrefab("se_hexarmory_troll_blood", out string assetPath))
            {
                TrollBloodStatusEffect = AssetBundle.LoadAsset<StatusEffect>(assetPath);

                #if DEBUG
                if (TrollBloodStatusEffect == null)
                {
                    Jotunn.Logger.LogError($"[HexArmory] Failed to load status effect from path: {assetPath}");
                }
                else
                {
                    Jotunn.Logger.LogInfo($"[HexArmory] Loaded status effect: {TrollBloodStatusEffect.name}");
                }
                #endif
            }
            else
            {
                #if DEBUG
                Jotunn.Logger.LogError("[HexArmory] Failed to find asset path for status effect: se_hexarmory_troll_blood");
                #endif
            }
        }

        internal static void UnloadAssets()
        {
            if (AssetBundle != null)
            {
                AssetBundle.Unload(false);
                AssetBundle = null;
                _assetPathByPrefabName = null;
            }
        }

        private static void BuildAssetLookup()
        {
            _assetPathByPrefabName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var assetName in AssetBundle.GetAllAssetNames())
            {
                var prefabName = Path.GetFileNameWithoutExtension(assetName);

                if (string.IsNullOrEmpty(prefabName) || _assetPathByPrefabName.ContainsKey(prefabName))
                {
                    continue;
                }

                _assetPathByPrefabName.Add(prefabName, assetName);
            }
        }
    }
}
