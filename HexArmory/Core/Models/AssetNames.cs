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
                    "assets/_customitems/hexarmory/dualflintknives/hex_armory_dual_flint_knives.prefab"
                },
                {
                    ItemDefinitions.DualFlintAxes.PrefabName,
                    "assets/_customitems/hexarmory/dualflintaxes/hex_armory_dual_flint_axes.prefab"
                }
            };
    }
}