using System.Collections.Generic;
using UnityEngine;

namespace HexArmory.Core
{
    public static class HexRegistry
    {
        public static readonly List<GameObject> Prefabs = new List<GameObject>();
        public static readonly List<GameObject> Items = new List<GameObject>();
        public static readonly List<Recipe> Recipes = new List<Recipe>();

        public static void Clear()
        {
            Prefabs.Clear();
            Items.Clear();
            Recipes.Clear();
        }

        public static void AddPrefab(GameObject prefab)
        {
            if (prefab == null)
            {
                Plugin.Log.LogWarning(nameof(HexRegistry) + ": Attempted to add null prefab.");
                return;
            }

            if (!Prefabs.Contains(prefab))
            {
                Prefabs.Add(prefab);
            }
        }

        public static void AddItem(GameObject itemPrefab)
        {
            if (itemPrefab == null)
            {
                Plugin.Log.LogWarning(nameof(HexRegistry) + ": Attempted to add null item prefab.");
                return;
            }

            if (!Items.Contains(itemPrefab))
            {
                Items.Add(itemPrefab);
            }
        }

        public static void AddRecipe(Recipe recipe)
        {
            if (recipe == null)
            {
                Plugin.Log.LogWarning(nameof(HexRegistry) + ": Attempted to add null recipe.");
                return;
            }

            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
            }
        }
    }
}