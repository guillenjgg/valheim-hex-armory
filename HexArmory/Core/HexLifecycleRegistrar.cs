using HarmonyLib;
using HexArmory.Items;
using System;
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
            int count = 0;

            foreach (var item in HexRegistry.Items)
            {
                if (item == null)
                {
                    Plugin.Log.LogWarning("RegisterItems: Found null item prefab in registry.");
                    continue;
                }

                if (!objectDb.m_items.Contains(item))
                {
                    objectDb.m_items.Add(item);
                    count++;

                    Plugin.Log.LogInfo("RegisterItems: Added item to ObjectDB: " + item.name);
                }
            }

            RebuildObjectDbRegisters(objectDb);

            Plugin.Log.LogInfo("RegisterItems: Registration complete. Added " + count + " item(s).");

            // 👇 ADD THIS BLOCK RIGHT HERE 👇
            var prefab = objectDb.GetItemPrefab(FireproofFeatherCapeItem.PrefabName);
            var itemDrop = prefab?.GetComponent<ItemDrop>();

            Plugin.Log.LogInfo(
                "POST-REGISTER dropPrefab = " +
                (itemDrop?.m_itemData?.m_dropPrefab != null
                    ? itemDrop.m_itemData.m_dropPrefab.name
                    : "<null>")
            );
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
                    RegisterNamedPrefab(zNetScene, prefab);
                    Plugin.Log.LogDebug(nameof(RegisterPrefabs) + ": Prefab already present in ZNetScene: " + prefab.name);
                    continue;
                }

                zNetScene.m_prefabs.Add(prefab);
                RegisterNamedPrefab(zNetScene, prefab);

                addedCount++;

                Plugin.Log.LogInfo(nameof(RegisterPrefabs) + ": Added prefab to ZNetScene: " + prefab.name);
            }

            Plugin.Log.LogInfo(nameof(RegisterPrefabs) + ": Registration complete. Added " + addedCount + " prefab(s).");
        }

        private static void RegisterNamedPrefab(ZNetScene zNetScene, GameObject prefab)
        {
            if (zNetScene == null || prefab == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(prefab.name))
            {
                return;
            }

            try
            {
                var namedPrefabsField = AccessTools.Field(typeof(ZNetScene), "m_namedPrefabs");
                if (namedPrefabsField == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterNamedPrefab) + ": Could not find m_namedPrefabs field.");
                    return;
                }

                var namedPrefabs = namedPrefabsField.GetValue(zNetScene) as Dictionary<int, GameObject>;
                if (namedPrefabs == null)
                {
                    Plugin.Log.LogWarning(nameof(RegisterNamedPrefab) + ": m_namedPrefabs was null or unexpected type.");
                    return;
                }

                var prefabHash = prefab.name.GetStableHashCode();
                namedPrefabs[prefabHash] = prefab;

                Plugin.Log.LogDebug(nameof(RegisterNamedPrefab) + ": Registered named prefab: " + prefab.name);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError(nameof(RegisterNamedPrefab) + ": Failed to register named prefab: " + ex);
            }
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
            catch (Exception ex)
            {
                Plugin.Log.LogError(nameof(RebuildObjectDbRegisters) + ": Failed to rebuild ObjectDB registers: " + ex);
            }
        }
    }
}