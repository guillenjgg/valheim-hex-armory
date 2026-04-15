using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

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

            HarmonyInstance = new Harmony(ModGuid);
            HarmonyInstance.PatchAll();

            Log.LogInfo("[Hex] " + ModName + " loaded.");
        }
    }
}