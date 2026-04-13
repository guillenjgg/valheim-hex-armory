using HexArmory.Items;
using HexArmory.Recipes;
using UnityEngine;

namespace HexArmory.Core
{
    public static class HexContentBuilder
    {
        private static bool _builtFireproofFeatherCape;

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
            if (_builtFireproofFeatherCape)
            {
                return;
            }

            var prefab = FireproofFeatherCapeItem.Create(objectDb);
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

            HexRegistry.Prefabs.Add(prefab);
            HexRegistry.Items.Add(prefab);
            HexRegistry.Recipes.Add(recipe);

            _builtFireproofFeatherCape = true;

            Plugin.Log.LogInfo(nameof(BuildFireproofFeatherCape) + ": Fireproof feather cape content built and added to HexRegistry.");
        }
    }
}