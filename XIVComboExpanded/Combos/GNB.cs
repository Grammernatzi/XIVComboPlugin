using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class GNB
    {
        public const byte JobID = 37;

        public const uint
            KeenEdge = 16137,
            NoMercy = 16138,
            BrutalShell = 16139,
            DemonSlice = 16141,
            SolidBarrel = 16145,
            GnashingFang = 16146,
            DemonSlaughter = 16149,
            SonicBreak = 16153,
            Continuation = 16155,
            JugularRip = 16156,
            AbdomenTear = 16157,
            EyeGouge = 16158,
            BowShock = 16159,
            BurstStrike = 16162,
            FatedCircle = 16163,
            Bloodfest = 16164,
            DoubleDown = 25760,
            ReignOfBeasts = 36937,
            Hypervelocity = 25759,
            FatedBrand = 36936,
            LightningShot = 16143;

        public static class Buffs
        {
            public const ushort
                NoMercy = 1831,
                ReadyToRip = 1842,
                ReadyToTear = 1843,
                ReadyToGouge = 1844,
                ReadyToBlast = 2686,
                Bloodfest = 5051;
        }

        public static class Debuffs
        {
            public const ushort
                BowShock = 1838;
        }

        public static class Levels
        {
            public const byte
                BrutalShell = 4,
                SolidBarrel = 26,
                BurstStrike = 30,
                DemonSlaughter = 40,
                SonicBreak = 54,
                BowShock = 62,
                Continuation = 70,
                FatedCircle = 72,
                Bloodfest = 76,
                EnhancedContinuation = 86,
                CartridgeCharge2 = 88,
                DoubleDown = 90;
        }
    }

    internal class GunbreakerSolidBarrelCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerSolidBarrelCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.SolidBarrel)
            {
                if (IsEnabled(CustomComboPreset.GunbreakerSolidShotFeature))
                {
                    if (CanUseAction(GNB.LightningShot) && !InMeleeRange())
                        return GNB.LightningShot;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == GNB.KeenEdge && level >= GNB.Levels.BrutalShell)
                        return GNB.BrutalShell;

                    if (lastComboMove == GNB.BrutalShell && level >= GNB.Levels.SolidBarrel)
                    {
                        if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature))
                        {
                            var gauge = GetJobGauge<GNBGauge>();
                            var maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;
                            if (HasEffect(GNB.Buffs.Bloodfest)) maxAmmo += maxAmmo;

                            if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont))
                            {
                                if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast))
                                    return GNB.Hypervelocity;
                            }

                            if (level >= GNB.Levels.BurstStrike && gauge.Ammo == maxAmmo)
                                return GNB.BurstStrike;
                        }

                        return GNB.SolidBarrel;
                    }
                }

                return GNB.KeenEdge;
            }

            return actionID;
        }
    }

    internal class GunbreakerGnashingFangContinuation : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerGnashingFangContinuation;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.GnashingFang)
            {
                if (level >= GNB.Levels.Continuation)
                {
                    if (HasEffect(GNB.Buffs.ReadyToRip) || HasEffect(GNB.Buffs.ReadyToTear) || HasEffect(GNB.Buffs.ReadyToGouge))
                        return OriginalHook(GNB.Continuation);
                }

                return OriginalHook(GNB.GnashingFang);
            }

            return actionID;
        }
    }

    internal class GunbreakerBurstStrikeContinuation : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerBurstStrikeCont;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.BurstStrike)
            {
                if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast))
                    return GNB.Hypervelocity;
            }

            return actionID;
        }
    }

    internal class GunbreakerFatedCircleContinuation : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerFatedCircleContinuation;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.FatedCircle)
            {
                if (OriginalHook(GNB.Continuation) == GNB.FatedBrand)
                    return GNB.FatedBrand;
            }

            return actionID;
        }
    }

    /*    internal class GunbreakerBowShockSonicBreakFeature : CustomCombo
        {
            protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerBowShockSonicBreakFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == GNB.BowShock || actionID == GNB.SonicBreak)
                {
                    if (level >= GNB.Levels.BowShock && level >= GNB.Levels.SonicBreak)
                    {
                        if (GetCooldown(GNB.SolidBarrel).CooldownRemaining < 0.5 && IsActionOffCooldown(GNB.SonicBreak) && IsEnabled(CustomComboPreset.GunbreakerBowShockSonicBreakOption))
                            return GNB.SonicBreak;
                        return CalcBestAction(actionID, GNB.BowShock, GNB.SonicBreak);
                    }
                }

                return actionID;
            }
        }*/

    internal class GunbreakerDoubleDownFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerDoubleDownFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.BurstStrike || actionID == GNB.FatedCircle)
            {
                var gauge = GetJobGauge<GNBGauge>();
                if (level >= GNB.Levels.DoubleDown && gauge.Ammo >= 1)
                {
                    if (IsActionOffCooldown(GNB.DoubleDown))
                        return GNB.DoubleDown;
                }
            }

            return actionID;
        }
    }

    internal class GunbreakerBloodfestNoMercyFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerBloodfestNoMercyFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.Bloodfest)
            {
                if (!CanUseAction(GNB.Bloodfest)) return GNB.NoMercy;
                if (!IsActionOffCooldown(GNB.Bloodfest))
                {
                    if (IsActionOffCooldown(GNB.NoMercy)) return GNB.NoMercy;

                    if (IsEnabled(CustomComboPreset.GunbreakerNoMercyDoubleDownFeature))
                    {
                        var gauge = GetJobGauge<GNBGauge>();
                        if (gauge.Ammo >= 1 && (HasEffect(GNB.Buffs.NoMercy) || CanUseAction(OriginalHook(GNB.ReignOfBeasts))))
                        {
                            if (GetCooldown(GNB.SolidBarrel).CooldownRemaining >= 0.5 && IsActionOffCooldown(GNB.BowShock) && IsEnabled(CustomComboPreset.GunbreakerNoMercyFeature))
                                return GNB.BowShock;
                            if (IsActionOffCooldown(GNB.DoubleDown) && level >= GNB.Levels.DoubleDown)
                                return GNB.DoubleDown;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.GunbreakerNoMercyFeature))
                    {
                        if (HasEffect(GNB.Buffs.NoMercy) || CanUseAction(OriginalHook(GNB.ReignOfBeasts)))
                        {
                            if ((GetCooldown(GNB.SolidBarrel).CooldownRemaining >= 0.5 || OriginalHook(GNB.NoMercy) == GNB.NoMercy) && IsActionOffCooldown(GNB.BowShock))
                                return GNB.BowShock;
                        }
                    }

                    if (OriginalHook(GNB.NoMercy) == GNB.SonicBreak) return GNB.SonicBreak;
                }
            }

            return actionID;
        }
    }

    internal class GunbreakerBurstHeartFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerBurstHeartFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (CanUseAction(OriginalHook(GNB.ReignOfBeasts)))
                return OriginalHook(GNB.ReignOfBeasts);
            return actionID;
        }
    }

    internal class GunbreakerBurstStrikeToFatedCircleFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerBurstStrikeToFatedCircleFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.BurstStrike)
            {
                if (level >= GNB.Levels.FatedCircle && (lastComboMove == GNB.DemonSlice || lastComboMove == GNB.DemonSlaughter))
                {
                    if (OriginalHook(GNB.Continuation) == GNB.FatedBrand)
                        return GNB.FatedBrand;
                    return GNB.FatedCircle;
                }
            }

            return actionID;
        }
    }

    internal class GunbreakerDemonSlaughterCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerDemonSlaughterCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == (IsEnabled(CustomComboPreset.GunbreakerEvilDemonSlaughterCombo) ? GNB.DemonSlice : GNB.DemonSlaughter))
            {
                if (IsEnabled(CustomComboPreset.GunbreakerDemonHeartFeature) && CanUseAction(OriginalHook(GNB.ReignOfBeasts)))
                    return OriginalHook(GNB.ReignOfBeasts);

                if (comboTime > 0 && lastComboMove == GNB.DemonSlice && level >= GNB.Levels.DemonSlaughter)
                {
                    if (IsEnabled(CustomComboPreset.GunbreakerFatedCircleFeature) && level >= GNB.Levels.FatedCircle)
                    {
                        var gauge = GetJobGauge<GNBGauge>();
                        var maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;
                        if (HasEffect(GNB.Buffs.Bloodfest)) maxAmmo += maxAmmo;

                        if (gauge.Ammo == maxAmmo)
                        {
                            return GNB.FatedCircle;
                        }

                        if (OriginalHook(GNB.Continuation) == GNB.FatedBrand)
                            return GNB.FatedBrand;
                    }

                    return GNB.DemonSlaughter;
                }

                return GNB.DemonSlice;
            }

            return actionID;
        }
    }

    internal class GunbreakerNoMercyDoubleDownFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerNoMercyDoubleDownFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<GNBGauge>();
            if (gauge.Ammo >= 1 && HasEffect(GNB.Buffs.NoMercy))
            {
                if (GetCooldown(GNB.SolidBarrel).CooldownRemaining >= 0.5 && IsActionOffCooldown(GNB.BowShock) && IsEnabled(CustomComboPreset.GunbreakerNoMercyFeature))
                    return GNB.BowShock;
                if (IsActionOffCooldown(GNB.DoubleDown) && level >= GNB.Levels.DoubleDown)
                    return GNB.DoubleDown;
            }

            return actionID;
        }
    }

    internal class GunbreakerNoMercyFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.GunbreakerNoMercyFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.NoMercy)
            {
                if (HasEffect(GNB.Buffs.NoMercy))
                {
                    if ((GetCooldown(GNB.SolidBarrel).CooldownRemaining >= 0.5 || OriginalHook(GNB.NoMercy) == GNB.NoMercy) && IsActionOffCooldown(GNB.BowShock))
                        return GNB.BowShock;
                }
            }

            return actionID;
        }
    }
}
