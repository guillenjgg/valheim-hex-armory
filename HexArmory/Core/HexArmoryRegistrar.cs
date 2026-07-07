using HexArmory.Core;
using HexArmory.Core.Services;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;

namespace HexArmory
{
    internal static class HexArmoryRegistrar
    {
        private static bool _registered;

        internal static void RegisterItems()
        {
            if (_registered)
            {
                return;
            }

            if (Plugin.Instance == null)
            {
                return;
            }

            int registeredCount = CreateCustomItems();

            _registered = true;
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterItems;

            Jotunn.Logger.LogInfo($"Items registered. Count: {registeredCount}");
        }

        private static int CreateCustomItems()
        {
            int registeredCount = 0;

            foreach (var itemDefinition in ItemDefinitions.All)
            {
                if (CreateCustomItem(itemDefinition))
                {
                    registeredCount++;
                }
            }

            return registeredCount;
        }

        private static bool CreateCustomItem(ItemDefinitionEntry itemDefinition)
        {
            if (itemDefinition == null)
            {
                Jotunn.Logger.LogWarning("Item definition is null.");
                return false;
            }

            var itemConfig = BuildItemConfig(itemDefinition);

            CustomItem customItem;

            if (itemDefinition.BasePrefabName == null)
            {
                if (!HexArmoryAssetManager.PrefabPathByItemPrefabName.TryGetValue(itemDefinition.PrefabName, out string assetName))
                {
                    Jotunn.Logger.LogError(
                        $"No asset bundle prefab path mapped for item: {itemDefinition.PrefabName}");

                    return false;
                }

                customItem = new CustomItem(
                    HexArmoryAssetManager.AssetBundle,
                    assetName,
                    true,
                    itemConfig);

                if (customItem == null || customItem.ItemPrefab == null || customItem.ItemDrop == null)
                {
                    Jotunn.Logger.LogError(
                        $"Failed to load prefab from asset bundle. Item={itemDefinition.PrefabName}, Asset={assetName}");

                    return false;
                }
            }
            else
            {
                customItem = new CustomItem(
                    itemDefinition.PrefabName,
                    itemDefinition.BasePrefabName,
                    itemConfig);
            }

            if (itemDefinition.HasPostRegistrationChanges)
            {
                ItemDropModifierService.ApplyModifications(customItem.ItemDrop, itemDefinition);
            }

            ItemManager.Instance.AddItem(customItem);

            Jotunn.Logger.LogInfo($"Registered item: {itemDefinition.PrefabName}");

            return true;
        }

        private static ItemConfig BuildItemConfig(ItemDefinitionEntry itemDefinition)
        {
            return new ItemConfig
            {
                Name = itemDefinition.DisplayNameToken,
                Description = itemDefinition.DescriptionToken,
                Amount = itemDefinition.Amount,
                CraftingStation = itemDefinition.CraftingStation,
                MinStationLevel = itemDefinition.MinStationLevel,
                Requirements = itemDefinition.Requirements
            };
        }
    }
}