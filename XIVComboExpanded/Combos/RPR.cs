using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class RPR
    {
        public const byte JobID = 39;

        public const uint
            // Single Target
            Slice = 24373,
            WaxingSlice = 24374,
            InfernalSlice = 24375,
            Gibbet = 24382,
            Gallows = 24383,
            ShadowOfDeath = 24378,
            BloodStalk = 24389,
            Gluttony = 24393,
            // AoE
            SpinningScythe = 24376,
            NightmareScythe = 24377,
            Guillotine = 24384,
            GrimSwathe = 24392,
            // Shroud
            Enshroud = 24394,
            Communio = 24398,
            ArcaneCircle = 24405,
            PlentifulHarvest = 24385,
            // Misc
            Soulsow = 24387,
            HarvestMoon = 24388,
            HellsIngress = 24401,
            HellsEgress = 24402,
            Regress = 24403;

        public static class Buffs
        {
            public const ushort
                Enshrouded = 2593,
                SoulReaver = 2587,
                ImmortalSacrifice = 2592,
                EnhancedGibbet = 2588,
                EnhancedGallows = 2589,
                EnhancedCrossReaping = 2591,
                Threshold = 2595;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Slice = 1,
                WaxingSlice = 5,
                SpinningScythe = 25,
                InfernalSlice = 30,
                NightmareScythe = 45,
                Gluttony = 76,
                Enshroud = 80,
                Soulsow = 82,
                PlentifulHarvest = 88,
                Communio = 90;
        }
    }

    internal class ReaperComboCommunioFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperComboCommunioFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gibbet || actionID == RPR.Gallows || actionID == RPR.Guillotine)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (HasEffect(RPR.Buffs.Enshrouded) && gauge.LemureShroud == 1 && (gauge.VoidShroud == 0 || !IsEnabled(CustomComboPreset.ReaperLemureFeature)) && level >= RPR.Levels.Communio)
                    return RPR.Communio;
            }

            return actionID;
        }
    }

    internal class ReaperSoulsowReminderFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperSoulsowReminderFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ShadowOfDeath)
            {
                if (OriginalHook(RPR.Soulsow) != RPR.HarvestMoon && !HasCondition(ConditionFlag.InCombat) && level >= RPR.Levels.Soulsow)
                    return RPR.Soulsow;
            }

            return actionID;
        }
    }

    internal class ReaperSoulsowFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperSoulsowFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ShadowOfDeath)
            {
                if (OriginalHook(RPR.Soulsow) != RPR.HarvestMoon && LocalPlayer?.TargetObject is null && level >= RPR.Levels.Soulsow)
                    return RPR.Soulsow;
            }

            return actionID;
        }
    }

    internal class ReaperLemureFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperLemureFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gibbet || actionID == RPR.Gallows || actionID == RPR.Guillotine)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (HasEffect(RPR.Buffs.Enshrouded) && gauge.VoidShroud >= 2)
                {
                    if (actionID == RPR.Guillotine)
                        return OriginalHook(RPR.GrimSwathe);
                    return OriginalHook(RPR.BloodStalk);
                }
            }

            return actionID;
        }
    }

    internal class ReaperStalkingSwathingFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperStalkingSwathingFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (gauge.VoidShroud >= 2)
                return OriginalHook(actionID);

            if (gauge.LemureShroud >= 1)
            {
                if (IsEnabled(CustomComboPreset.ReaperComboCommunioFeature))
                {
                    if (gauge.LemureShroud == 1 && level >= RPR.Levels.Communio)
                        return RPR.Communio;
                }

                if (actionID == RPR.GrimSwathe) return OriginalHook(RPR.Guillotine);

                return HasEffect(RPR.Buffs.EnhancedCrossReaping) ? OriginalHook(RPR.Gallows) : OriginalHook(RPR.Gibbet);
            }

            if (HasEffect(RPR.Buffs.SoulReaver))
            {
                if (actionID == RPR.GrimSwathe) return RPR.Guillotine;
                return HasEffect(RPR.Buffs.EnhancedGallows) ? RPR.Gallows : RPR.Gibbet;
            }

            return actionID;
        }
    }

    internal class ReaperSliceCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperSliceCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == (IsEnabled(CustomComboPreset.ReaperInfernalSliceCombo) ? RPR.InfernalSlice : RPR.Slice))
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (OriginalHook(RPR.Soulsow) != RPR.HarvestMoon && !HasCondition(ConditionFlag.InCombat) && IsEnabled(CustomComboPreset.ReaperSoulsowReminderFeature) && level >= RPR.Levels.Soulsow)
                    return RPR.Soulsow;

                if (IsEnabled(CustomComboPreset.ReaperLemureFeature))
                {
                    if (HasEffect(RPR.Buffs.Enshrouded) && gauge.VoidShroud >= 2)
                    {
                        return OriginalHook(RPR.BloodStalk);
                    }
                }

                if (IsEnabled(CustomComboPreset.ReaperComboCommunioFeature))
                {
                    if (HasEffect(RPR.Buffs.Enshrouded) && gauge.LemureShroud == 1 && gauge.VoidShroud == 0 && level >= RPR.Levels.Communio)
                        return RPR.Communio;
                }

                if (IsEnabled(CustomComboPreset.ReaperGibbetGallowsFeature) && (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded)))
                {
                    if ((HasEffect(RPR.Buffs.EnhancedGallows) && !HasEffect(RPR.Buffs.Enshrouded) && IsEnabled(CustomComboPreset.ReaperGibbetGallowsOption)) || (HasEffect(RPR.Buffs.EnhancedCrossReaping) && HasEffect(RPR.Buffs.Enshrouded)))
                        return OriginalHook(RPR.Gallows);

                    return OriginalHook(RPR.Gibbet);
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                        return RPR.WaxingSlice;

                    if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                        return RPR.InfernalSlice;
                }

                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class ReaperScytheCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperScytheCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == (IsEnabled(CustomComboPreset.ReaperNightmareScytheCombo) ? RPR.NightmareScythe : RPR.SpinningScythe))
            {
                if (OriginalHook(RPR.Soulsow) == RPR.HarvestMoon && IsEnabled(CustomComboPreset.ReaperSoulsowFeature) && LocalPlayer?.TargetObject is not null && level >= RPR.Levels.Soulsow)
                    return RPR.HarvestMoon;

                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperLemureFeature))
                {
                    if (HasEffect(RPR.Buffs.Enshrouded) && gauge.VoidShroud >= 2)
                    {
                        return OriginalHook(RPR.GrimSwathe);
                    }
                }

                if (IsEnabled(CustomComboPreset.ReaperComboCommunioFeature))
                {
                    if (HasEffect(RPR.Buffs.Enshrouded) && gauge.LemureShroud == 1 && gauge.VoidShroud == 0 && level >= RPR.Levels.Communio)
                        return RPR.Communio;
                }

                if (IsEnabled(CustomComboPreset.ReaperGuillotineFeature) && (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded)))
                    return OriginalHook(RPR.Guillotine);

                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                        return RPR.NightmareScythe;
                }

                return RPR.SpinningScythe;
            }

            return actionID;
        }
    }

    internal class EnshroudCommunioFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperEnshroudCommunioFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Enshroud)
            {
                if (level >= RPR.Levels.Communio && HasEffect(RPR.Buffs.Enshrouded))
                    return RPR.Communio;

                return RPR.Enshroud;
            }

            return actionID;
        }
    }

    internal class GibbetGallowsFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperGibbetGallowsFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ShadowOfDeath)
            {
                if ((HasEffect(RPR.Buffs.SoulReaver) && !HasEffect(RPR.Buffs.Enshrouded)) && (!IsEnabled(CustomComboPreset.ReaperGibbetGallowsOption) || (!HasEffect(RPR.Buffs.EnhancedGallows) && !HasEffect(RPR.Buffs.EnhancedGibbet))))
                {
                    return OriginalHook(RPR.Gallows);
                }
            }

            return actionID;
        }
    }

    internal class ReaperHarvestFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperHarvestFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ArcaneCircle)
            {
                if (HasEffect(RPR.Buffs.ImmortalSacrifice) && level >= RPR.Levels.PlentifulHarvest)
                    return RPR.PlentifulHarvest;
            }

            return actionID;
        }
    }

    internal class ReaperRegressFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperRegressFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((actionID == RPR.HellsEgress || actionID == RPR.HellsIngress) && HasEffect(RPR.Buffs.Threshold))
            {
                return RPR.Regress;
            }

            return actionID;
        }
    }

    internal class ReaperBloodStalkFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperBloodStalkFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (IsActionOffCooldown(RPR.Gluttony) && level >= RPR.Levels.Gluttony && !HasEffect(RPR.Buffs.Enshrouded))
                return RPR.Gluttony;

            return actionID;
        }
    }

    internal class ReaperGrimSwatheFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperGrimSwatheFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (IsActionOffCooldown(RPR.Gluttony) && level >= RPR.Levels.Gluttony && !HasEffect(RPR.Buffs.Enshrouded))
                return RPR.Gluttony;

            return actionID;
        }
    }
}
