using HexArmory.Items;
using HexArmory.Recipes;
using UnityEngine;

namespace HexArmory.Core
{
    public static class HexContentBuilder
    {
        private static GameObject _fireproofFeatherCapePrefab;
        private static Recipe _fireproofFeatherCapeRecipe;

        public static void BuildAll(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogWarning(nameof(BuildAll) + ": objectDb was null.");
                return;
            }

            BuildFireproofFeatherCape(objectDb);
        }

        private static void BuildFireproofFeatherCape(ObjectDB objectDb)
        {
            if (_fireproofFeatherCapePrefab != null && _fireproofFeatherCapeRecipe != null)
            {
                return;
            }

            var prefab = FireproofFeatherCapeItem.Create(objectDb);

            if (prefab != null)
            {
                var builtItemDrop = prefab.GetComponent<ItemDrop>();
                Plugin.Log.LogInfo(
                    nameof(BuildFireproofFeatherCape)
                    + ": Built prefab drop prefab = "
                    + (builtItemDrop != null && builtItemDrop.m_itemData != null && builtItemDrop.m_itemData.m_dropPrefab != null
                        ? builtItemDrop.m_itemData.m_dropPrefab.name
                        : "<null>"));
            }

            if (prefab == null)
            {
                Plugin.Log.LogWarning(nameof(BuildFireproofFeatherCape) + ": Failed to create fireproof feather cape prefab.");
                return;
            }

            var recipe = FireproofFeatherCapeRecipe.Create(prefab, objectDb);
            if (recipe == null)
            {
                Plugin.Log.LogWarning(nameof(BuildFireproofFeatherCape) + ": Failed to create fireproof feather cape recipe.");
                return;
            }

            _fireproofFeatherCapePrefab = prefab;
            _fireproofFeatherCapeRecipe = recipe;

            HexRegistry.Prefabs.Add(prefab);
            HexRegistry.Items.Add(prefab);
            HexRegistry.Recipes.Add(recipe);

            Plugin.Log.LogInfo(nameof(BuildFireproofFeatherCape) + ": Fireproof feather cape content built and added to HexRegistry.");
        }
    }
}