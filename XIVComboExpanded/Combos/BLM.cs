using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class BLM
    {
        public const byte ClassID = 7;
        public const byte JobID = 25;

        public const uint
            Fire = 141,
            Blizzard = 142,
            Thunder = 144,
            Blizzard2 = 25793,
            Fire2 = 147,
            Transpose = 149,
            Fire3 = 152,
            Thunder3 = 153,
            Blizzard3 = 154,
            Scathe = 156,
            Freeze = 159,
            Flare = 162,
            LeyLines = 3573,
            Enochian = 3575,
            Blizzard4 = 3576,
            Fire4 = 3577,
            BetweenTheLines = 7419,
            Despair = 16505,
            UmbralSoul = 16506,
            Foul = 7422,
            Xenoglossy = 16507,
            HighFire2 = 25794,
            HighBlizzard2 = 25795,
            Amplifier = 25796;

        public static class Buffs
        {
            public const ushort
                Thundercloud = 164,
                LeyLines = 737,
                Firestarter = 165;
        }

        public static class Debuffs
        {
            public const ushort
                Thunder = 161,
                Thunder3 = 163;
        }

        public static class Levels
        {
            public const byte
                Manafont = 30,
                Fire3 = 35,
                Freeze = 40,
                Blizzard3 = 35,
                Thunder3 = 45,
                Flare = 50,
                Enochian = 60,
                Blizzard4 = 58,
                Fire4 = 60,
                BetweenTheLines = 62,
                Despair = 72,
                UmbralSoul = 76,
                Xenoglossy = 80,
                Amplifier = 86;
        }
    }

    internal class BlackEnochianFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackEnochianFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Fire4 || actionID == BLM.Blizzard4)
            {
                var gauge = GetJobGauge<BLMGauge>();

                if (IsEnabled(CustomComboPreset.BlackEnochianDespairFeature) && gauge.InAstralFire)
                {
                    if (level >= BLM.Levels.Despair && LocalPlayer?.CurrentMp < 2400 && LocalPlayer?.CurrentMp >= 800)
                        return BLM.Despair;
/*                    if (level >= BLM.Levels.Manafont && LocalPlayer?.CurrentMp < 800 && IsActionOffCooldown(BLM.Manafont)) //Maybe replace Despair itself with Manafont instead.
                        return BLM.Manafont;*/ 
                    if (level >= BLM.Levels.Blizzard3 && LocalPlayer?.CurrentMp < 800)
                        return BLM.Blizzard3;
                }

                if (gauge.InUmbralIce && gauge.UmbralHearts == 3 && LocalPlayer?.CurrentMp >= 9600)
                    return BLM.Fire3;

                return gauge.InUmbralIce ? BLM.Blizzard4 : BLM.Fire4;
            }

            return actionID;
        }
    }

    internal class BlackFlareDespairFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackFlareDespairFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Flare && !IsEnabled(CustomComboPreset.BlackFreezeFlareFeature))
            {
                if (TargetHasEffect(BLM.Debuffs.Thunder3) && IsEnabled(CustomComboPreset.BlackFlareDespairFeature) && level >= BLM.Levels.Despair)
                    return BLM.Despair;
            }

            return actionID;
        }
    }

    internal class BlackFreezeFlareFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackFreezeFlareFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Freeze || actionID == BLM.Flare)
            {
                var gauge = GetJobGauge<BLMGauge>();

                if (TargetHasEffect(BLM.Debuffs.Thunder3) && IsEnabled(CustomComboPreset.BlackFlareDespairFeature) && level >= BLM.Levels.Despair && gauge.InAstralFire)
                    return BLM.Despair;

                return gauge.InUmbralIce ? BLM.Freeze : BLM.Flare;
            }

            return actionID;
        }
    }

    internal class BlackFire2Feature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackFire2Feature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Fire2 || actionID == BLM.HighFire2)
            {
                var gauge = GetJobGauge<BLMGauge>();

                if (LocalPlayer is null) return actionID;

                if (TargetHasEffect(BLM.Debuffs.Thunder3) && IsEnabled(CustomComboPreset.BlackFlareDespairFeature) && level >= BLM.Levels.Despair)
                    return BLM.Despair;

                if (level >= BLM.Levels.Flare && ((gauge.UmbralHearts <= 1 && level >= BLM.Levels.Blizzard4) || LocalPlayer.CurrentMp < 3800) && gauge.InAstralFire)
                    return BLM.Flare;
            }

            return actionID;
        }
    }

    internal class BlackBlizzard2Feature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackBlizzard2Feature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Blizzard2 || actionID == BLM.HighBlizzard2)
            {
                var gauge = GetJobGauge<BLMGauge>();

                if (level >= BLM.Levels.Freeze && gauge.InUmbralIce)
                    return BLM.Freeze;
            }

            return actionID;
        }
    }

    internal class BlackManaFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackManaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Transpose)
            {
                var gauge = GetJobGauge<BLMGauge>();
                if (gauge.InUmbralIce && gauge.IsEnochianActive && level >= BLM.Levels.UmbralSoul)
                    return BLM.UmbralSoul;
            }

            return actionID;
        }
    }

    internal class BlackLeyLinesFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackLeyLinesFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.LeyLines)
            {
                if (HasEffect(BLM.Buffs.LeyLines) && level >= BLM.Levels.BetweenTheLines)
                    return BLM.BetweenTheLines;
            }

            return actionID;
        }
    }

    internal class BlackBlizzardFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackBlizzardFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Blizzard)
            {
                var gauge = GetJobGauge<BLMGauge>();
                if (level >= BLM.Levels.Blizzard3 && !gauge.InUmbralIce)
                    return BLM.Blizzard3;
                return OriginalHook(BLM.Blizzard);
            }

            return actionID;
        }
    }

    internal class BlackFireFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackFireFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Fire)
            {
                var gauge = GetJobGauge<BLMGauge>();
                if (level >= BLM.Levels.Fire3 && (!gauge.InAstralFire || HasEffect(BLM.Buffs.Firestarter)))
                    return BLM.Fire3;
                return OriginalHook(BLM.Fire);
            }

            return actionID;
        }
    }

    internal class BlackXenoAmpFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackXenoAmpFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            return ((IsActionOffCooldown(BLM.Amplifier) && GetCooldown(BLM.Fire).CooldownRemaining > 0.5) || LocalPlayer?.TargetObject is null) && level >= BLM.Levels.Amplifier ? BLM.Amplifier : actionID;
        }
    }

    internal class BlackScatheFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackScatheFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Scathe)
            {
                var gauge = GetJobGauge<BLMGauge>();
                if (level >= BLM.Levels.Xenoglossy && gauge.PolyglotStacks > 0)
                    return ((IsActionOffCooldown(BLM.Amplifier) && GetCooldown(BLM.Fire).CooldownRemaining > 0.5) || LocalPlayer?.TargetObject is null) && level >= BLM.Levels.Amplifier && IsEnabled(CustomComboPreset.BlackXenoAmpFeature) ? BLM.Amplifier : BLM.Xenoglossy;
            }

            return actionID;
        }
    }
}
