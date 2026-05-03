using BepInEx;
//using HarmonyLib;
using HexArmory.Core;
using Jotunn.Managers;

namespace HexArmory
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Plugin : BaseUnityPlugin
    {
        internal const string PluginGuid = "hex.hexarmory";
        internal const string PluginName = "HexArmory";
        internal const string PluginVersion = "1.0.0";

        internal static Plugin Instance { get; private set; }
        //internal static Harmony HarmonyInstance { get; private set; }

        private void Awake()
        {
            Instance = this;

            PluginConfig.Initialize(Config);

            LocalizationRegistrar.Register();
            Jotunn.Logger.LogInfo("[HexArmory] Localization registered.");

            PrefabManager.OnVanillaPrefabsAvailable += HexArmoryRegistrar.RegisterItems;

            //HarmonyInstance = new Harmony(PluginGuid);
            //HarmonyInstance.PatchAll();

            Jotunn.Logger.LogInfo($"[{PluginName}] loaded (v{PluginVersion}).");
        }

        private void OnDestroy()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= HexArmoryRegistrar.RegisterItems;
            Instance = null;
            //HarmonyInstance?.UnpatchSelf();
        }
    }
}