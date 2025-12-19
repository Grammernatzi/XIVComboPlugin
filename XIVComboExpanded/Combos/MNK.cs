using System;
using System.Linq;

using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class MNK
    {
        public const byte ClassID = 2;
        public const byte JobID = 20;

        public const uint
            Bootshine = 53,
            LeapingOpo = 36945,
            DragonKick = 74,
            TrueStrike = 54,
            RisingRaptor = 36946,
            SnapPunch = 56,
            PouncingCoeurl = 36947,
            TwinSnakes = 61,
            Demolish = 66,
            ArmOfTheDestroyer = 62,
            PerfectBalance = 69,
            Rockbreaker = 70,
            Meditation = 36942,
            SteeledMeditation = 36940,
            EnlightenedMeditation = 36943,
            ForbiddenChakra = 3547,
            FormShift = 4262,
            FourPointFury = 16473,
            HowlingFist = 25763,
            Enlightenment = 16474,
            SixSidedStar = 16476,
            MasterfulBlitz = 25764,
            ShadowOfTheDestroyer = 25767,
            RiddleOfFire = 7395,
            Brotherhood = 7396,
            RiddleOfWind = 25766,
            Thunderclap = 25762;

        public static class Buffs
        {
            public const ushort
                TwinSnakes = 101,
                OpoOpoForm = 107,
                RaptorForm = 108,
                CoeurlForm = 109,
                PerfectBalance = 110,
                LeadenFist = 1861,
                Brotherhood = 1185,
                FormlessFist = 2513;
        }

        public static class Debuffs
        {
            public const ushort
                Demolish = 246;
        }

        public static class Levels
        {
            public const byte
                TrueStrike = 4,
                SnapPunch = 6,
                Meditation = 15,
                TwinSnakes = 18,
                Rockbreaker = 30,
                Demolish = 30,
                FourPointFury = 45,
                HowlingFist = 40,
                DragonKick = 50,
                FormShift = 52,
                MasterfulBlitz = 60,
                Brotherhood = 70,
                RiddleOfWind = 72,
                Enlightenment = 74,
                ShadowOfTheDestroyer = 82;
        }
    }

    internal class MonkBrotherhoodLockoutFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkBrotherhoodLockoutFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            return actionID == MNK.Brotherhood && HasEffectAny(MNK.Buffs.Brotherhood) && FindEffectAny(MNK.Buffs.Brotherhood)?.RemainingTime > 3 && IsActionOffCooldown(MNK.Brotherhood) ? SMN.Physick : MNK.Brotherhood;
        }
    }

    internal class MonkRiddleToBrotherFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkRiddleToBrotherFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            return (actionID == MNK.RiddleOfFire && IsActionOffCooldown(MNK.Brotherhood) && CanUseAction(MNK.Brotherhood))
                && (!IsEnabled(CustomComboPreset.MonkBrotherhoodLockoutFeature) || !(HasEffectAny(MNK.Buffs.Brotherhood) && FindEffectAny(MNK.Buffs.Brotherhood)?.RemainingTime > 3)) ? MNK.Brotherhood : actionID;
        }
    }

    internal class MonkRiddleToRiddleFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkRiddleToRiddleFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (OriginalHook(MNK.RiddleOfWind) != MNK.RiddleOfWind)
                return OriginalHook(MNK.RiddleOfWind);
            return (actionID == MNK.RiddleOfFire && IsActionOffCooldown(MNK.RiddleOfWind) && !IsActionOffCooldown(MNK.RiddleOfFire) && level >= MNK.Levels.RiddleOfWind) ? MNK.RiddleOfWind : actionID;
        }
    }

    internal class MonkMeditationReminder : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkMeditationReminder;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<MNKGauge>();
            return !HasCondition(ConditionFlag.InCombat) && gauge.Chakra < 5 && CanUseAction(OriginalHook(MNK.Meditation)) ? OriginalHook(MNK.Meditation) : actionID;
        }
    }

    internal class MonkChakraToEnlightenment : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkChakraToEnlightmentFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<MNKGauge>();
            return gauge.Chakra >= 5 && CanUseAction(OriginalHook(MNK.Enlightenment)) && (this.FilteredLastComboMove == MNK.ShadowOfTheDestroyer || this.FilteredLastComboMove == MNK.ArmOfTheDestroyer || this.FilteredLastComboMove == MNK.FourPointFury || this.FilteredLastComboMove == MNK.Rockbreaker) ? OriginalHook(MNK.Enlightenment) : actionID;
        }
    }

    internal class MonkChakraKick : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkChakraKickFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            return CanUseAction(OriginalHook(MNK.ForbiddenChakra)) && GCDClipCheck() ? OriginalHook(MNK.ForbiddenChakra) : actionID;
        }
    }

    internal class MonkOpoCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkOpoCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<MNKGauge>();

            if ((!InMeleeRange() || CurrentTarget?.ObjectKind == Dalamud.Game.ClientState.Objects.Enums.ObjectKind.Player) && CanUseAction(MNK.Thunderclap) && IsEnabled(CustomComboPreset.MonkDragonClapFeature))
                return MNK.Thunderclap;

            if (IsEnabled(CustomComboPreset.MonkDragonKickBalanceFeature) && !gauge.BeastChakra.Contains(BeastChakra.None) && CanUseAction(OriginalHook(MNK.MasterfulBlitz)))
                return OriginalHook(MNK.MasterfulBlitz);

            if (HasEffect(MNK.Buffs.RaptorForm))
            {
                if (gauge.RaptorFury == 0 && level >= MNK.Levels.TwinSnakes && IsEnabled(CustomComboPreset.MonkTwinRaptorsFeature) && !IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption))
                    return MNK.TwinSnakes;
                return OriginalHook(MNK.TrueStrike);
            }

            if (HasEffect(MNK.Buffs.CoeurlForm))
            {
                if (gauge.CoeurlFury == 0 && level >= MNK.Levels.Demolish && IsEnabled(CustomComboPreset.MonkDemolishingPounceFeature) && !IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption))
                    return MNK.Demolish;
                return OriginalHook(MNK.SnapPunch);
            }

            bool hasForm = HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.OpoOpoForm);
            if ((gauge.OpoOpoFury == 0 || !hasForm) && level >= MNK.Levels.DragonKick && IsEnabled(CustomComboPreset.MonkDragonKickBootshineFeature)
                && (!IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) || (HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist))))
                return MNK.DragonKick;

            return actionID;
        }
    }

    internal class MonkDragonClapFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkDragonClapFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((!InMeleeRange() || CurrentTarget?.ObjectKind == Dalamud.Game.ClientState.Objects.Enums.ObjectKind.Player) && CanUseAction(MNK.Thunderclap))
                return MNK.Thunderclap;

            return actionID;
        }
    }

    internal class MonkDragonKickCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkDragonKickCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.DragonKick)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (IsEnabled(CustomComboPreset.MonkDragonClapFeature) && (!InMeleeRange() || CurrentTarget?.ObjectKind == Dalamud.Game.ClientState.Objects.Enums.ObjectKind.Player) && CanUseAction(MNK.Thunderclap))
                    return MNK.Thunderclap;

                if (IsEnabled(CustomComboPreset.MonkDragonKickBalanceFeature))
                {
                    if (!gauge.BeastChakra.Contains(BeastChakra.None) && CanUseAction(OriginalHook(MNK.MasterfulBlitz)))
                        return OriginalHook(MNK.MasterfulBlitz);
                }

                if (HasEffect(MNK.Buffs.RaptorForm))
                {
                    if (IsEnabled(CustomComboPreset.MonkTwinRaptorsFeature) && !IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) && (gauge.RaptorFury > 0 || level < MNK.Levels.TwinSnakes))
                        return OriginalHook(MNK.TrueStrike);
                    return MNK.TwinSnakes;
                }

                if (HasEffect(MNK.Buffs.CoeurlForm))
                {
                    if ((gauge.CoeurlFury > 0 || level < MNK.Levels.Demolish) && IsEnabled(CustomComboPreset.MonkDemolishingPounceFeature) && !IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption))
                        return OriginalHook(MNK.SnapPunch);
                    return MNK.Demolish;
                }

                bool hasForm = HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.OpoOpoForm) || level < MNK.Levels.DragonKick;

                if ((gauge.OpoOpoFury > 0 || level < MNK.Levels.DragonKick) && hasForm && IsEnabled(CustomComboPreset.MonkDragonKickBootshineFeature)
                    && (!IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) || HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist)))
                    return OriginalHook(MNK.Bootshine);
            }

            return actionID;
        }
    }

    internal class MonkFormSnakes : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkFormSnakes;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.FormShift && HasEffect(MNK.Buffs.PerfectBalance))
            {
                var gauge = GetJobGauge<MNKGauge>();
                if (IsEnabled(CustomComboPreset.MonkTwinRaptorsFeature))
                    if (gauge.RaptorFury > 0)
                        return OriginalHook(MNK.TrueStrike);
                return MNK.TwinSnakes;
            }

            return actionID;
        }
    }

    internal class MonkPerfectBalanceDemolishFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkPerfectBalanceDemolishFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance))
            {
                var gauge = GetJobGauge<MNKGauge>();
                if (IsEnabled(CustomComboPreset.MonkDemolishingPounceFeature))
                    if (gauge.CoeurlFury > 0)
                        return OriginalHook(MNK.SnapPunch);
                return MNK.Demolish;
            }

            return actionID;
        }
    }

    internal class MonkAoECombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkAoECombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == (IsEnabled(CustomComboPreset.MonkAoEComboFormOption) ? MNK.FormShift : MNK.FourPointFury))
            {
                IStatus? pb = FindEffect(MNK.Buffs.PerfectBalance);

                var gauge = GetJobGauge<MNKGauge>();

                if (HasEffect(MNK.Buffs.PerfectBalance))
                {
                    switch (pb?.Param)
                    {
                        case 3:
                            return MNK.FourPointFury;
                        case 2:
                            if (!gauge.BeastChakra.Contains(BeastChakra.Raptor))
                                return MNK.FourPointFury;
                            return MNK.Rockbreaker;
                        case 1:
                            if (gauge.BeastChakra.Contains(BeastChakra.OpoOpo) && !gauge.BeastChakra.Contains(BeastChakra.Raptor))
                                return MNK.FourPointFury;
                            if (!gauge.BeastChakra.Contains(BeastChakra.Coeurl))
                                return MNK.Rockbreaker;
                            return OriginalHook(MNK.ArmOfTheDestroyer);
                    }
                }
            }

            if (actionID == (IsEnabled(CustomComboPreset.MonkAoEComboBlitzOption) ? PLD.TotalEclipse : MNK.MasterfulBlitz))
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (IsEnabled(CustomComboPreset.MonkAoEMeditationFeature) && gauge.Chakra >= 5 && CanUseAction(OriginalHook(MNK.HowlingFist)) && CurrentTarget is not null && HasCondition(ConditionFlag.InCombat) && GetCooldown(PLD.FastBlade).CooldownRemaining >= 0.5)
                    return OriginalHook(MNK.HowlingFist);

                if (OriginalHook(MNK.MasterfulBlitz) != MNK.MasterfulBlitz && CanUseAction(OriginalHook(MNK.MasterfulBlitz)) && !IsEnabled(CustomComboPreset.MonkAoEComboBlitzOption))
                    return OriginalHook(MNK.MasterfulBlitz);

                if (HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist))
                {
                    if (level >= MNK.Levels.ShadowOfTheDestroyer)
                    {
                        return OriginalHook(MNK.ArmOfTheDestroyer);
                    }

                    return MNK.Rockbreaker;
                }

                if (HasEffect(MNK.Buffs.OpoOpoForm))
                    return OriginalHook(MNK.ArmOfTheDestroyer);

                if (HasEffect(MNK.Buffs.RaptorForm) && CanUseAction(MNK.FourPointFury))
                    return MNK.FourPointFury;

                if (HasEffect(MNK.Buffs.CoeurlForm) && CanUseAction(MNK.Rockbreaker))
                    return MNK.Rockbreaker;

                return OriginalHook(MNK.ArmOfTheDestroyer);
            }

            return actionID;
        }
    }

    internal class MonkDragonKickBalanceFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkDragonKickBalanceFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (OriginalHook(MNK.MasterfulBlitz) != MNK.MasterfulBlitz && CanUseAction(OriginalHook(MNK.MasterfulBlitz)))
                return OriginalHook(MNK.MasterfulBlitz);

            return actionID;
        }
    }

    internal class MonkDragonKickBootshineFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkDragonKickBootshineFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            bool hasForm = HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.OpoOpoForm);

            if (new[] { MNK.Bootshine, MNK.LeapingOpo, MNK.DragonKick }.Contains(actionID) && hasForm && (!IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) || HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist)))
            {
                var gauge = GetJobGauge<MNKGauge>();
                if (gauge.OpoOpoFury > 0 || level < MNK.Levels.DragonKick)
                    return OriginalHook(MNK.Bootshine);
                return MNK.DragonKick;
            }

            if (level < MNK.Levels.DragonKick) return MNK.Bootshine;

            return actionID;
        }
    }

    internal class MonkTwinRaptorsFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkTwinRaptorsFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<MNKGauge>();
            if (!IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) || (HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist)))
                if (gauge.RaptorFury > 0 || level < MNK.Levels.TwinSnakes)
                    return OriginalHook(MNK.TrueStrike);
            return actionID;
        }
    }

    internal class MonkDemolishingPounceFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkDemolishingPounceFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<MNKGauge>();
            if (!IsEnabled(CustomComboPreset.MonkPerfectBalanceFuryOption) || (HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist)))
                if (gauge.CoeurlFury > 0 || level < MNK.Levels.Demolish)
                    return OriginalHook(MNK.SnapPunch);
            return actionID;
        }
    }

    internal class MonkPerfectBalanceFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MonkPerfectBalanceFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.PerfectBalance)
            {
                if (HasEffect(MNK.Buffs.PerfectBalance) && IsEnabled(CustomComboPreset.MonkPerfectBalanceFeatureLockout))
                    return SMN.Physick;
                if (OriginalHook(MNK.MasterfulBlitz) != MNK.MasterfulBlitz && CanUseAction(OriginalHook(MNK.MasterfulBlitz)))
                    return OriginalHook(MNK.MasterfulBlitz);
            }

            return actionID;
        }
    }
}
