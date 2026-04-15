using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HexArmory.Core;

namespace HexArmory.Recipes
{
    public static class AshenCapeRecipe
    {
        public const string RecipeName = "Recipe_" + ModConstants.ModPrefix + "_CapeFeather_Ashen";
        public const string VanillaItemName = ItemNames.CapeFeather;

        public static Recipe Create(GameObject prefab, ObjectDB objectDb)
        {
            if (prefab == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeRecipe) + ": prefab was null.");
                return null;
            }

            if (objectDb == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeRecipe) + ": objectDb was null.");
                return null;
            }

            if (objectDb.m_recipes == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeRecipe) + ": ObjectDB.m_recipes was null.");
                return null;
            }

            var itemDrop = prefab.GetComponent<ItemDrop>();
            if (itemDrop == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeRecipe) + ": prefab was missing ItemDrop.");
                return null;
            }

            // Find the vanilla Ash cape recipe to mirror requirements from
            Recipe vanillaRecipe = null;

            // Try to find the vanilla ash prefab first
            string[] ashCandidates = new[] { "Cape_Ash", "CapeAsh", "cape_ash", "capeash", "Cape_Ashen", "CapeAshen", "cape_ash" };
            GameObject ashPrefab = null;
            foreach (var name in ashCandidates)
            {
                ashPrefab = objectDb.GetItemPrefab(name);
                if (ashPrefab != null) break;
            }

            if (ashPrefab == null)
            {
                ashPrefab = Resources.FindObjectsOfTypeAll<ItemDrop>()
                    .FirstOrDefault(i => i != null && i.name.ToLower().Contains("ash"))?.gameObject;
            }

            if (ashPrefab != null)
            {
                foreach (var recipe in objectDb.m_recipes)
                {
                    if (recipe == null || recipe.m_item == null || recipe.m_item.gameObject == null) continue;
                    if (recipe.m_item.gameObject.name == ashPrefab.name)
                    {
                        vanillaRecipe = recipe;
                        break;
                    }
                }
            }

            // Fallback to CapeFeather recipe if ash recipe not found
            if (vanillaRecipe == null)
            {
                foreach (var recipe in objectDb.m_recipes)
                {
                    if (recipe == null || recipe.m_item == null || recipe.m_item.gameObject == null) continue;
                    if (recipe.m_item.gameObject.name == ItemNames.CapeFeather)
                    {
                        vanillaRecipe = recipe;
                        break;
                    }
                }
            }

            if (vanillaRecipe == null)
            {
                Plugin.Log.LogError(nameof(AshenCapeRecipe) + ": Could not find a vanilla cape recipe to base on.");
                return null;
            }

            var newRecipe = ScriptableObject.Instantiate(vanillaRecipe);
            newRecipe.name = RecipeName;
            newRecipe.m_item = itemDrop;

            // Prefer Black Forge as crafting station if available; otherwise keep vanilla station.
            try
            {
                // Prefer an exact match to the vanilla black forge prefab name to avoid selecting mod mock stations
                var stations = Resources.FindObjectsOfTypeAll<CraftingStation>();
                var exact = stations.FirstOrDefault(cs => cs != null && string.Equals(cs.gameObject?.name, "blackforge", StringComparison.OrdinalIgnoreCase));
                if (exact != null)
                {
                    newRecipe.m_craftingStation = exact;
                    newRecipe.m_minStationLevel = 1; // keep reasonable station level
                    Plugin.Log.LogInfo(nameof(AshenCapeRecipe) + ": Selected exact-match crafting station -> " + exact.gameObject.name);
                }
                else
                {
                    // Fallback to previous heuristic (substring)
                    var heuristic = stations.FirstOrDefault(cs => cs != null && cs.name.ToLower().Contains("black"));
                    if (heuristic != null)
                    {
                        newRecipe.m_craftingStation = heuristic;
                        newRecipe.m_minStationLevel = 1;
                        Plugin.Log.LogInfo(nameof(AshenCapeRecipe) + ": Selected heuristic crafting station -> " + heuristic.gameObject.name);
                    }
                    else
                    {
                        newRecipe.m_craftingStation = vanillaRecipe.m_craftingStation;
                        newRecipe.m_minStationLevel = vanillaRecipe.m_minStationLevel;
                        Plugin.Log.LogInfo(nameof(AshenCapeRecipe) + ": Black Forge not found; using vanilla crafting station.");
                    }
                }
            }
            catch (Exception ex)
            {
                newRecipe.m_craftingStation = vanillaRecipe.m_craftingStation;
                newRecipe.m_minStationLevel = vanillaRecipe.m_minStationLevel;
                Plugin.Log.LogWarning(nameof(AshenCapeRecipe) + ": Error while searching for Black Forge; using vanilla station. " + ex);
            }

            // Copy vanilla requirements first
            var requirements = new List<Piece.Requirement>();
            foreach (var req in vanillaRecipe.m_resources)
            {
                if (req == null || req.m_resItem == null) continue;

                requirements.Add(new Piece.Requirement
                {
                    m_resItem = req.m_resItem,
                    m_amount = req.m_amount,
                    m_amountPerLevel = req.m_amountPerLevel,
                    m_recover = req.m_recover
                });
            }

            // Add 10 feathers (try common vanilla names)
            var featherReq = CreateBestEffortRequirement(objectDb, new[] { "Feathers", "Feather" }, 10);
            if (featherReq == null || featherReq.m_resItem == null)
            {
                Plugin.Log.LogWarning(nameof(AshenCapeRecipe) + ": Could not find feather item prefab; feather requirement not added.");
            }
            else
            {
                requirements.Add(featherReq);
            }

            // Add 5 Surtling Cores
            var surtlingReq = CreateRequirement(objectDb, ItemNames.SurtlingCore, 5);
            if (surtlingReq == null || surtlingReq.m_resItem == null)
            {
                Plugin.Log.LogWarning(nameof(AshenCapeRecipe) + ": Could not create Surtling Core requirement.");
            }
            else
            {
                requirements.Add(surtlingReq);
            }

            newRecipe.m_resources = requirements.ToArray();

            Plugin.Log.LogInfo(nameof(AshenCapeRecipe) + ": Built recipe " + newRecipe.name);

            return newRecipe;
        }

        private static Piece.Requirement CreateRequirement(ObjectDB objectDb, string name, int amount)
        {
            var prefab = objectDb.GetItemPrefab(name);
            var itemDrop = prefab?.GetComponent<ItemDrop>();

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

        // Try multiple candidate names and return the first valid requirement found.
        private static Piece.Requirement CreateBestEffortRequirement(ObjectDB objectDb, string[] candidateNames, int amount)
        {
            foreach (var name in candidateNames)
            {
                var req = CreateRequirement(objectDb, name, amount);
                if (req != null && req.m_resItem != null) return req;
            }

            // As a last resort try to find an ItemDrop by inspecting all loaded prefabs for likely names
            var found = Resources.FindObjectsOfTypeAll<ItemDrop>()
                                 .FirstOrDefault(i => i != null && candidateNames.Any(c => i.name.ToLower().Contains(c.ToLower())));
            if (found != null)
            {
                return new Piece.Requirement
                {
                    m_resItem = found,
                    m_amount = amount,
                    m_amountPerLevel = 0,
                    m_recover = true
                };
            }

            return null;
        }
    }
}
