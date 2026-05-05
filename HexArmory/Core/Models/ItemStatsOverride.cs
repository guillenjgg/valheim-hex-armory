namespace HexArmory.Core.Models
{
    internal sealed class ItemStatsOverride
    {
        internal float SlashDamage { get; set; }
        internal float PierceDamage { get; set; }

        internal float SlashDamagePerLevel { get; set; }
        internal float PierceDamagePerLevel { get; set; }

        internal int MaxQuality { get; set; }

        internal float AttackForce { get; set; }
        internal float BackstabBonus { get; set; }

        internal float BlockPower { get; set; }
        internal float BlockPowerPerLevel { get; set; }

        internal float DeflectionForce { get; set; }
        internal float DeflectionForcePerLevel { get; set; }

        internal float DurabilityPerLevel { get; set; }
        internal float DurabilityDrain { get; set; }
        internal float MovementModifier { get; set; }
        internal float AttackStamina { get; set; }
    }
}
