using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class BLU
    {
        public const byte JobID = 36;

        public const uint
            Addle = 7560,
            RoseOfDestruction = 23275,
            ShockStrike = 11429,
            JKick = 18325,
            Eruption = 11427,
            GlassDance = 11430,
            Surpanakha = 18323,
            Nightbloom = 23290,
            MoonFlute = 11415,
            Whistle = 18309,
            Tingle = 23265,
            TripleTrident = 23264,
            FinalSting = 11407,
            Bristle = 11393,
            SongOfTorment = 11386;

        public static class Buffs
        {
            public const ushort
                MoonFlute = 1718,
                Bristle = 1716,
                Tingle = 2492,
                Whistle = 2118;
        }

        public static class Debuffs
        {
            public const short
                SongOfTorment = 273;
        }

        public static class Levels
        {
            public const byte
                LucidDreaming = 24;
        }
    }

    internal class BluDoT : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BluDoT;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLU.Bristle)
            {
                if (!HasEffect(BLU.Buffs.Bristle))
                    return BLU.Bristle;
                return BLU.SongOfTorment;
            }

            return actionID;
        }
    }

    internal class BluLimitBreak : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BluLimitBreak;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLU.FinalSting)
            {
                if (!HasEffect(BLU.Buffs.Whistle))
                    return BLU.Whistle;
                if (!HasEffect(BLU.Buffs.MoonFlute))
                    return BLU.MoonFlute;
                return BLU.FinalSting;
            }

            return actionID;
        }
    }

    internal class BluBurstCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BluBurstCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLU.Nightbloom)
            {
                if (!GetCooldown(BLU.JKick).IsCooldown)
                    return BLU.JKick;
                if (!GetCooldown(BLU.Nightbloom).IsCooldown)
                    return BLU.Nightbloom;
                if (!GetCooldown(BLU.ShockStrike).IsCooldown)
                    return BLU.ShockStrike;
                if (!GetCooldown(BLU.GlassDance).IsCooldown)
                    return BLU.GlassDance;
                return BLU.Surpanakha;
            }

            return actionID;
        }
    }

    internal class BluTridentCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BluTridentCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLU.Tingle)
            {
                if (GetCooldown(BLU.TripleTrident).CooldownRemaining < 3)
                {
                    if (!HasEffect(BLU.Buffs.Whistle))
                        return BLU.Whistle;
                    if (!HasEffect(BLU.Buffs.Tingle))
                        return BLU.Tingle;
                    if (!HasEffect(BLU.Buffs.MoonFlute) && !HasCondition(ConditionFlag.InCombat))
                        return BLU.MoonFlute;
                    if (!GetCooldown(BLU.JKick).IsCooldown)
                        return BLU.JKick;
                    if (!GetCooldown(BLU.TripleTrident).IsCooldown)
                        return BLU.TripleTrident;
                }

                if (!GetCooldown(BLU.JKick).IsCooldown)
                    return BLU.JKick;
                if (!GetCooldown(BLU.Nightbloom).IsCooldown)
                    return BLU.Nightbloom;
                if (!GetCooldown(BLU.RoseOfDestruction).IsCooldown)
                    return BLU.RoseOfDestruction;
                if (!GetCooldown(BLU.ShockStrike).IsCooldown)
                    return BLU.ShockStrike;
                if (!GetCooldown(BLU.GlassDance).IsCooldown)
                    return BLU.GlassDance;
                return BLU.Surpanakha;
            }

            return actionID;
        }
    }
}