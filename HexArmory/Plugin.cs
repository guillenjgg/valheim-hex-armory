using BepInEx;
using BepInEx.Logging;
using HexArmory.Core.Localization;
using Jotunn.Managers;

namespace HexArmory.Core.Services
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Plugin : BaseUnityPlugin
    {
        internal const string PluginGuid = "com.hex.hexarmory";
        internal const string PluginName = "HexArmory";
        internal const string PluginVersion = "1.0.0";

        private static ManualLogSource Log;

        internal static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            PluginConfig.Initialize(Config);

            LocalizationRegistrar.Register();
            HexArmoryAssetManagerService.LoadAssets();

            PrefabManager.OnVanillaPrefabsAvailable += HexArmoryRegistrarService.RegisterItems;

            Log.LogInfo($"{PluginName} v{PluginVersion} loaded.");
        }

        private void OnDestroy()
        {
            Log.LogInfo($"{PluginName} v{PluginVersion} unloaded.");

            PrefabManager.OnVanillaPrefabsAvailable -= HexArmoryRegistrarService.RegisterItems;

            HexArmoryAssetManagerService.UnloadAssets();
            Instance = null;
            Log = null;
        }
    }
}