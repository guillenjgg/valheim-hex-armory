using UnityEngine;

namespace HexArmory.Utils
{
    public static class CloneHelpers
    {
        //public static GameObject CloneItemPrefab(ObjectDB objectDb, string basePrefabName, string newPrefabName)
        //{
        //    GameObject basePrefab = objectDb.GetItemPrefab(basePrefabName);
        //    if (basePrefab == null)
        //    {
        //        Plugin.Log.LogError($"Base prefab not found: {basePrefabName}");
        //        return null;
        //    }

        //    GameObject clone = UnityEngine.Object.Instantiate(basePrefab, objectDb.transform);
        //    clone.name = newPrefabName;
        //    clone.SetActive(false);

        //    return clone;
        //}

        //public static StatusEffect CloneStatusEffect(StatusEffect original, string newName)
        //{
        //    if (original == null)
        //    {
        //        return null;
        //    }

        //    StatusEffect clone = UnityEngine.Object.Instantiate(original);
        //    clone.name = newName;
        //    return clone;
        //}
    }
}