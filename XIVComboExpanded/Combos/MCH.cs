using System;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedestPlugin.Combos
{
    internal static class MCH
    {
        public const byte JobID = 31;

        public const uint
            // Single target
            CleanShot = 2873,
            HeatedCleanShot = 7413,
            SplitShot = 2866,
            HeatedSplitShot = 7411,
            SlugShot = 2868,
            HeatedSlugshot = 7412,
            // Charges
            GaussRound = 2874,
            Ricochet = 2890,
            // AoE
            SpreadShot = 2870,
            Scattergun = 25786,
            AutoCrossbow = 16497,
            // Rook
            RookAutoturret = 2864,
            RookOverdrive = 7415,
            AutomatonQueen = 16501,
            QueenOverdrive = 16502,
            // Other
            Hypercharge = 17209,
            HeatBlast = 7410,
            HotShot = 2872,
            Drill = 16498,
            AirAnchor = 16500,
            Chainsaw = 25788;

        public static class Buffs
        {
            public const ushort Placeholder = 0;
        }

        public static class Debuffs
        {
            public const ushort Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                SlugShot = 2,
                GaussRound = 15,
                CleanShot = 26,
                Hypercharge = 30,
                HeatBlast = 35,
                RookOverdrive = 40,
                Ricochet = 50,
                AutoCrossbow = 52,
                HeatedSplitShot = 54,
                Drill = 58,
                HeatedSlugshot = 60,
                HeatedCleanShot = 64,
                ChargedActionMastery = 74,
                AirAnchor = 76,
                QueenOverdrive = 80,
                Chainsaw = 90;
        }
    }

    internal class MachinistMainCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistMainCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsOverheated && level >= MCH.Levels.HeatBlast)
                    return MCH.HeatBlast;

                if (comboTime > 0)
                {
                    if (lastComboMove == MCH.SplitShot && level >= MCH.Levels.SlugShot)
                        return OriginalHook(MCH.SlugShot);

                    if (lastComboMove == MCH.SlugShot && level >= MCH.Levels.CleanShot)
                        return OriginalHook(MCH.CleanShot);
                }

                return OriginalHook(MCH.SplitShot);
            }

            return actionID;
        }
    }

    internal class MachinistGaussRoundRicochetFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistGaussRoundRicochetFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.GaussRound || actionID == MCH.Ricochet)
            {
                if (level >= MCH.Levels.Ricochet)
                    return CalcBestAction(actionID, MCH.GaussRound, MCH.Ricochet);

                return MCH.GaussRound;
            }

            return actionID;
        }
    }

    internal class MachinistOverheatFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistOverheatFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.HeatBlast || actionID == MCH.AutoCrossbow)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (!gauge.IsOverheated && level >= MCH.Levels.Hypercharge)
                    return MCH.Hypercharge;

                if (level < MCH.Levels.AutoCrossbow)
                    return MCH.HeatBlast;
            }

            return actionID;
        }
    }

    internal class MachinistSpreadShotFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistSpreadShotFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.SpreadShot || actionID == MCH.Scattergun)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsOverheated && level >= MCH.Levels.AutoCrossbow)
                    return MCH.AutoCrossbow;

                return OriginalHook(MCH.SpreadShot);
            }

            return actionID;
        }
    }

    internal class MachinistOverdriveFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistOverdriveFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.RookAutoturret || actionID == MCH.AutomatonQueen)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsRobotActive)
                    // ROOKIE
                    return OriginalHook(MCH.QueenOverdrive);
            }

            return actionID;
        }
    }

    internal class MachinistDrillAirAnchorFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistHotShotDrillChainsawFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.Drill || actionID == MCH.HotShot || actionID == MCH.AirAnchor)
            {
                if (level >= MCH.Levels.Chainsaw)
                    return CalcBestAction(actionID, MCH.Chainsaw, MCH.AirAnchor, MCH.Drill);

                if (level >= MCH.Levels.AirAnchor)
                    return CalcBestAction(actionID, MCH.AirAnchor, MCH.Drill);

                if (level >= MCH.Levels.Drill)
                    return CalcBestAction(actionID, MCH.Drill, MCH.HotShot);

                return MCH.HotShot;
            }

            return actionID;
        }
    }
}
