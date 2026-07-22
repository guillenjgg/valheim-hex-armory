using System.Collections.Generic;
using HexArmory.Core.Definitions.Weapons;
using HexArmory.Core.Models;
using HexArmory.Core.Services;
using static HitData;

namespace HexArmory.Core.Definitions
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
                addEquipStatusEffect: HexArmoryAssetManagerService.TrollBloodStatusEffect,
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

            ItemDefinitionFactory.WeaponAxe(
                DualCrystalAxes.PrefabName,
                null,
                DualCrystalAxes.DisplayNameToken,
                DualCrystalAxes.DescriptionToken,
                DualCrystalAxes.Amount,
                DualCrystalAxes.MinStationLevel,
                DualCrystalAxes.CraftingStation,
                DualCrystalAxes.Requirements,
                statsOverride: DualCrystalAxes.StatsOverride),

            ItemDefinitionFactory.WeaponAxe(
                DualBlackMetalAxes.PrefabName,
                null,
                DualBlackMetalAxes.DisplayNameToken,
                DualBlackMetalAxes.DescriptionToken,
                DualBlackMetalAxes.Amount,
                DualBlackMetalAxes.MinStationLevel,
                DualBlackMetalAxes.CraftingStation,
                DualBlackMetalAxes.Requirements,
                statsOverride: DualBlackMetalAxes.StatsOverride),

            ItemDefinitionFactory.WeaponAxe(
                DualJotunBaneAxes.PrefabName,
                null,
                DualJotunBaneAxes.DisplayNameToken,
                DualJotunBaneAxes.DescriptionToken,
                DualJotunBaneAxes.Amount,
                DualJotunBaneAxes.MinStationLevel,
                DualJotunBaneAxes.CraftingStation,
                DualJotunBaneAxes.Requirements,
                statsOverride: DualJotunBaneAxes.StatsOverride),

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
                statsOverride: DualFlameMetalKnives.StatsOverride),

            ItemDefinitionFactory.WeaponKnife(
                DualFlameMetalLightningKnives.PrefabName,
                null,
                DualFlameMetalLightningKnives.DisplayNameToken,
                DualFlameMetalLightningKnives.DescriptionToken,
                DualFlameMetalLightningKnives.Amount,
                DualFlameMetalLightningKnives.MinStationLevel,
                DualFlameMetalLightningKnives.CraftingStation,
                DualFlameMetalLightningKnives.Requirements,
                statsOverride: DualFlameMetalLightningKnives.StatsOverride),

            ItemDefinitionFactory.WeaponSword(
                FlintSword.PrefabName,
                null,
                FlintSword.DisplayNameToken,
                FlintSword.DescriptionToken,
                FlintSword.Amount,
                FlintSword.MinStationLevel,
                FlintSword.CraftingStation,
                FlintSword.Requirements,
                statsOverride: FlintSword.StatsOverride)
        };
    }
}
