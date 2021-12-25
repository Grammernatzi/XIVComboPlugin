using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class SAM
    {
        public const byte JobID = 34;

        public const uint
            Hakaze = 7477,
            Yukikaze = 7480,
            Gekko = 7481,
            Jinpu = 7478,
            Kasha = 7482,
            Shifu = 7479,
            Mangetsu = 7484,
            Fuga = 7483,
            Oka = 7485,
            Shinten = 7490,
            Kyuten = 7491,
            Guren = 7496,
            Senei = 16481,
            MeikyoShisui = 7499,
            Seigan = 7501,
            ThirdEye = 7498,
            Iaijutsu = 7867,
            TsubameGaeshi = 16483,
            KaeshiHiganbana = 16484,
            Shoha = 16487,
            Shoha2 = 25779,
            Ikishoten = 16482,
            Fuko = 25780,
            OgiNamikiri = 25781,
            KaeshiNamikiri = 25782;

        public static class Buffs
        {
            public const ushort
                MeikyoShisui = 1233,
                EyesOpen = 1252,
                Jinpu = 1298,
                Shifu = 1299,
                OgiNamikiriReady = 2959;
        }

        public static class Debuffs
        {
            public const ushort Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Jinpu = 4,
                Shifu = 18,
                Gekko = 30,
                Mangetsu = 35,
                Kasha = 40,
                Oka = 45,
                Yukikaze = 50,
                Guren = 70,
                Senei = 72,
                TsubameGaeshi = 76,
                Shoha = 80,
                Shoha2 = 82,
                Hyosetsu = 86,
                OgiNamikiri = 90;
        }
    }

    internal class SamuraiYukikazeCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiYukikazeCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Yukikaze)
            {
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Yukikaze;

                if (comboTime > 0 && lastComboMove == SAM.Hakaze && level >= SAM.Levels.Yukikaze)
                    return SAM.Yukikaze;

                return SAM.Hakaze;
            }

            return actionID;
        }
    }

    internal class SamuraiGekkoCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiGekkoCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Gekko)
            {
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Gekko;

                if (comboTime > 0)
                {
                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Jinpu)
                        return SAM.Jinpu;

                    if (lastComboMove == SAM.Jinpu && level >= SAM.Levels.Gekko)
                        return SAM.Gekko;
                }

                if (IsEnabled(CustomComboPreset.SamuraiGekkoOption))
                    return SAM.Jinpu;

                return SAM.Hakaze;
            }

            return actionID;
        }
    }

    internal class SamuraiKashaCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiKashaCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Kasha)
            {
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Kasha;

                if (comboTime > 0)
                {
                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Shifu)
                        return SAM.Shifu;

                    if (lastComboMove == SAM.Shifu && level >= SAM.Levels.Kasha)
                        return SAM.Kasha;
                }

                if (IsEnabled(CustomComboPreset.SamuraiKashaOption))
                    return SAM.Shifu;

                return SAM.Hakaze;
            }

            return actionID;
        }
    }
    /*
    internal class SamuraiMangetsuCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiMangetsuCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((!IsEnabled(CustomComboPreset.SamuraiEvilMangetsuCombo) && actionID == SAM.Mangetsu) || (IsEnabled(CustomComboPreset.SamuraiEvilMangetsuCombo) && (actionID == SAM.Fuga || actionID == SAM.Fuko)))
            {
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Mangetsu;

                if (comboTime > 0 && (lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Mangetsu)
                    return SAM.Mangetsu;

                return OriginalHook(SAM.Fuga);
            }

            return actionID;
        }
    }
    */

    internal class SamuraiMangetsuCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiMangetsuCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Mangetsu)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                {
                    if (gauge.HasGetsu)
                    {
                        return SAM.Oka;
                    }
                    else
                    {
                        return SAM.Mangetsu;
                    }
                }

                if (comboTime > 0 && (lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko))
                {
                    if (gauge.HasGetsu && gauge.HasKa)
                    {
                        // return OriginalHook(SAM.Iaijutsu);
                        if (!HasEffect(SAM.Buffs.Jinpu))
                        {
                            return SAM.Mangetsu;
                        }
                        else if (!HasEffect(SAM.Buffs.Shifu))
                        {
                            return SAM.Oka;
                        }
                        else
                        {
                            var Jinpudurat = FindEffectAny(SAM.Buffs.Jinpu);
                            var Shifudurat = FindEffectAny(SAM.Buffs.Shifu);
                            if (Shifudurat.RemainingTime >= Jinpudurat.RemainingTime) { return SAM.Mangetsu; }
                        }
                    }

                    if (level >= SAM.Levels.Oka && gauge.HasGetsu)
                        return SAM.Oka;

                    if (level >= SAM.Levels.Mangetsu)
                        return SAM.Mangetsu;
                }

                return OriginalHook(SAM.Fuga);
            }

            return actionID;
        }
    }

    internal class SamuraiOkaCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiOkaCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Oka)
            {
                if (HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Oka;

                if (comboTime > 0 && (lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Oka)
                    return SAM.Oka;

                return OriginalHook(SAM.Fuga);
            }

            return actionID;
        }
    }

    internal class SamuraiTsubameGaeshiShohaFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiTsubameGaeshiShohaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.TsubameGaeshi)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3 && OriginalHook(SAM.TsubameGaeshi) == SAM.TsubameGaeshi)
                    return SAM.Shoha;
            }

            return actionID;
        }
    }

    internal class SamuraiIaijutsuShohaFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiIaijutsuShohaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Iaijutsu)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3 && OriginalHook(SAM.TsubameGaeshi) == SAM.TsubameGaeshi)
                    return SAM.Shoha;
            }

            return actionID;
        }
    }

    internal class SamuraiTsubameGaeshiIaijutsuFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiTsubameGaeshiIaijutsuFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.TsubameGaeshi)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (level >= SAM.Levels.TsubameGaeshi && gauge.Sen == Sen.NONE)
                    return OriginalHook(SAM.TsubameGaeshi);
                return OriginalHook(SAM.Iaijutsu);
            }

            return actionID;
        }
    }

    internal class SamuraiIaijutsuTsubameGaeshiFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Iaijutsu)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (level >= SAM.Levels.TsubameGaeshi && gauge.Sen == Sen.NONE)
                    return OriginalHook(SAM.TsubameGaeshi);
                return OriginalHook(SAM.Iaijutsu);
            }

            return actionID;
        }
    }

    internal class SamuraiSeneiFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiSeneiFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Shinten)
            {
                if (IsActionOffCooldown(SAM.Senei) && level >= SAM.Levels.Senei)
                    return SAM.Senei;
            }

            return actionID;
        }
    }

    internal class SamuraiShohaFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiShohaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Shinten)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
            }

            return actionID;
        }
    }

    internal class SamuraiGurenFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiGurenFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Kyuten)
            {
                if (IsActionOffCooldown(SAM.Guren) && level >= SAM.Levels.Guren)
                    return SAM.Guren;
            }

            return actionID;
        }
    }

    internal class SamuraiShoha2Feature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiShoha2Feature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Kyuten)
            {
                var gauge = GetJobGauge<SAMGauge>();
                if (level >= SAM.Levels.Shoha2 && gauge.MeditationStacks >= 3)
                    return SAM.Shoha2;
            }

            return actionID;
        }
    }

    internal class SamuraiIkishotenNamikiriFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiIkishotenNamikiriFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Ikishoten)
            {
                if (level >= SAM.Levels.OgiNamikiri)
                {
                    if (HasEffect(SAM.Buffs.OgiNamikiriReady))
                    {
                        var gauge = GetJobGauge<SAMGauge>();
                        if (gauge.MeditationStacks >= 3)
                            return SAM.Shoha;
                        return SAM.OgiNamikiri;
                    }

                    if (OriginalHook(SAM.OgiNamikiri) == SAM.KaeshiNamikiri)
                        return SAM.KaeshiNamikiri;
                }

                return SAM.Ikishoten;
            }

            return actionID;
        }
    }

    internal class SamuraiAutoFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.SamuraiAutoFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Hakaze)
            {
                if (IsEnabled(CustomComboPreset.SamuraiAutoFeature))
                {
                    var gauge = GetJobGauge<SAMGauge>();
                    var meikyo = HasEffect(SAM.Buffs.MeikyoShisui);

                    if (meikyo)
                    {
                        if (!gauge.HasKa)
                            return SAM.Kasha;
                        if (!gauge.HasGetsu)
                            return SAM.Gekko;
                        return SAM.Yukikaze;
                    }

                    if (!gauge.HasKa)
                    {
                        if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Shifu)
                            return SAM.Shifu;

                        if (lastComboMove == SAM.Shifu && level >= SAM.Levels.Kasha)
                            return SAM.Kasha;

                    }
                    if (!gauge.HasGetsu)
                    {
                        if (lastComboMove == SAM.Hakaze)
                            return SAM.Jinpu;

                        if (lastComboMove == SAM.Jinpu && level >= SAM.Levels.Gekko)
                            return SAM.Gekko;
                    }
                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Yukikaze)
                        return SAM.Yukikaze;

                    return actionID;

                }
            }
            return actionID;

        }
    }
}
