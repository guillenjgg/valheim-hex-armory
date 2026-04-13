using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HexArmory.Core;

namespace HexArmory
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string ModGuid = "com.hex.hexarmory";
        public const string ModName = "HexArmory";
        public const string ModVersion = "1.0.0";

        internal static Plugin Instance { get; private set; }
        internal static Harmony HarmonyInstance { get; private set; }
        internal static ManualLogSource Log { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            RegisterContent();

            HarmonyInstance = new Harmony(ModGuid);
            HarmonyInstance.PatchAll();

            Log.LogInfo("[Hex] " + ModName + " loaded.");
        }

        private static void RegisterContent()
        {
            Log.LogInfo("[Hex] Registering HexArmory content definitions.");

            // Register prefabs, items, and recipes here.

            Log.LogInfo("[Hex] HexArmory content definitions registered.");
        }
    }
}