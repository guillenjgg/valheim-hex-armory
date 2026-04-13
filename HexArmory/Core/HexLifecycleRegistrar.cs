using System.Collections.Generic;
using UnityEngine;

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
            if (objectDb.m_items == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterItems) + ": ObjectDB.m_items was null.");
                return;
            }

            var existingItemNames = BuildItemNameSet(objectDb.m_items);
            var addedCount = 0;

            foreach (var itemPrefab in HexRegistry.Items)
            {
                if (itemPrefab == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterItems) + ": Found null item prefab in registry.");
                    continue;
                }

                if (string.IsNullOrEmpty(itemPrefab.name))
                {
                    Plugin.Log.LogWarning(nameof(RegisterItems) + ": Found item prefab with null or empty name in registry.");
                    continue;
                }

                if (!existingItemNames.Add(itemPrefab.name))
                {
                    Plugin.Log.LogDebug(nameof(RegisterItems) + ": Item already present in ObjectDB: " + itemPrefab.name);
                    continue;
                }

                objectDb.m_items.Add(itemPrefab);
                addedCount++;

                Plugin.Log.LogInfo(nameof(RegisterItems) + ": Added item to ObjectDB: " + itemPrefab.name);
            }

            Plugin.Log.LogInfo(nameof(RegisterItems) + ": Registration complete. Added " + addedCount + " item(s).");
        }

        public static void RegisterRecipes(ObjectDB objectDb)
        {
            if (objectDb.m_recipes == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": ObjectDB.m_recipes was null.");
                return;
            }

            var existingRecipeNames = BuildRecipeNameSet(objectDb.m_recipes);
            var addedCount = 0;

            foreach (var recipe in HexRegistry.Recipes)
            {
                if (recipe == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": Found null recipe in registry.");
                    continue;
                }

                if (string.IsNullOrEmpty(recipe.name))
                {
                    Plugin.Log.LogWarning(nameof(RegisterRecipes) + ": Found recipe with null or empty name in registry.");
                    continue;
                }

                if (!existingRecipeNames.Add(recipe.name))
                {
                    Plugin.Log.LogDebug(nameof(RegisterRecipes) + ": Recipe already present in ObjectDB: " + recipe.name);
                    continue;
                }

                objectDb.m_recipes.Add(recipe);
                addedCount++;

                Plugin.Log.LogInfo(nameof(RegisterRecipes) + ": Added recipe to ObjectDB: " + recipe.name);
            }

            Plugin.Log.LogInfo(nameof(RegisterRecipes) + ": Registration complete. Added " + addedCount + " recipe(s).");
        }

        public static void RegisterPrefabs(ZNetScene zNetScene)
        {
            if (zNetScene == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterPrefabs) + ": zNetScene was null.");
                return;
            }

            if (zNetScene.m_prefabs == null)
            {
                Plugin.Log.LogWarning(nameof(RegisterPrefabs) + ": ZNetScene.m_prefabs was null.");
                return;
            }

            var existingPrefabNames = BuildPrefabNameSet(zNetScene.m_prefabs);
            var addedCount = 0;

            foreach (var prefab in HexRegistry.Prefabs)
            {
                if (prefab == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterPrefabs) + ": Found null prefab in registry.");
                    continue;
                }

                if (string.IsNullOrEmpty(prefab.name))
                {
                    Plugin.Log.LogWarning(nameof(RegisterPrefabs) + ": Found prefab with null or empty name in registry.");
                    continue;
                }

                if (!existingPrefabNames.Add(prefab.name))
                {
                    Plugin.Log.LogDebug(nameof(RegisterPrefabs) + ": Prefab already present in ZNetScene: " + prefab.name);
                    continue;
                }

                zNetScene.m_prefabs.Add(prefab);
                addedCount++;

                Plugin.Log.LogInfo(nameof(RegisterPrefabs) + ": Added prefab to ZNetScene: " + prefab.name);
            }

            Plugin.Log.LogInfo(nameof(RegisterPrefabs) + ": Registration complete. Added " + addedCount + " prefab(s).");
        }

        private static HashSet<string> BuildItemNameSet(List<GameObject> items)
        {
            var itemNames = new HashSet<string>();

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(item.name))
                {
                    continue;
                }

                itemNames.Add(item.name);
            }

            return itemNames;
        }

        private static HashSet<string> BuildRecipeNameSet(List<Recipe> recipes)
        {
            var recipeNames = new HashSet<string>();

            foreach (var recipe in recipes)
            {
                if (recipe == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(recipe.name))
                {
                    continue;
                }

                recipeNames.Add(recipe.name);
            }

            return recipeNames;
        }

        private static HashSet<string> BuildPrefabNameSet(List<GameObject> prefabs)
        {
            var prefabNames = new HashSet<string>();

            foreach (var prefab in prefabs)
            {
                if (prefab == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(prefab.name))
                {
                    continue;
                }

                prefabNames.Add(prefab.name);
            }

            return prefabNames;
        }
    }
}