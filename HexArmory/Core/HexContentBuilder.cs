using HexArmory.Items;
using HexArmory.Recipes;

namespace HexArmory.Core
{
    public static class HexContentBuilder
    {
        public static void BuildAll(ObjectDB objectDb)
        {
            if (objectDb == null)
            {
                Plugin.Log.LogWarning(nameof(BuildAll) + ": objectDb was null.");
                return;
            }

            HexRegistry.Clear();
            BuildFireproofFeatherCape(objectDb);
        }

        private static void BuildFireproofFeatherCape(ObjectDB objectDb)
        {
            var prefab = FireproofFeatherCapeItem.Create(objectDb);
            if (prefab == null)
            {
                Plugin.Log.LogWarning(nameof(BuildFireproofFeatherCape) + ": Failed to create fireproof feather cape prefab.");
                return;
            }

            var builtItemDrop = prefab.GetComponent<ItemDrop>();
            Plugin.Log.LogInfo(
                nameof(BuildFireproofFeatherCape)
                + ": Built prefab drop prefab = "
                + (builtItemDrop != null && builtItemDrop.m_itemData != null && builtItemDrop.m_itemData.m_dropPrefab != null
                    ? builtItemDrop.m_itemData.m_dropPrefab.name
                    : "<null>")
            );

            var recipe = FireproofFeatherCapeRecipe.Create(prefab, objectDb);
            if (recipe == null)
            {
                Plugin.Log.LogWarning(nameof(BuildFireproofFeatherCape) + ": Failed to create fireproof feather cape recipe.");
                return;
            }

            HexRegistry.AddPrefab(prefab);
            HexRegistry.AddItem(prefab);
            HexRegistry.AddRecipe(recipe);

            Plugin.Log.LogInfo(nameof(BuildFireproofFeatherCape) + ": Fireproof feather cape content built and added to HexRegistry.");
        }
    }
}