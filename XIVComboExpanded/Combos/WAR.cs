using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class WAR
    {
        public const byte ClassID = 3;
        public const byte JobID = 21;

        public const uint
            HeavySwing = 31,
            Maim = 37,
            Berserk = 38,
            InnerRelease = 7389,
            Overpower = 41,
            StormsPath = 42,
            StormsEye = 45,
            InnerBeast = 49,
            SteelCyclone = 51,
            Infuriate = 52,
            FellCleave = 3549,
            Decimate = 3550,
            RawIntuition = 3551,
            MythrilTempest = 16462,
            ChaoticCyclone = 16463,
            NascentFlash = 16464,
            InnerChaos = 16465,
            PrimalRend = 25753,
            Tomahawk = 46,
            Orogeny = 25752,
            Upheaval = 7387;

        public static class Buffs
        {
            public const ushort
                InnerRelease = 1177,
                NascentChaos = 1897,
                PrimalRendReady = 2624,
                SurgingTempest = 2677;
        }

        public static class Debuffs
        {
            public const ushort Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Maim = 4,
                StormsPath = 26,
                MythrilTempest = 40,
                StormsEye = 50,
                FellCleave = 54,
                Decimate = 60,
                MythrilTempestTrait = 74,
                NascentFlash = 76,
                InnerChaos = 80,
                PrimalRend = 90;
        }
    }

    internal class WarriorStormsPathCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorStormsPathCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.StormsPath)
            {
                if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature) && HasEffect(WAR.Buffs.InnerRelease))
                {
                    return OriginalHook(WAR.FellCleave);
                }

                if (IsEnabled(CustomComboPreset.WarriorStormsPathtoStormsEyeFeature))
                {
                    if (lastComboMove == WAR.Maim && CanUseAction(WAR.StormsEye) && !HasEffect(WAR.Buffs.SurgingTempest))
                    {
                        return OriginalHook(WAR.StormsEye);
                    }
                }

                if (IsEnabled(CustomComboPreset.WarriorStormsPathahawkFeature))
                {
                    if (CanUseAction(WAR.Tomahawk) && !InMeleeRange())
                        return WAR.Tomahawk;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == WAR.HeavySwing && CanUseAction(WAR.Maim))
                        return WAR.Maim;

                    if (lastComboMove == WAR.Maim && CanUseAction(WAR.StormsPath))
                        return WAR.StormsPath;
                }

                return WAR.HeavySwing;
            }

            return actionID;
        }
    }

    internal class WarriorStormsEyeCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorStormsEyeCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.StormsEye)
            {
                if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature) && HasEffect(WAR.Buffs.InnerRelease))
                {
                    if (IsEnabled(CustomComboPreset.WarriorInnerReleaseahawkOption))
                    {
                        return WAR.Tomahawk;
                    }

                    return OriginalHook(WAR.FellCleave);
                }

                if (IsEnabled(CustomComboPreset.WarriorStormsEyeahawkFeature))
                {
                    if (CanUseAction(WAR.Tomahawk) && !InMeleeRange())
                        return WAR.Tomahawk;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == WAR.HeavySwing && CanUseAction(WAR.Maim))
                        return IsEnabled(CustomComboPreset.WarriorStormsEyeHawkReplacementFeature) ? WAR.Tomahawk : WAR.Maim;

                    if (lastComboMove == WAR.Maim && CanUseAction(WAR.StormsEye))
                        return WAR.StormsEye;
                }

                return IsEnabled(CustomComboPreset.WarriorStormsEyeHawkReplacementFeature) ? WAR.Tomahawk : WAR.HeavySwing;
            }

            return actionID;
        }
    }

    internal class WarriorMythrilTempestCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorMythrilTempestCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.MythrilTempest)
            {
                if (CanUseAction(WAR.PrimalRend) && IsEnabled(CustomComboPreset.WarriorMythrilRendFeature))
                    return WAR.PrimalRend;

                if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature) && HasEffect(WAR.Buffs.InnerRelease))
                {
                    return OriginalHook(WAR.Decimate);
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == WAR.Overpower && CanUseAction(WAR.MythrilTempest))
                    {
                        var gauge = GetJobGauge<WARGauge>().BeastGauge;
                        if (IsEnabled(CustomComboPreset.WarriorGaugeOvercapFeature) && gauge >= 90 && level >= WAR.Levels.MythrilTempestTrait)
                            return OriginalHook(WAR.Decimate);

                        return WAR.MythrilTempest;
                    }
                }

                return CurrentTarget is null && CanUseAction(WAR.MythrilTempest) ? WAR.MythrilTempest : WAR.Overpower;
            }

            return actionID;
        }
    }

    internal class WarriorOverpowerCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorOverpowerCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.Overpower)
            {
                if (CanUseAction(WAR.PrimalRend) && IsEnabled(CustomComboPreset.WarriorMythrilRendFeature))
                    return WAR.PrimalRend;

                if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature) && HasEffect(WAR.Buffs.InnerRelease))
                {
                    return OriginalHook(WAR.Decimate);
                }

                var gauge = GetJobGauge<WARGauge>().BeastGauge;
                if (comboTime > 0)
                {
                    if (lastComboMove == WAR.Overpower && CanUseAction(WAR.MythrilTempest))
                    {
                        if (gauge >= 90 && level >= WAR.Levels.MythrilTempestTrait && IsEnabled(CustomComboPreset.WarriorGaugeOvercapFeature))
                        {
                            return OriginalHook(WAR.Decimate);
                        }

                        return WAR.MythrilTempest;
                    }
                }

                return CurrentTarget is null && CanUseAction(WAR.MythrilTempest) ? WAR.MythrilTempest : WAR.Overpower;
            }

            return actionID;
        }
    }

    internal class WarriorNascentFlashFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorNascentFlashFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.NascentFlash)
            {
                if (level >= WAR.Levels.NascentFlash)
                    return WAR.NascentFlash;
                return WAR.RawIntuition;
            }

            return actionID;
        }
    }

    internal class WarriorPrimalRendFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorPrimalRendFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (CanUseAction(WAR.PrimalRend))
                return WAR.PrimalRend;

            return actionID;
        }
    }

    internal class WarriorFellCleaveToDecimateFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorFellCleaveToDecimateFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.FellCleave || actionID == WAR.InnerBeast)
            {
                if (HasEffect(WAR.Buffs.NascentChaos) && level < WAR.Levels.InnerChaos)
                    return OriginalHook(WAR.Decimate);

                if (CanUseAction(OriginalHook(WAR.Decimate)) && (lastComboMove == WAR.MythrilTempest || lastComboMove == WAR.Overpower))
                    return OriginalHook(WAR.Decimate);
            }

            return actionID;
        }
    }

    internal class WarriorUporgyFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.WarriorUporgyFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WAR.Upheaval && CanUseAction(WAR.Orogeny) && (lastComboMove == WAR.Overpower || lastComboMove == WAR.MythrilTempest))
                return WAR.Orogeny;

            return actionID;
        }
    }
}
