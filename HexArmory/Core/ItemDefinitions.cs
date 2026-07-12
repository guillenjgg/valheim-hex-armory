using System.Collections.Generic;
using static HitData;

namespace HexArmory.Core
{
    internal static class ItemDefinitions
    {
        internal static readonly ItemDefinitionEntry[] All =
        {
            ItemDefinitionFactory.ArmorCape(
                TemperedFeatherCape.PrefabName,
                VanillaPrefabNames.Capes.FeatherCape,
                TemperedFeatherCape.DisplayNameToken,
                TemperedFeatherCape.DescriptionToken,
                TemperedFeatherCape.Amount,
                TemperedFeatherCape.MinStationLevel,
                TemperedFeatherCape.CraftingStation,
                TemperedFeatherCape.Requirements,
                damageTypesToRemove: new[]
                {
                    HitData.DamageType.Fire,
                }),

            ItemDefinitionFactory.ArmorCape(
                AshenWingMantleCape.PrefabName,
                VanillaPrefabNames.Capes.AshCape,
                AshenWingMantleCape.DisplayNameToken,
                AshenWingMantleCape.DescriptionToken,
                AshenWingMantleCape.Amount,
                AshenWingMantleCape.MinStationLevel,
                AshenWingMantleCape.CraftingStation,
                AshenWingMantleCape.Requirements,
                overrideEquipEffectFromPrefab: VanillaPrefabNames.Capes.FeatherCape),

            ItemDefinitionFactory.ArmorCape(
                TrollBloodCape.PrefabName,
                null,
                TrollBloodCape.DisplayNameToken,
                TrollBloodCape.DescriptionToken,
                TrollBloodCape.Amount,
                TrollBloodCape.MinStationLevel,
                TrollBloodCape.CraftingStation,
                TrollBloodCape.Requirements,
                addEquipStatusEffect: HexArmoryAssetManager.TrollBloodStatusEffect,
                addDamageModifiers: new List<HitData.DamageModPair>
                {
                    new HitData.DamageModPair
                    {
                        m_type = HitData.DamageType.Frost,
                        m_modifier = DamageModifier.Resistant
                    }
                }),

            ItemDefinitionFactory.ArmorCape(
                TarredHideCape.PrefabName,
                null,
                TarredHideCape.DisplayNameToken,
                TarredHideCape.DescriptionToken,
                TarredHideCape.Amount,
                TarredHideCape.MinStationLevel,
                TarredHideCape.CraftingStation,
                TarredHideCape.Requirements,
                addDamageModifiers: new List<HitData.DamageModPair>
                {
                    new HitData.DamageModPair
                    {
                        m_type = HitData.DamageType.Frost,
                        m_modifier = DamageModifier.Resistant
                    }
                }),

            ItemDefinitionFactory.WeaponKnife(
                DualFlintKnives.PrefabName,
                null,
                DualFlintKnives.DisplayNameToken,
                DualFlintKnives.DescriptionToken,
                DualFlintKnives.Amount,
                DualFlintKnives.MinStationLevel,
                DualFlintKnives.CraftingStation,
                DualFlintKnives.Requirements,
                statsOverride: DualFlintKnives.StatsOverride),

            ItemDefinitionFactory.WeaponAxe(
                DualFlintAxes.PrefabName,
                null,
                DualFlintAxes.DisplayNameToken,
                DualFlintAxes.DescriptionToken,
                DualFlintAxes.Amount,
                DualFlintAxes.MinStationLevel,
                DualFlintAxes.CraftingStation,
                DualFlintAxes.Requirements,
                statsOverride: DualFlintAxes.StatsOverride),

            ItemDefinitionFactory.WeaponAxe(
                DualBronzeAxes.PrefabName,
                null,
                DualBronzeAxes.DisplayNameToken,
                DualBronzeAxes.DescriptionToken,
                DualBronzeAxes.Amount,
                DualBronzeAxes.MinStationLevel,
                DualBronzeAxes.CraftingStation,
                DualBronzeAxes.Requirements,
                statsOverride: DualBronzeAxes.StatsOverride),

            ItemDefinitionFactory.WeaponAxe(
                DualIronAxes.PrefabName,
                null,
                DualIronAxes.DisplayNameToken,
                DualIronAxes.DescriptionToken,
                DualIronAxes.Amount,
                DualIronAxes.MinStationLevel,
                DualIronAxes.CraftingStation,
                DualIronAxes.Requirements,
                statsOverride: DualIronAxes.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualCopperKnives.PrefabName,
                null,
                DualCopperKnives.DisplayNameToken,
                DualCopperKnives.DescriptionToken,
                DualCopperKnives.Amount,
                DualCopperKnives.MinStationLevel,
                DualCopperKnives.CraftingStation,
                DualCopperKnives.Requirements,
                statsOverride: DualCopperKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualSilverKnives.PrefabName,
                null,
                DualSilverKnives.DisplayNameToken,
                DualSilverKnives.DescriptionToken,
                DualSilverKnives.Amount,
                DualSilverKnives.MinStationLevel,
                DualSilverKnives.CraftingStation,
                DualSilverKnives.Requirements,
                statsOverride: DualSilverKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualBlackMetalKnives.PrefabName,
                null,
                DualBlackMetalKnives.DisplayNameToken,
                DualBlackMetalKnives.DescriptionToken,
                DualBlackMetalKnives.Amount,
                DualBlackMetalKnives.MinStationLevel,
                DualBlackMetalKnives.CraftingStation,
                DualBlackMetalKnives.Requirements,
                statsOverride: DualBlackMetalKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualIronKnives.PrefabName,
                null,
                DualIronKnives.DisplayNameToken,
                DualIronKnives.DescriptionToken,
                DualIronKnives.Amount,
                DualIronKnives.MinStationLevel,
                DualIronKnives.CraftingStation,
                DualIronKnives.Requirements,
                statsOverride: DualIronKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualChitinKnives.PrefabName,
                null,
                DualChitinKnives.DisplayNameToken,
                DualChitinKnives.DescriptionToken,
                DualChitinKnives.Amount,
                DualChitinKnives.MinStationLevel,
                DualChitinKnives.CraftingStation,
                DualChitinKnives.Requirements,
                statsOverride: DualChitinKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                SkollAndHatiEmberForged.PrefabName,
                null,
                SkollAndHatiEmberForged.DisplayNameToken,
                SkollAndHatiEmberForged.DescriptionToken,
                SkollAndHatiEmberForged.Amount,
                SkollAndHatiEmberForged.MinStationLevel,
                SkollAndHatiEmberForged.CraftingStation,
                SkollAndHatiEmberForged.Requirements,
                statsOverride: SkollAndHatiEmberForged.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualFlameMetalKnives.PrefabName,
                null,
                DualFlameMetalKnives.DisplayNameToken,
                DualFlameMetalKnives.DescriptionToken,
                DualFlameMetalKnives.Amount,
                DualFlameMetalKnives.MinStationLevel,
                DualFlameMetalKnives.CraftingStation,
                DualFlameMetalKnives.Requirements,
                statsOverride: DualFlameMetalKnives.StatsOverride)
        };
    }
}
