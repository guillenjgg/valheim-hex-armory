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
                    DualFlintKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualflintknives/hex_armory_dual_flint_knives.prefab"
                },
                {
                    DualFlintAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualflintaxes/hex_armory_dual_flint_axes.prefab"
                },
                {
                    DualBronzeAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualbronzeaxes/hex_armory_dual-bronze-axes.prefab"
                },
                {
                    DualIronAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualironaxes/hex_armory_dual-iron-axes.prefab"
                },
                {
                    DualCrystalAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualcrystalaxes/hex_armory_dual_crystal_battle_axes.prefab"
                },
                {
                    DualCopperKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualcopperknives/hex_armory_dual_copper_knives.prefab"
                },
                {
                    DualSilverKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualsilverknives/hex_armory_dual_silver_knives.prefab"
                },
                {
                    DualBlackMetalKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualblackmetalknives/hex_armory_dual_black_metal_knives.prefab"
                },
                {
                    DualIronKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualironknives/hex_armory_dual_iron_knives.prefab"
                },
                {
                    DualChitinKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualchitinknives/hex_armory_dual_chitin_knives.prefab"
                },
                {
                    DualFlameMetalKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualflamemetalknives/hex_armory_dual_flame_metal_knives.prefab"
                },
                {
                    SkollAndHatiEmberForged.PrefabName,
                    "assets/_customitems/hexarmory/knives/skollandhatiember/hex_armory_skoll_and_hati_emberforged.prefab"
                },
                {
                    TarredHideCape.PrefabName,
                    "assets/_customitems/hexarmory/armor/capes/tarredhidecape/hex_armory_tarred_hide_cape.prefab"
                },
                {
                    TrollBloodCape.PrefabName,
                    "assets/_customitems/hexarmory/armor/capes/trollbloodcape/hex_armory_troll_blood_cape.prefab"
},
                };

        internal static StatusEffect TrollBloodStatusEffect { get; private set; }

        private const string TrollBloodStatusEffectPath =
            "assets/_customitems/hexarmory/statuseffects/se_hexarmory_troll_blood.asset";


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

            LoadStatusEffects();
        }

        internal static void LoadStatusEffects()
        {
            TrollBloodStatusEffect = AssetBundle.LoadAsset<StatusEffect>(TrollBloodStatusEffectPath);

            #if DEBUG
            if (TrollBloodStatusEffect == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] Failed to load status effect: {TrollBloodStatusEffectPath}");
            }
            else
            {
                Jotunn.Logger.LogInfo($"[HexArmory] Loaded status effect: {TrollBloodStatusEffect.name}");
            }
            #endif
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
