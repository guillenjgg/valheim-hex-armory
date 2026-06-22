using HexArmory.Core.Models;
using Jotunn.Configs;
using System;
using System.Collections.Generic;
using static HitData;

namespace HexArmory.Core
{
    internal static class ItemDefinitions
    {
        internal static readonly ItemDefinitionEntry[] All =
        {
            new ItemDefinitionEntry(
                TemperedFeatherCape.PrefabName,
                VanillaPrefabNames.Capes.FeatherCape,
                TemperedFeatherCape.DisplayNameToken,
                TemperedFeatherCape.DescriptionToken,
                TemperedFeatherCape.Amount,
                TemperedFeatherCape.MinStationLevel,
                TemperedFeatherCape.CraftingStation,
                TemperedFeatherCape.Requirements)
            {
                DamageTypesToRemove = new HitData.DamageType[]
                {
                    HitData.DamageType.Fire,
                }
            },
            new ItemDefinitionEntry(
                AshenWingMantleCape.PrefabName,
                VanillaPrefabNames.Capes.AshCape,
                AshenWingMantleCape.DisplayNameToken,
                AshenWingMantleCape.DescriptionToken,
                AshenWingMantleCape.Amount,
                AshenWingMantleCape.MinStationLevel,
                AshenWingMantleCape.CraftingStation,
                AshenWingMantleCape.Requirements)
            {
                OverrideEquipEffectFromPrefab = VanillaPrefabNames.Capes.FeatherCape
            },
            new ItemDefinitionEntry(
                TarredHideCape.PrefabName,
                null,
                TarredHideCape.DisplayNameToken,
                TarredHideCape.DescriptionToken,
                TarredHideCape.Amount,
                TarredHideCape.MinStationLevel,
                TarredHideCape.CraftingStation,
                TarredHideCape.Requirements)
            {
                AddDamageModifiers = new List<HitData.DamageModPair>
                {
                    new HitData.DamageModPair
                    {
                        m_type = HitData.DamageType.Frost,
                        m_modifier = DamageModifier.Resistant
                    }
                }
            },
            new ItemDefinitionEntry(
                DualFlintKnives.PrefabName,
                null,
                DualFlintKnives.DisplayNameToken,
                DualFlintKnives.DescriptionToken,
                DualFlintKnives.Amount,
                DualFlintKnives.MinStationLevel,
                DualFlintKnives.CraftingStation,
                DualFlintKnives.Requirements)
            {
                StatsOverride = DualFlintKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                DualFlintAxes.PrefabName,
                null,
                DualFlintAxes.DisplayNameToken,
                DualFlintAxes.DescriptionToken,
                DualFlintAxes.Amount,
                DualFlintAxes.MinStationLevel,
                DualFlintAxes.CraftingStation,
                DualFlintAxes.Requirements)
            {
                StatsOverride = DualFlintAxes.StatsOverride
            },
            new ItemDefinitionEntry(
                DualCopperKnives.PrefabName,
                null,
                DualCopperKnives.DisplayNameToken,
                DualCopperKnives.DescriptionToken,
                DualCopperKnives.Amount,
                DualCopperKnives.MinStationLevel,
                DualCopperKnives.CraftingStation,
                DualCopperKnives.Requirements)
            {
                StatsOverride = DualCopperKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                DualSilverKnives.PrefabName,
                null,
                DualSilverKnives.DisplayNameToken,
                DualSilverKnives.DescriptionToken,
                DualSilverKnives.Amount,
                DualSilverKnives.MinStationLevel,
                DualSilverKnives.CraftingStation,
                DualSilverKnives.Requirements)
            {
                StatsOverride = DualSilverKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                DualBlackMetalKnives.PrefabName,
                null,
                DualBlackMetalKnives.DisplayNameToken,
                DualBlackMetalKnives.DescriptionToken,
                DualBlackMetalKnives.Amount,
                DualBlackMetalKnives.MinStationLevel,
                DualBlackMetalKnives.CraftingStation,
                DualBlackMetalKnives.Requirements)
            {
                StatsOverride = DualBlackMetalKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                DualIronKnives.PrefabName,
                null,
                DualIronKnives.DisplayNameToken,
                DualIronKnives.DescriptionToken,
                DualIronKnives.Amount,
                DualIronKnives.MinStationLevel,
                DualIronKnives.CraftingStation,
                DualIronKnives.Requirements)
            {
                StatsOverride = DualIronKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                DualChitinKnives.PrefabName,
                null,
                DualChitinKnives.DisplayNameToken,
                DualChitinKnives.DescriptionToken,
                DualChitinKnives.Amount,
                DualChitinKnives.MinStationLevel,
                DualChitinKnives.CraftingStation,
                DualChitinKnives.Requirements)
            {
                StatsOverride = DualChitinKnives.StatsOverride
            },
            new ItemDefinitionEntry(
                SkollAndHatiEmberForged.PrefabName,
                null,
                SkollAndHatiEmberForged.DisplayNameToken,
                SkollAndHatiEmberForged.DescriptionToken,
                SkollAndHatiEmberForged.Amount,
                SkollAndHatiEmberForged.MinStationLevel,
                SkollAndHatiEmberForged.CraftingStation,
                SkollAndHatiEmberForged.Requirements)
            {
                StatsOverride = SkollAndHatiEmberForged.StatsOverride
            },
            new ItemDefinitionEntry(
                DualFlameMetalKnives.PrefabName,
                null,
                DualFlameMetalKnives.DisplayNameToken,
                DualFlameMetalKnives.DescriptionToken,
                DualFlameMetalKnives.Amount,
                DualFlameMetalKnives.MinStationLevel,
                DualFlameMetalKnives.CraftingStation,
                DualFlameMetalKnives.Requirements)
            {
                StatsOverride = DualFlameMetalKnives.StatsOverride
            }
        };

