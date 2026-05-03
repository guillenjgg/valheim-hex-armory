using HexArmory.Core;
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

            Jotunn.Logger.LogInfo($"[HexArmory] items registered. Count: {registeredCount}");
        }

        private static int CreateCustomItems()
        {
            int registeredCount = 0;

            if (CreateTemperedFeatherCape())
            {
                registeredCount++;
            }

            return registeredCount;
        }

        private static bool CreateTemperedFeatherCape()
        {
            var itemConfig = BuildTemperedFeatherCapeConfig();

            var temperedCape = new CustomItem(
                TemperedFeatherCape.PrefabName,
                ItemNames.CapeFeather,
                itemConfig);

            ItemManager.Instance.AddItem(temperedCape);

            RemoveFireDamageModifier(temperedCape.ItemDrop);

            return true;
        }

        private static void RemoveFireDamageModifier(ItemDrop itemDrop)
        {
            if (itemDrop == null)
            {
                Jotunn.Logger.LogWarning("[HexArmory] ItemDrop is null.");
                return;
            }

            if (itemDrop.m_itemData == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] m_itemData is NULL on {itemDrop.name}");
                return;
            }

            if (itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] m_shared is NULL on {itemDrop.name}");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            int removedCount = shared.m_damageModifiers.RemoveAll(mod => mod.m_type == HitData.DamageType.Fire);

            Jotunn.Logger.LogInfo($"[HexArmory] Removed fire damage modifiers from {itemDrop.name}. Count: {removedCount}");
        }

        private static ItemConfig BuildTemperedFeatherCapeConfig()
        {
            return new ItemConfig
            {
                Name = TemperedFeatherCape.DisplayNameToken,
                Description = TemperedFeatherCape.DescriptionToken,
                Amount = TemperedFeatherCape.Amount,
                CraftingStation = CraftingStations.GaldrTable,
                MinStationLevel = TemperedFeatherCape.MinStationLevel,
                Requirements = TemperedFeatherCape.Requirements
            };
        }
    }
}