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
            BuildAshenCape(objectDb);
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
            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo(
                    $"{nameof(BuildFireproofFeatherCape)}: Built prefab drop prefab = {(builtItemDrop != null && builtItemDrop.m_itemData != null && builtItemDrop.m_itemData.m_dropPrefab != null ? builtItemDrop.m_itemData.m_dropPrefab.name : "<null>")}" );
            }

            var recipe = FireproofFeatherCapeRecipe.Create(prefab, objectDb);
            if (recipe == null)
            {
                Plugin.Log.LogWarning(nameof(BuildFireproofFeatherCape) + ": Failed to create fireproof feather cape recipe.");
                return;
            }

            HexRegistry.AddPrefab(prefab);
            HexRegistry.AddItem(prefab);
            HexRegistry.AddRecipe(recipe);

            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo($"{nameof(BuildFireproofFeatherCape)}: Fireproof feather cape content built and added to HexRegistry.");
            }
        }

        private static void BuildAshenCape(ObjectDB objectDb)
        {
            var prefab = AshenCapeItem.Create(objectDb);
            if (prefab == null)
            {
                Plugin.Log.LogWarning(nameof(BuildAshenCape) + ": Failed to create Ashen Cape prefab.");
                return;
            }

            var builtItemDrop = prefab.GetComponent<ItemDrop>();
            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo(
                    $"{nameof(BuildAshenCape)}: Built prefab drop prefab = {(builtItemDrop != null && builtItemDrop.m_itemData != null && builtItemDrop.m_itemData.m_dropPrefab != null ? builtItemDrop.m_itemData.m_dropPrefab.name : "<null>")}" );
            }

            var recipe = AshenCapeRecipe.Create(prefab, objectDb);
            if (recipe == null)
            {
                Plugin.Log.LogWarning(nameof(BuildAshenCape) + ": Failed to create Ashen Cape recipe.");
                return;
            }

            HexRegistry.AddPrefab(prefab);
            HexRegistry.AddItem(prefab);
            HexRegistry.AddRecipe(recipe);

            if (PluginConfig.EnableAdvancedDebugLogging.Value)
            {
                Plugin.Log.LogInfo($"{nameof(BuildAshenCape)}: Ashen Cape content built and added to HexRegistry.");
            }
        }
    }
}
