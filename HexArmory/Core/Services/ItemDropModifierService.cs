using HexArmory.Core.Models;
using Jotunn.Managers;
using System.Collections.Generic;

namespace HexArmory.Core.Services
{
    internal static class ItemDropModifierService
    {
        internal static void ApplyModifications(ItemDrop itemDrop, ItemDefinitionEntry itemDefinition)
        {
            if (itemDrop == null || itemDefinition == null)
            {
                return;
            }

            if (itemDefinition.DamageTypesToRemove != null && itemDefinition.DamageTypesToRemove.Length > 0)
            {
                RemoveDamageModifiers(itemDrop, itemDefinition.DamageTypesToRemove);
            }

            if (!string.IsNullOrEmpty(itemDefinition.OverrideEquipEffectFromPrefab))
            {
                OverrideEquipEffect(itemDrop, itemDefinition.OverrideEquipEffectFromPrefab);
            }

            if (itemDefinition.AddDamageModifiers != null)
            {
                AddDamageModifiers(itemDrop, itemDefinition.AddDamageModifiers);
            }

            if (itemDefinition.StatsOverride != null)
            {
                ApplyWeaponStats(itemDrop, itemDefinition.StatsOverride);
            }

            if(itemDefinition.EquipStatusEffect != null)
            {
                ApplyEquippedStatusEffect(itemDrop, itemDefinition.EquipStatusEffect);
            }
        }

        private static void RemoveDamageModifiers(ItemDrop itemDrop, HitData.DamageType[] damageTypes)
        {
            if (damageTypes == null || damageTypes.Length == 0)
            {
                return;
            }

            foreach (var damageType in damageTypes)
            {
                RemoveDamageModifier(itemDrop, damageType);
            }
        }

        private static void OverrideEquipEffect(ItemDrop targetItemDrop, string sourcePrefabName)
        {
            if (targetItemDrop == null ||
                targetItemDrop.m_itemData == null ||
                targetItemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("Invalid target ItemDrop.");
                return;
            }

            if (string.IsNullOrEmpty(sourcePrefabName))
            {
                Jotunn.Logger.LogWarning("No source prefab specified for equip effect override.");
                return;
            }

            var targetShared = targetItemDrop.m_itemData.m_shared;

            var sourcePrefab = PrefabManager.Instance.GetPrefab(sourcePrefabName);

            Jotunn.Logger.LogInfo($"Attempting to override equip effect on {targetItemDrop.name} using source prefab: {sourcePrefabName}");

            if (sourcePrefab == null)
            {
                Jotunn.Logger.LogError($"Could not find source prefab: {sourcePrefabName}");
                return;
            }

            var sourceDrop = sourcePrefab.GetComponent<ItemDrop>();

            if (sourceDrop == null ||
                sourceDrop.m_itemData == null ||
                sourceDrop.m_itemData.m_shared == null ||
                sourceDrop.m_itemData.m_shared.m_equipStatusEffect == null)
            {
                Jotunn.Logger.LogError($"Source prefab {sourcePrefabName} has no equip effect.");
                return;
            }

            var sourceEffect = sourceDrop.m_itemData.m_shared.m_equipStatusEffect;

            if (targetShared.m_equipStatusEffect != null)
            {
                Jotunn.Logger.LogInfo(
                    $"[HexArmory] Replacing existing equip effect on {targetItemDrop.name}: {targetShared.m_equipStatusEffect.name}");
            }

            var effectClone = UnityEngine.Object.Instantiate(sourceEffect);
            effectClone.name = $"SE_HexArmory_{targetItemDrop.name}";

            targetShared.m_equipStatusEffect = effectClone;

            Jotunn.Logger.LogInfo(
                $"Applied equip effect from {sourcePrefabName} to {targetItemDrop.name}: {effectClone.name}");
        }

        private static void AddDamageModifiers(ItemDrop targetItemDrop, List<HitData.DamageModPair> damageModifiers)
        {
            if (targetItemDrop == null ||
                targetItemDrop.m_itemData == null ||
                targetItemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("Invalid target ItemDrop.");
                return;
            }

            if (damageModifiers == null || damageModifiers.Count == 0)
            {
                Jotunn.Logger.LogWarning("No damage modifiers to add.");
                return;
            }

            var targetModifiers = targetItemDrop.m_itemData.m_shared.m_damageModifiers;

            foreach (var modifier in damageModifiers)
            {
                targetModifiers.RemoveAll(mod => mod.m_type == modifier.m_type);
                targetModifiers.Add(new HitData.DamageModPair
                {
                    m_type = modifier.m_type,
                    m_modifier = modifier.m_modifier
                });

                Jotunn.Logger.LogInfo(
                    $"Added damage modifier to {targetItemDrop.name}: {modifier.m_type} = {modifier.m_modifier}");
            }
        }

        private static void ApplyWeaponStats(ItemDrop itemDrop, ItemStatsOverride stats)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("Invalid ItemDrop while applying weapon stats.");
                return;
            }

