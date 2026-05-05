using BepInEx;
using HexArmory.Core;
using HexArmory.Core.Localization;
using Jotunn.Managers;
using Jotunn.Utils;
using System.IO;
using UnityEngine;

namespace HexArmory
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Plugin : BaseUnityPlugin
    {
        private AssetBundle _assetBundle;

        internal const string PluginGuid = "hex.hexarmory";
        internal const string PluginName = "HexArmory";
        internal const string PluginVersion = "1.0.0";
        internal AssetBundle AssetBundle => _assetBundle;

        internal static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            PluginConfig.Initialize(Config);

            LocalizationRegistrar.Register();
            Jotunn.Logger.LogInfo("[HexArmory] Localization registered.");

            Logger.LogInfo("[HexArmory] Embedded resources: " +
    string.Join(", ", typeof(Plugin).Assembly.GetManifestResourceNames()));

            _assetBundle = AssetUtils.LoadAssetBundleFromResources("HexArmory.AssetsEmbedded.hexarmory", typeof(Plugin).Assembly);

            if (_assetBundle == null)
            {
                Logger.LogError("[HexArmory] Embedded asset bundle failed to load!");
            }
            else
            {
                Logger.LogInfo("[HexArmory] Embedded asset bundle loaded successfully.");

                var assets = _assetBundle.GetAllAssetNames();
                Logger.LogInfo("[HexArmory] Assets in bundle: " + string.Join(", ", assets));
            }

            PrefabManager.OnVanillaPrefabsAvailable += HexArmoryRegistrar.RegisterItems;

            Jotunn.Logger.LogInfo($"[{PluginName}] loaded (v{PluginVersion}).");
        }

        private void OnDestroy()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= HexArmoryRegistrar.RegisterItems;

            if (_assetBundle != null)
            {
                _assetBundle.Unload(false);
                _assetBundle = null;
            }

            Instance = null;
        }
    }
}