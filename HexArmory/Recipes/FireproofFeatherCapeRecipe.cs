using System.Collections.Generic;
using UnityEngine;
using HexArmory.Core;

namespace HexArmory.Recipes
{
    public static class FireproofFeatherCapeRecipe
    {
        public const string RecipeName = "Recipe_" + ModConstants.ModPrefix + "_CapeFeather_Fireproof";
        public const string VanillaItemName = ItemNames.CapeFeather;

        public static Recipe Create(GameObject prefab, ObjectDB objectDb)
        {
            if (prefab == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": prefab was null.");
                return null;
            }

            if (objectDb == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": objectDb was null.");
                return null;
            }

            if (objectDb.m_recipes == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": ObjectDB.m_recipes was null.");
                return null;
            }

            var itemDrop = prefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": prefab was missing ItemDrop.");
                return null;
            }

            Recipe vanillaRecipe = null;

            foreach (var recipe in objectDb.m_recipes)
            {
                if (recipe == null)
                {
                    continue;
                }

                if (recipe.m_item == null || recipe.m_item.gameObject == null)
                {
                    continue;
                }

                if (recipe.m_item.gameObject.name == VanillaItemName)
                {
                    vanillaRecipe = recipe;
                    break;
                }
            }

            if (vanillaRecipe == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": Could not find vanilla Feather Cape recipe.");
                return null;
            }

            var newRecipe = ScriptableObject.Instantiate(vanillaRecipe);
            newRecipe.name = RecipeName;
            newRecipe.m_item = itemDrop;
            newRecipe.m_minStationLevel = 1;

            var requirements = new List<Piece.Requirement>();

            foreach (var req in vanillaRecipe.m_resources)
            {
                if (req == null || req.m_resItem == null)
                {
                    continue;
                }

                requirements.Add(new Piece.Requirement
                {
                    m_resItem = req.m_resItem,
                    m_amount = req.m_amount,
                    m_amountPerLevel = req.m_amountPerLevel,
                    m_recover = req.m_recover
                });
            }

            var surtlingCoreRequirement = CreateRequirement(objectDb, ItemNames.SurtlingCore, 5);
            if (surtlingCoreRequirement == null)
            {
                Plugin.Log.LogError(nameof(FireproofFeatherCapeRecipe) + ": Could not create Surtling Core requirement.");
                return null;
            }

            requirements.Add(surtlingCoreRequirement);
            newRecipe.m_resources = requirements.ToArray();

            Plugin.Log.LogInfo(nameof(FireproofFeatherCapeRecipe) + ": Built recipe " + newRecipe.name);

            return newRecipe;
        }

        private static Piece.Requirement CreateRequirement(ObjectDB objectDb, string itemName, int amount)
        {
            if (objectDb == null || objectDb.m_items == null)
            {
                return null;
            }

            foreach (var itemPrefab in objectDb.m_items)
            {
                if (itemPrefab == null)
                {
                    continue;
                }

                if (itemPrefab.name != itemName)
                {
                    continue;
                }

                var itemDrop = itemPrefab.GetComponent<ItemDrop>();
                if (itemDrop == null)
                {
                    return null;
                }

                return new Piece.Requirement
                {
                    m_resItem = itemDrop,
                    m_amount = amount,
                    m_amountPerLevel = 0,
                    m_recover = true
                };
            }

            return null;
        }
    }
}