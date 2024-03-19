using System;
using UnityEngine;

namespace Pixygon.Skills {
    public class StatsBase : MonoBehaviour {
    }

    public enum StatNames {
        Hp,
        Speed,
        ReloadSpeed,
        FireRate,
        MagicDamage,
        ProjectileSpeed,
        ProjectileDamage,
        ProjectileCount, //How many times you can fire before reload
        ProjectileNumber, //How many projectiles appear on each fire
        ProjectileSpread,
        ProjectilePiercing,
        ProjectileBounce,
        MagnetPower,
        XpGain,
        ProjectileKnockBack,
        ProjectileSize,
        BurnActivationRate,
        DazeActivationRate,
        FreezeActivationRate,
        ZapActivationRate,
        ShieldRegenSpeed,
        KnockbackRate,
        BurnFieldRate,
        BurnDamage,
        ProjectileKillSpeed,
        ProjectileRipple,
        ProjectileHoming,
        RollSpeed,
        Stamina,
        StaminaRegenSpeed,
        CriticalHitRate,
        CriticalHitIncrease,
        ExplosiveRate,
        ExplosiveRank,
        Zoom,
        Darkness,
        DamageDodge,
        EarthBall,
        WaterBall,
        Size,
    }

    public enum SpecialSkills {
        None = 0,
        Shield = 1,
        Totem = 2,
        Fire = 3,
        FireLaser = 4,
        FireBall = 5,
        FireSteps = 6,
        FirePillar = 7,
        FireSummon = 8,
        Earth = 9,

        //EarthBall = 10,
        EarthMines = 11,
        EarthSummon = 12,
        Water = 13,

        //WaterBall = 14,
        WaterSummon = 15,
        Air = 16,
        AirBall = 17,
        AirZap = 18,
        AirUltimate = 19,
        AirSummon = 20,
        SpikeRoll = 21,
        FireRoll = 22,
        WaterRoll = 23,
        EarthRoll = 24,
        AirRoll = 25,
        Backshot = 26,
        ReloadRoll = 27,
        ExplodingRoll = 28,
        ShieldFire = 29,
        Dodge = 30,
        HiddenSkills = 31,
        InvertedControls = 32,
        ToTheMoon = 33,
        BlastResistance = 34,
        ThunderBlast = 35,
        FireBlast = 36,
        WaterBlast = 37,
        StoneWall = 38
    }

    public enum Ailments {
        Burn,
        Daze,
        Freeze,
        Zap,
        None,
        All
    }

    public enum DamageType {
        Normal,
        Fire,
        Earth,
        Water,
        Air,
        Aether,
        Summon
    }

    [Serializable]
    public class StatData {
        public float _value;
        public string _title;
        public string _description;
    }
}