using HexArmory.Core.Models;
using Jotunn.Managers;

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

            if (itemDefinition.StatsOverride != null)
            {
                ApplyWeaponStats(itemDrop, itemDefinition.StatsOverride);
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
                Jotunn.Logger.LogError("[HexArmory] Invalid target ItemDrop.");
                return;
            }

            if (string.IsNullOrEmpty(sourcePrefabName))
            {
                Jotunn.Logger.LogWarning("[HexArmory] No source prefab specified for equip effect override.");
                return;
            }

            var targetShared = targetItemDrop.m_itemData.m_shared;

            var sourcePrefab = PrefabManager.Instance.GetPrefab(sourcePrefabName);

            if (sourcePrefab == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] Could not find source prefab: {sourcePrefabName}");
                return;
            }

            var sourceDrop = sourcePrefab.GetComponent<ItemDrop>();

            if (sourceDrop == null ||
                sourceDrop.m_itemData == null ||
                sourceDrop.m_itemData.m_shared == null ||
                sourceDrop.m_itemData.m_shared.m_equipStatusEffect == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] Source prefab {sourcePrefabName} has no equip effect.");
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
                $"[HexArmory] Applied equip effect from {sourcePrefabName} to {targetItemDrop.name}: {effectClone.name}");
        }

        private static void ApplyWeaponStats(ItemDrop itemDrop, ItemStatsOverride stats)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError("[HexArmory] Invalid ItemDrop while applying weapon stats.");
                return;
            }

            if (stats == null)
            {
                Jotunn.Logger.LogWarning($"[HexArmory] No weapon stats override found for {itemDrop.name}.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            shared.m_damages.m_slash = stats.SlashDamage;
            shared.m_damages.m_pierce = stats.PierceDamage;
            shared.m_damages.m_chop = stats.ChopDamage;

            shared.m_damagesPerLevel.m_slash = stats.SlashDamagePerLevel;
            shared.m_damagesPerLevel.m_pierce = stats.PierceDamagePerLevel;
            shared.m_damagesPerLevel.m_chop = stats.ChopDamagePerLevel;

            shared.m_maxQuality = stats.MaxQuality;

            shared.m_attackForce = stats.AttackForce;
            shared.m_backstabBonus = stats.BackstabBonus;

            shared.m_blockPower = stats.BlockPower;
            shared.m_blockPowerPerLevel = stats.BlockPowerPerLevel;

            shared.m_deflectionForce = stats.DeflectionForce;
            shared.m_deflectionForcePerLevel = stats.DeflectionForcePerLevel;

            shared.m_durabilityPerLevel = stats.DurabilityPerLevel;
            shared.m_useDurabilityDrain = stats.UseDurabilityDrain;
            shared.m_movementModifier = stats.MovementModifier;

            shared.m_attack.m_attackStamina = stats.AttackStamina;

            Jotunn.Logger.LogInfo(
                $"[HexArmory] Applied weapon stats to {itemDrop.name}. " +
                $"Slash={shared.m_damages.m_slash}, Pierce={shared.m_damages.m_pierce}, " +
                $"SlashPerLevel={shared.m_damagesPerLevel.m_slash}, PiercePerLevel={shared.m_damagesPerLevel.m_pierce}, " +
                $"MaxQuality={shared.m_maxQuality}");
        }

        private static void RemoveDamageModifier(ItemDrop itemDrop, HitData.DamageType damageType)
        {
            if (itemDrop == null ||
                itemDrop.m_itemData == null ||
                itemDrop.m_itemData.m_shared == null)
            {
                Jotunn.Logger.LogError($"[HexArmory] Invalid ItemDrop while removing {damageType} modifier.");
                return;
            }

            var shared = itemDrop.m_itemData.m_shared;

            int removedCount = shared.m_damageModifiers.RemoveAll(
                mod => mod.m_type == damageType);

            if (removedCount > 0)
            {
                Jotunn.Logger.LogInfo(
                    $"[HexArmory] Removed {removedCount} {damageType} damage modifier(s) from {itemDrop.name ?? "Unknown"}.");
            }
            else
            {
                Jotunn.Logger.LogDebug(
                    $"[HexArmory] No {damageType} damage modifiers found on {itemDrop.name ?? "Unknown"}.");
            }
        }
    }
}