        #region Armor
        internal static class TemperedFeatherCape
        {
            internal const string PrefabName = "CapeFeather_HexArmory_Tempered";
            internal const string DisplayNameToken = "$item_hexarmory_tempered_feather_cape";
            internal const string DescriptionToken = "$item_hexarmory_tempered_feather_cape_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.GaldrTable;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 10),
                new RequirementConfig(VanillaPrefabNames.Materials.ScaleHide, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Eitr, 20),
                new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 5)
            };
        }

        internal static class AshenWingMantleCape
        {
            internal const string PrefabName = "AshCape_HexArmory_Wingmantle_Cape";
            internal const string DisplayNameToken = "$item_hexarmory_ashen_wingmantle_cape";
            internal const string DescriptionToken = "$item_hexarmory_ashen_wingmantle_cape_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.BlackForge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.AskHide, 6),
                new RequirementConfig(VanillaPrefabNames.Materials.MorgenSinew, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.FlametalNew, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Feathers, 20)
            };
        }

        internal static class TarredHideCape
        {
            internal const string PrefabName = "hex_armory_tarred_hide_cape";
            internal const string DisplayNameToken = "$item_hex_armory_tarred_hide_cape";
            internal const string DescriptionToken = "$item_hex_armory_tarred_hide_cape_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.DeerHide, 4),
                new RequirementConfig(VanillaPrefabNames.Materials.BoneFragments, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Resin, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.Coal, 5)
            };
        }
        #endregion

        #region Knives
        internal static class DualFlintKnives
        {
            internal const string PrefabName = "hex_armory_dual_flint_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_flint_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_flint_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Flint, 8, 4),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 0)
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 5f,
                PierceDamage = 5f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 10f,
                BackstabBonus = 6f,
                BlockPower = 4f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 40f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 5f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualCopperKnives
        {
            internal const string PrefabName = "hex_armory_dual_copper_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_copper_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_copper_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Forge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Copper, 16, 4),
                new RequirementConfig(VanillaPrefabNames.Materials.GreydwarfEye, 0, 8)
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 12f,
                PierceDamage = 12f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 15f,
                BackstabBonus = 6f,
                BlockPower = 4f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 5f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualChitinKnives
        {
            internal const string PrefabName = "hex_armory_dual_chitin_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_chitin_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_chitin_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Chitin, 40, 10),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 20f,
                PierceDamage = 20f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 10f,
                BackstabBonus = 6f,
                BlockPower = 4f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 8f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualIronKnives
        {
            internal const string PrefabName = "hex_armory_dual_iron_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_iron_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_iron_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 3;

            internal static readonly string CraftingStation = CraftingStations.Forge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.Iron, 30, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 6, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.TrophySkeleton, 2, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 22f,
                PierceDamage = 22f,
                Spirit = 12f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 15f,
                BackstabBonus = 6f,
                BlockPower = 8f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 8f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualSilverKnives
        {
            internal const string PrefabName = "hex_armory_dual_silver_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_silver_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_silver_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 3;

            internal static readonly string CraftingStation = CraftingStations.Forge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 4, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.Silver, 20, 5),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 6, 2),
                new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 4, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 25f,
                PierceDamage = 25f,
                Spirit = 0f,
                Fire = 12f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 10f,
                BackstabBonus = 6f,
                BlockPower = 12f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 10f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualBlackMetalKnives
        {
            internal const string PrefabName = "hex_armory_dual_black_metal_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_black_metal_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_black_metal_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 4;

            internal static readonly string CraftingStation = CraftingStations.Forge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.BlackMetal, 20, 8),
                new RequirementConfig(VanillaPrefabNames.Materials.LinenThread, 10, 10),
                new RequirementConfig(VanillaPrefabNames.Materials.FreezeGland, 5, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 34f,
                PierceDamage = 34f,
                Frost = 12f,
                SlashDamagePerLevel = 1f,
                PierceDamagePerLevel = 1f,
                MaxQuality = 4,
                AttackForce = 10f,
                BackstabBonus = 6f,
                BlockPower = 24f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 15f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 12f,
                TimedBlockBonus = 6f
            };
        }

        internal static class SkollAndHatiEmberForged
        {
            internal const string PrefabName = "hex_armory_skoll_hati_emberforged_knives";
            internal const string DisplayNameToken = "$item_hex_armory_skoll_hati_emberforged_knives";
            internal const string DescriptionToken = "$item_hex_armory_skoll_hati_emberforged_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.BlackForge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.FineWood, 8, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Iron, 10, 4),
                new RequirementConfig(VanillaPrefabNames.Materials.BlackMetal, 20, 8),
                new RequirementConfig(VanillaPrefabNames.Materials.SurtlingCore, 5, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                Fire = 20f,
                TimedBlockBonus = 6f
            };
        }

        internal static class DualFlameMetalKnives
        {
            internal const string PrefabName = "hex_armory_dual_flame_metal_knives";
            internal const string DisplayNameToken = "$item_hex_armory_dual_flame_metal_knives";
            internal const string DescriptionToken = "$item_hex_armory_dual_flame_metal_knives_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 4;

            internal static readonly string CraftingStation = CraftingStations.Forge;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 1, 0),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 120f,
                PierceDamage = 120f,
                Spirit = 12f,
                Frost = 12f,
                SlashDamagePerLevel = 3f,
                PierceDamagePerLevel = 3f,
                MaxQuality = 4,
                AttackForce = 15f,
                BackstabBonus = 6f,
                BlockPower = 57f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 25f,
                DeflectionForcePerLevel = 5f,
                MaxDurability = 250f,
                DurabilityPerLevel = 50f,
                UseDurabilityDrain = 1f,
                MovementModifier = 0f,
                AttackStamina = 12f,
                TimedBlockBonus = 6f,
            };
        }
        #endregion

        #region Axes
        internal static class DualFlintAxes
        {
            internal const string PrefabName = "hex_armory_dual_flint_axes";
            internal const string DisplayNameToken = "$item_hex_armory_dual_flint_axes";
            internal const string DescriptionToken = "$item_hex_armory_dual_flint_axes_desc";
            internal const int Amount = 1;
            internal const int MinStationLevel = 1;

            internal static readonly string CraftingStation = CraftingStations.Workbench;

            internal static readonly RequirementConfig[] Requirements =
            {
                new RequirementConfig(VanillaPrefabNames.Materials.Wood, 8, 0),
                new RequirementConfig(VanillaPrefabNames.Materials.Flint, 12, 6),
                new RequirementConfig(VanillaPrefabNames.Materials.LeatherScraps, 4, 2),
            };

            internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
            {
                SlashDamage = 20f,
                ChopDamage = 25f,
                PierceDamage = 0f,
                SlashDamagePerLevel = 4f,
                ChopDamagePerLevel = 2f,
                MaxQuality = 4,
                AttackForce = 20f,
                BackstabBonus = 3f,
                BlockPower = 8f,
                BlockPowerPerLevel = 0f,
                DeflectionForce = 20f,
                DeflectionForcePerLevel = 5f,
                DurabilityPerLevel = 30f,
                UseDurabilityDrain = 2f,
                MovementModifier = 0f,
                AttackStamina = 6f
            };
        }
        #endregion
    }
}