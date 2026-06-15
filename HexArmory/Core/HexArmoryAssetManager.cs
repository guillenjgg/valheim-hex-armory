using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace HexArmory.Core
{
    internal static class HexArmoryAssetManager
    {
        internal static AssetBundle AssetBundle { get; private set; }

        internal static readonly Dictionary<string, string> PrefabPathByItemPrefabName =
            new Dictionary<string, string>
            {
                {
                    ItemDefinitions.DualFlintKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualflintknives/hex_armory_dual_flint_knives.prefab"
                },
                {
                    ItemDefinitions.DualFlintAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualflintaxes/hex_armory_dual_flint_axes.prefab"
                },
                {
                    ItemDefinitions.DualCopperKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualcopperknives/hex_armory_dual_copper_knives.prefab"
                },
                {
                    ItemDefinitions.DualSilverKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualsilverknives/hex_armory_dual_silver_knives.prefab"
                },
                {
                    ItemDefinitions.DualBlackMetalKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualblackmetalknives/hex_armory_dual_black_metal_knives.prefab"
                },
                {
                    ItemDefinitions.DualIronKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualironknives/hex_armory_dual_iron_knives.prefab"
                },
                {
                    ItemDefinitions.DualChitinKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualchitinknives/hex_armory_dual_chitin_knives.prefab"
                },
                {
                    ItemDefinitions.DualFlameMetalKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualflamemetalknives/hex_armory_dual_flame_metal_knives.prefab"
                },
            };

        internal static void LoadAssets()
        {
            AssetBundle = AssetUtils.LoadAssetBundleFromResources("HexArmory.AssetsEmbedded.hexarmory");

            if (AssetBundle == null)
            {
                #if DEBUG
                Jotunn.Logger.LogError("[HexArmory] Embedded asset bundle failed to load!");
                #endif
            }
            else
            {
                #if DEBUG
                Jotunn.Logger.LogInfo("[HexArmory] Embedded asset bundle loaded successfully.");
                var assets = AssetBundle.GetAllAssetNames();
                Jotunn.Logger.LogInfo("[HexArmory] Assets in bundle: " + string.Join(", ", assets));
                #endif
            }
        }

        internal static void UnloadAssets()
        {
            if (AssetBundle != null)
            {
                AssetBundle.Unload(false);
                AssetBundle = null;
            }
        }
    }
}
