using System.Collections.Generic;
using HarmonyLib;
using HexArmory.Items;

namespace HexArmory.Core
{
    public static class HexLifecycleRegistrar
    {
        public static void RegisterAll(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterAll) + ": objectDb was null.");
                return;
            }

            RegisterItems(objectDb);
            RegisterRecipes(objectDb);
        }

        public static void RegisterItems(ObjectDB objectDb)
        {
            if (objectDb == null || objectDb.m_items == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterItems) + ": ObjectDB or ObjectDB.m_items was null.");
                return;
            }

            int count = 0;

            foreach (var item in HexRegistry.Items)
            {
                if (item == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterItems) + ": Found null item prefab in registry. Skipping.");
                    continue;
                }

                if (!objectDb.m_items.Contains(item))
                {
                    objectDb.m_items.Add(item);
                    count++;

                    if (PluginConfig.EnableAdvancedDebugLogging.Value)
                    {
                        Plugin.Log.LogInfo($"{nameof(RegisterItems)}: Added item to ObjectDB: {item.name}");
                    }
                }
            }

            RebuildObjectDbRegisters(objectDb);

            Plugin.Log.LogInfo($"{nameof(RegisterItems)}: Registration complete. Added {count} item(s).");

            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                var prefab = objectDb.GetItemPrefab(FireproofFeatherCapeItem.PrefabName);
                var itemDrop = prefab?.GetComponent<ItemDrop>();

                var dropPrefabName = itemDrop?.m_itemData?.m_dropPrefab != null
                    ? itemDrop.m_itemData.m_dropPrefab.name
                    : "<null>";

                Plugin.Log.LogInfo($"POST-REGISTER dropPrefab = {dropPrefabName}");
            }
        }

        public static void RegisterRecipes(ObjectDB objectDb)
        {
            if (objectDb == null || objectDb.m_recipes == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": ObjectDB or ObjectDB.m_recipes was null.");
                return;
            }

            var existingRecipeNames = BuildRecipeNameSet(objectDb.m_recipes);
            var addedCount = 0;

            foreach (var recipe in HexRegistry.Recipes)
            {
                if (recipe == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": Found null recipe in registry. Skipping.");
                    continue;
                }

                if (string.IsNullOrEmpty(recipe.name))
                {
                    Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": Found recipe with null or empty name in registry. Skipping.");
                    continue;
                }

                if (!existingRecipeNames.Add(recipe.name))
                {
                    if (PluginConfig.EnableAdvancedDebugLogging.Value)
                    {
                        Plugin.Log.LogDebug($"{nameof(RegisterRecipes)}: Recipe already present in ObjectDB: {recipe.name}");
                    }
                    continue;
                }

                objectDb.m_recipes.Add(recipe);
                addedCount++;

                if (PluginConfig.EnableAdvancedDebugLogging.Value)
                {
                    Plugin.Log.LogInfo($"{nameof(RegisterRecipes)}: Added recipe to ObjectDB: {recipe.name}");
                }
            }

            Plugin.Log.LogInfo($"{nameof(RegisterRecipes)}: Registration complete. Added {addedCount} recipe(s).");
        }

        private static HashSet<string> BuildRecipeNameSet(List<Recipe> recipes)
        {
            var recipeNames = new HashSet<string>();

            foreach (var recipe in recipes)
            {
                if (recipe == null || string.IsNullOrEmpty(recipe.name))
                {
                    continue;
                }

                recipeNames.Add(recipe.name);
            }

            return recipeNames;
        }

        private static void RebuildObjectDbRegisters(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                return;
            }

            try
            {
                var updateRegistersMethod = AccessTools.Method(typeof(ObjectDB), "UpdateRegisters");
                if (updateRegistersMethod == null)
                {
                    Plugin.Log.LogWarning(nameof(RebuildObjectDbRegisters) + ": Could not find ObjectDB.UpdateRegisters.");
                    return;
                }

                updateRegistersMethod.Invoke(objectDb, null);
                Plugin.Log.LogInfo(nameof(RebuildObjectDbRegisters) + ": Rebuilt ObjectDB registers.");
            }
            catch (System.Exception ex)
            {
                Plugin.Log.LogError(nameof(RebuildObjectDbRegisters) + ": Failed to rebuild ObjectDB registers: " + ex);
            }
        }
    }
}