            if (stats == null)
            {
                Jotunn.Logger.LogWarning($"No weapon stats override found for {itemDrop.name}.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            shared.m_damages.m_slash = stats.SlashDamage ?? shared.m_damages.m_slash;
            shared.m_damages.m_pierce = stats.PierceDamage ?? shared.m_damages.m_pierce;
            shared.m_damages.m_chop = stats.ChopDamage ?? shared.m_damages.m_chop;
            shared.m_damages.m_blunt = stats.BluntDamage ?? shared.m_damages.m_blunt;
            shared.m_damages.m_spirit = stats.Spirit ?? shared.m_damages.m_spirit;
            shared.m_damages.m_fire = stats.Fire ?? shared.m_damages.m_fire;
            shared.m_damages.m_frost = stats.Frost ?? shared.m_damages.m_frost;
            shared.m_damages.m_poison = stats.Poison ?? shared.m_damages.m_poison;
            shared.m_damages.m_lightning = stats.Lightning ?? shared.m_damages.m_lightning;

            shared.m_damagesPerLevel.m_slash = stats.SlashDamagePerLevel ?? shared.m_damagesPerLevel.m_slash;
            shared.m_damagesPerLevel.m_pierce = stats.PierceDamagePerLevel ?? shared.m_damagesPerLevel.m_pierce;
            shared.m_damagesPerLevel.m_chop = stats.ChopDamagePerLevel ?? shared.m_damagesPerLevel.m_chop;

            shared.m_maxQuality = stats.MaxQuality ?? shared.m_maxQuality;

            shared.m_attackForce = stats.AttackForce ?? shared.m_attackForce;
            shared.m_backstabBonus = stats.BackstabBonus ?? shared.m_backstabBonus;

            shared.m_blockPower = stats.BlockPower ?? shared.m_blockPower;
            shared.m_blockPowerPerLevel = stats.BlockPowerPerLevel ?? shared.m_blockPowerPerLevel;

            shared.m_deflectionForce = stats.DeflectionForce ?? shared.m_deflectionForce;
            shared.m_deflectionForcePerLevel = stats.DeflectionForcePerLevel ?? shared.m_deflectionForcePerLevel;

            shared.m_maxDurability = stats.MaxDurability ?? shared.m_maxDurability;
            shared.m_durabilityPerLevel = stats.DurabilityPerLevel ?? shared.m_durabilityPerLevel;
            shared.m_useDurabilityDrain = stats.UseDurabilityDrain ?? shared.m_useDurabilityDrain;
            shared.m_movementModifier = stats.MovementModifier ?? shared.m_movementModifier;

            shared.m_attack.m_attackStamina = stats.AttackStamina ?? shared.m_attack.m_attackStamina;
            shared.m_timedBlockBonus = stats.TimedBlockBonus ?? shared.m_timedBlockBonus;

            shared.m_toolTier = stats.ToolTier ?? shared.m_toolTier;

            Jotunn.Logger.LogDebug(
                $"Applied weapon stats to {itemDrop.name}. " +
                $"Slash={shared.m_damages.m_slash}, Pierce={shared.m_damages.m_pierce}, " +
                $"Spirit={shared.m_damages.m_spirit}, Fire={shared.m_damages.m_fire}, Frost={shared.m_damages.m_frost}, " +
                $"MaxQuality={shared.m_maxQuality}");
        }

        private static void RemoveDamageModifier(ItemDrop itemDrop, HitData.DamageType damageType)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError($"Invalid ItemDrop while removing {damageType} modifier.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            int removedCount = shared.m_damageModifiers.RemoveAll(
                mod => mod.m_type == damageType);

            if (removedCount > 0)
            {
                Jotunn.Logger.LogInfo(
                    $"Removed {removedCount} {damageType} damage modifier(s) from {itemDrop.name ?? "Unknown"}.");
            }
            else
            {
                Jotunn.Logger.LogDebug(
                    $"No {damageType} damage modifiers found on {itemDrop.name ?? "Unknown"}.");
            }
        }

        private static void ApplyEquippedStatusEffect(ItemDrop itemDrop, StatusEffect equipStatusEffect)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("Invalid ItemDrop while applying equip status effect.");
                return;
            }

            if (equipStatusEffect == null)
            {
                Jotunn.Logger.LogWarning($"No equip status effect provided for {itemDrop.name}.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            if (shared.m_equipStatusEffect != null)
            {
                Jotunn.Logger.LogInfo(
                    $"[HexArmory] Replacing equip status effect on {itemDrop.name}: {shared.m_equipStatusEffect.name}");
            }

            shared.m_equipStatusEffect = equipStatusEffect;

            Jotunn.Logger.LogInfo(
                $"[HexArmory] Applied equip status effect to {itemDrop.name}: {equipStatusEffect.name}");
        }
    }
}
