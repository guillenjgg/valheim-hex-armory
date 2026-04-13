using System.Collections.Generic;
using UnityEngine;

namespace HexArmory.Core
{
    public static class HexRegistry
    {
        public static readonly List<GameObject> Prefabs = new List<GameObject>();
        public static readonly List<GameObject> Items = new List<GameObject>();
        public static readonly List<Recipe> Recipes = new List<Recipe>();
    }
}
