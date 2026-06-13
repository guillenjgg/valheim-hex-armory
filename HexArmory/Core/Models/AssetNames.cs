using System.Collections.Generic;

namespace HexArmory.Core.Models
{
    internal static class AssetNames
    {
        internal static readonly Dictionary<string, string> PrefabPathByItemPrefabName =
            new Dictionary<string, string>
            {
                {
                    ItemDefinitions.DualFlintKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualflintknives/hex_armory_dual_flint_knives.prefab"
                },
                {
                    ItemDefinitions.DualFlintAxes.PrefabName,
                    "assets/_customitems/hexarmory/axes/dualflintaxes/hex_armory_dual_flint_axes.prefab"
                },
                {
                    ItemDefinitions.DualCopperKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualcopperknives/hex_armory_dual_copper_knives.prefab"
                },
                {
                    ItemDefinitions.DualSilverKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualsilverknives/hex_armory_dual_silver_knives.prefab"
                },
                {
                    ItemDefinitions.DualBlackMetalKnives.PrefabName,
                    "assets/_customitems/hexarmory/knives/dualblackmetalknives/hex_armory_dual_black_metal_knives.prefab"
                }
            };
    }
}