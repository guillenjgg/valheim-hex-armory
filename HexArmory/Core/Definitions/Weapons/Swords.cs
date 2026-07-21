using HexArmory.Core.Models;
using Jotunn.Configs;

namespace HexArmory.Core.Definitions.Weapons
{
    internal static class FlintSword
    {
        internal const string PrefabName = "hex_armory_flint_sword";
        internal const string DisplayNameToken = "$item_hex_armory_flint_sword";
        internal const string DescriptionToken = "$item_hex_armory_flint_sword_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;

        internal static readonly string CraftingStation = CraftingStations.Workbench;

        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(VanillaPrefabNames.Materials.Flint, 8, 2),
            new RequirementConfig(VanillaPrefabNames.Materials.Wood, 10, 0)
        };

        internal static readonly ItemStatsOverride StatsOverride = new ItemStatsOverride
        {
            SlashDamage = 17f,
            SlashDamagePerLevel = 6f,
            MaxQuality = 4,
            AttackForce = 40f,
            BackstabBonus = 6f,
            BlockPower = 12f,
            BlockPowerPerLevel = 0f,
            DeflectionForce = 20f,
            DeflectionForcePerLevel = 5f,
            MaxDurability = 200f,
            DurabilityPerLevel = 50f,
            UseDurabilityDrain = 1f,
            MovementModifier = 0f,
            AttackStamina = 6f,
            TimedBlockBonus = 2f,
        };
    }
}
