using Jotunn.Configs;

namespace HexArmory.Core
{
    internal static class ItemNames
    {
        internal const string CapeFeather = "CapeFeather";
        internal const string SurtlingCore = "SurtlingCore";
        internal const string Wood = "Wood";
        internal const string ScaleHide = "ScaleHide";
        internal const string Eitr = "Eitr";
        internal const string Feathers = "Feathers";
    }

    internal static class TemperedFeatherCape
    {
        internal const string PrefabName = "CapeFeather_HexArmory_Tempered";
        internal const string DisplayNameToken = "$item_hexarmory_tempered_feather_cape";
        internal const string DescriptionToken = "$item_hexarmory_tempered_feather_cape_desc";
        internal const int Amount = 1;
        internal const int MinStationLevel = 1;
        internal static readonly RequirementConfig[] Requirements =
        {
            new RequirementConfig(ItemNames.Feathers, 10),
            new RequirementConfig(ItemNames.ScaleHide, 5),
            new RequirementConfig(ItemNames.Eitr, 20),
            new RequirementConfig(ItemNames.SurtlingCore, 5)
        };
    }
}