using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HexArmory.Core;

namespace HexArmory
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGuid = "hex.hexarmory";
        private const string PluginName = "HexArmory";
        private const string PluginVersion = "1.0.0";

        internal static Plugin Instance { get; private set; }
        internal static Harmony HarmonyInstance { get; private set; }
        internal static ManualLogSource Log { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            PluginConfig.Initialize(Config);

            HarmonyInstance = new Harmony(PluginGuid);
            HarmonyInstance.PatchAll();

            Jotunn.Logger.LogInfo($"[{PluginName}] loaded (v{PluginVersion}).");
        }

        private void OnDestroy()
        {
            Instance = null;
            HarmonyInstance?.UnpatchSelf();
        }
    }
}