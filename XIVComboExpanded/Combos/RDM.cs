using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class RDM
    {
        public const byte JobID = 35;

        public const uint
            Verthunder = 7505,
            Veraero = 7507,
            Verthunder3 = 25855,
            Veraero3 = 25856,
            Veraero2 = 16525,
            Verthunder2 = 16524,
            Impact = 16526,
            Redoublement = 7516,
            EnchantedRedoublement = 7529,
            Zwerchhau = 7512,
            EnchantedZwerchhau = 7528,
            Moulinet = 7513,
            Riposte = 7504,
            EnchantedRiposte = 7527,
            Scatter = 7509,
            Verstone = 7511,
            Verfire = 7510,
            Jolt = 7503,
            Jolt2 = 7524,
            Verholy = 7526,
            Verflare = 7525,
            Scorch = 16530,
            Resolution = 25858;

        public static class Buffs
        {
            public const ushort
                Swiftcast = 167,
                VerfireReady = 1234,
                VerstoneReady = 1235,
                Acceleration = 1238,
                Dualcast = 1249,
                LostChainspell = 2560;
        }

        public static class Debuffs
        {
            public const ushort Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Jolt = 2,
                Verthunder = 4,
                Veraero = 10,
                Verraise = 64,
                Zwerchhau = 35,
                Redoublement = 50,
                Vercure = 54,
                Jolt2 = 62,
                Impact = 66,
                Verflare = 68,
                Verholy = 70,
                Scorch = 80,
                Resolution = 90;
        }
    }

    internal class RedMageAoECombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.RedMageAoECombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Veraero2 || actionID == RDM.Verthunder2)
            {
                if (HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.LostChainspell) || HasEffect(RDM.Buffs.Acceleration) || (OriginalHook(RDM.Impact) != RDM.Impact && OriginalHook(RDM.Impact) != RDM.Scatter))
                    return OriginalHook(RDM.Impact);

                var gauge = GetJobGauge<RDMGauge>();
                if (actionID == RDM.Veraero2 && gauge.WhiteMana > gauge.BlackMana)
                {
                    return OriginalHook(RDM.Verthunder2);
                }

                return actionID;
            }

            return actionID;
        }
    }

    internal class RedMageMeleeCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.RedMageMeleeCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Redoublement || actionID == RDM.Moulinet)
            {
                var gauge = GetJobGauge<RDMGauge>();

                if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlus) && !IsEnabled(CustomComboPreset.RedMageMeleeComboPlusPlus))
                {
                    if (OriginalHook(RDM.Verthunder2) == RDM.Verflare)
                    {
                        if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlusVerholy) && OriginalHook(RDM.Veraero2) == RDM.Verholy)
                            return RDM.Verholy;
                        return RDM.Verflare;
                    }
                }

                if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlusPlus))
                {
                    if (OriginalHook(RDM.Verthunder2) == RDM.Verflare)
                    {
                        if (gauge.BlackMana >= gauge.WhiteMana && level >= RDM.Levels.Verholy)
                        {
                            if (HasEffect(RDM.Buffs.VerstoneReady) && !HasEffect(RDM.Buffs.VerfireReady) && (gauge.BlackMana - gauge.WhiteMana <= 9))
                                return RDM.Verflare;

                            return RDM.Verholy;
                        }
                        else if (level >= RDM.Levels.Verflare)
                        {
                            if (!HasEffect(RDM.Buffs.VerstoneReady) && HasEffect(RDM.Buffs.VerfireReady) && level >= RDM.Levels.Verholy && (gauge.WhiteMana - gauge.BlackMana <= 9))
                                return RDM.Verholy;

                            return RDM.Verflare;
                        }
                    }
                }

                if (actionID == RDM.Redoublement)
                {
                    if ((lastComboMove == RDM.Riposte || lastComboMove == RDM.EnchantedRiposte) && level >= RDM.Levels.Zwerchhau)
                        return OriginalHook(RDM.Zwerchhau);

                    if (lastComboMove == RDM.Zwerchhau && level >= RDM.Levels.Redoublement)
                        return OriginalHook(RDM.Redoublement);
                }

                if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlus) || IsEnabled(CustomComboPreset.RedMageMeleeComboPlusPlus))
                {
                    if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                        return RDM.Scorch;
                    if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                        return RDM.Resolution;
                }

                if (actionID == RDM.Moulinet)
                    return OriginalHook(RDM.Moulinet);
                return OriginalHook(RDM.Riposte);
            }

            return actionID;
        }
    }

    internal class RedMageVerprocCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.RedMageVerprocCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Verstone || actionID == RDM.Verfire)
            {
                if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                    return RDM.Resolution;

                if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                    return RDM.Scorch;

                if (actionID == RDM.Verstone && OriginalHook(RDM.Verthunder2) == RDM.Verflare && level >= RDM.Levels.Verholy)
                    return RDM.Verholy;

                if (actionID == RDM.Verfire && OriginalHook(RDM.Verthunder2) == RDM.Verflare && level >= RDM.Levels.Verflare)
                    return RDM.Verflare;

                if (IsEnabled(CustomComboPreset.RedMageVerprocComboPlus))
                {
                    if (actionID == RDM.Verstone && (HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.LostChainspell) || HasEffect(RDM.Buffs.Acceleration)) && level >= RDM.Levels.Veraero)
                        return OriginalHook(RDM.Veraero);

                    if (actionID == RDM.Verfire && (HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.LostChainspell) || HasEffect(RDM.Buffs.Acceleration)) && level >= RDM.Levels.Verthunder)
                        return OriginalHook(RDM.Verthunder);
                }

                if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerFeatureStone))
                {
                    if (actionID == RDM.Verstone && !HasEffect(RDM.Buffs.VerstoneReady) && !HasCondition(ConditionFlag.InCombat) && level >= RDM.Levels.Veraero)
                        return OriginalHook(RDM.Veraero);
                }

                if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerFeatureFire))
                {
                    if (actionID == RDM.Verfire && !HasEffect(RDM.Buffs.VerfireReady) && !HasCondition(ConditionFlag.InCombat) && level >= RDM.Levels.Verthunder)
                        return OriginalHook(RDM.Verthunder);
                }

                if (actionID == RDM.Verstone && HasEffect(RDM.Buffs.VerstoneReady))
                    return RDM.Verstone;

                if (actionID == RDM.Verfire && HasEffect(RDM.Buffs.VerfireReady))
                    return RDM.Verfire;

                return OriginalHook(RDM.Jolt2);
            }

            return actionID;
        }

        internal class RedMageVeraeroVerThunderScorchFeature : CustomCombo
        {
            protected override CustomComboPreset Preset => CustomComboPreset.RedMageVeraeroVerThunderScorchFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                    return RDM.Resolution;

                if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                    return RDM.Scorch;

                return actionID;
            }
        }
    }
}
