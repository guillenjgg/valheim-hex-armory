using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace HexArmory.Core
{
    /// <summary>
    /// Handles BepInEx configuration with live-reload support via FileSystemWatcher.
    /// Follows wiki best practices: https://github.com/Valheim-Modding/Wiki/wiki/Best-Practices
    /// </summary>
    public static class PluginConfig
    {
        public static ConfigEntry<bool> EnableDebugLogging { get; private set; }

        public static void Initialize(ConfigFile config)
        {
            config.SaveOnConfigSet = false;

            EnableDebugLogging = config.Bind(
                "Debug",
                nameof(EnableDebugLogging),
                false,
                "Enable verbose debug logging for development and troubleshooting.");

            config.Save();

            config.SaveOnConfigSet = true;

            SetupConfigWatcher(config);
        }

        private static void SetupConfigWatcher(ConfigFile config)
        {
            string configPath = BepInEx.Paths.ConfigPath;
            string configFileName = $"{Plugin.ModGuid}.cfg";

            FileSystemWatcher watcher = new FileSystemWatcher(configPath, configFileName)
            {
                IncludeSubdirectories = true,
                EnableRaisingEvents = true
            };

            watcher.Changed += (sender, e) => ReloadConfig(config, configFileName);
            watcher.Created += (sender, e) => ReloadConfig(config, configFileName);
            watcher.Renamed += (sender, e) => ReloadConfig(config, configFileName);

            // Ensure thread-safe UI updates if running on main thread
            if (ThreadingHelper.SynchronizingObject != null)
            {
                watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            }
        }

        private static void ReloadConfig(ConfigFile config, string fileName)
        {
            string filePath = Path.Combine(BepInEx.Paths.ConfigPath, fileName);

            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                Plugin.Log.LogDebug($"[{nameof(PluginConfig)}] Reloading configuration from {fileName}...");
                config.Reload();
                Plugin.Log.LogInfo($"[{nameof(PluginConfig)}] Configuration reloaded successfully.");
            }
            catch (System.Exception ex)
            {
                Plugin.Log.LogError($"[{nameof(PluginConfig)}] Failed to reload configuration: {ex.Message}");
            }
        }
    }
}
